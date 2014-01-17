using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Sismolib
{
    /// <summary>
    /// Classe per la creazione di un'interfaccia verso un database per l'inserimento e la gestione dei
    /// dati rilevati dal simografo
    /// </summary>
    public class SismoDBC
    {
        /// <summary>
        /// Enumeratore per la selezione del tipo di database (es. MySQL, SQLServer, ecc..)
        /// </summary>
        public enum SismoDBType { SQLServer = 0, mySQL };
        
        /// <summary>
        /// Vettore per la selezione dell'asse su cui sono stati relvati i valori
        /// </summary>
        public string[] SismoAxisVett = { "X", "Y", "Z" };

        /// <summary>
        /// Valore booleano che indica se ci sono stati errori nell'ultima procedura/funzione eseguita di questa istanza
        /// </summary>
        public bool error = false;

        /// <summary>
        /// Errore rilevato nell'ultima procedura/funzione eseguita in questa istanza
        /// </summary>
        public Exception ExError;

        //variabile per l'impostazione del tipo di database
        private SismoDBType _sType;

        //variabili comuni per l'accesso al database
        private string serverAddress;
        private string idUser;
        private string password;
        private string dbname;

        //parametri aggiuntivi per la connessione a MySQL
        private string dbPooling;

        //parametri aggiuntivi per la connessione a SQLServer
        private int timeoutCon = 30;
        private string trustedCon = "yes";

        //variabili per la connessione a MySQL
        private MySqlConnection mySQLConn;
        private MySqlCommand mySQLCmd;

        //variabili per la connessione a SQLServer
        private SqlConnection SQLSvrConn;
        private SqlCommand SQLSvrCmd;

        //variabili di configurazione
        private string NameTable;
        
        /// <summary>
        /// Costruttore per la classe SismoDBC
        /// </summary>
        public SismoDBC()
        {
            NameTable = Properties.Settings.Default.TableName;
        }

        /// <summary>
        /// Metodo per configurazione della connessione al database
        /// </summary>
        /// <param name="type">Tipo di connessione</param>
        /// <param name="server">Idirizzo del server del database</param>
        /// <param name="user">Nome utente per l'accesso al database</param>
        /// <param name="passwd">Password per l'accesso al database</param>
        /// <param name="db">Nome del database</param>
        /// <param name="pooling">Parametro pooling per connessione a MySQL</param>
        /// <param name="trusted">Parametro di connessione TrusedConnection a SQLServer</param>
        /// <param name="timeout">Timeout per la connessione</param>
        /// <returns>True se i settaggi sono sitatticamente corretti,
        /// False se ci sono errori sintattici</returns>
        public bool ConfigureConnection(SismoDBType type, string server, string user, string passwd, string db, bool pooling=false, bool trusted=true, int timeout=30)
        {
            _sType=type;
            serverAddress = server;
            idUser = user;
            password = passwd;
            dbname = db;

            if (pooling)
                dbPooling = "yes";
            else
                dbPooling = "no";

            if (trusted)
                trustedCon = "yes";
            else
                trustedCon = "no";

            timeoutCon = timeout;
            return true;
        }

        /// <summary>
        /// Funzione per la connessione al database, prima è necessario configurare utilizzando 
        /// la funzione ConfigureConnection
        /// </summary>
        /// <returns>True se la connessione è andata a buon fine,
        /// False se la connessione non è riuscita</returns>
        public bool ConnectDB()
        {
            try
            {
                string connString = GetConnectionString();
                switch(_sType)
                {
                    case SismoDBType.mySQL:
                        {
                             mySQLConn = new MySqlConnection(connString);
                             mySQLConn.Open();
                        };break;
                    case SismoDBType.SQLServer:
                        {
                            SQLSvrConn = new SqlConnection(connString);
                            SQLSvrConn.Open();
                        };break;
                    default:
                        {
                        };break;
                }
            }
            catch (Exception e)
            {
                error = true;
                ExError = e;
                return false;

            }
            return true;
        }

        public void DesconnectDB()
        {
            if (mySQLConn != null)
                mySQLConn.Close();
            else if (SQLSvrConn != null)
                SQLSvrConn.Close();
        }

        /// <summary>
        /// Funzione per l'invio dei dati al database configurato. Se il database non esiste lo crea in automatico
        /// </summary>
        /// <param name="axis">Asse del sismografo a cui sono riferiti i dati</param>
        /// <param name="data">Dati rilevati</param>
        /// <returns>True se l'oprazione è andata  buon fine,
        /// False se l'operazione ha riscontrato errori</returns>
        public bool SendData(SismoAxis axis, SismoData[] datas)
        {
            try
            {
                string qry="";
                switch (_sType)
                {
                    case SismoDBType.mySQL:
                        {
                            for(int i=0;i<datas.Length;i++)
                            {
                                qry += "INSERT INTO " + NameTable + SismoAxisVett[(int)axis] + " VALUES (" + datas[i].time.Date.ToShortDateString() + ", " + datas[i].time.Hour + ", " + datas[i].time.Minute + "," + datas[i].time.Second + "," + datas[i].time.Millisecond + ", " + datas[i].value + ") ";
                            }

                            mySQLCmd = new MySqlCommand(qry, mySQLConn);

                        }; break;
                    case SismoDBType.SQLServer:
                        {
                            //SQLSvrConn = new SqlConnection(GetConnectionString());
                        }; break;
                    default:
                        {
                        }; break;
                }
            }
            catch (Exception e)
            {
                error = true;
                ExError = e;
                return false;
            }

            return true;
        }

        private string GetConnectionString()
        {
            string connStr = "";
            switch (_sType)
            {
                case SismoDBType.mySQL:
                    {
                        connStr = String.Format("Server={0};" +
                                                "Uid={1};" +
                                                "Pwd={2};" +
                                                "Database={3}; " +
                                                "Pooling={4}",
                                                serverAddress, idUser, password, dbname, dbPooling);

                    }; break;

                case SismoDBType.SQLServer:
                    {
                        connStr = String.Format("User Id={0};" +
                                                "Password={1};" +
                                                "Data Source={2};" +
                                                "Trusted_Connection={3};" +
                                                "Initial Catalog={4}; " +
                                                "connection timeout={5}",
                                                idUser, password, serverAddress,trustedCon, dbname, timeoutCon);
                    }; break;

                default:
                    {
                    }; break;
            }
            return connStr;
        }

        /// <summary>
        /// Funzione per la creazione del database e delle tabelle nel caso in cui non esistano nel database selezionato
        /// </summary>
        /// <returns></returns>
        public bool CreateIfNotExistDB()
        {
            try
            {
                switch (_sType)
                {
                    case SismoDBType.mySQL:
                        {
                            string qry = "CREATE DATABASE IF NOT EXISTS " + dbname;

                            mySQLCmd = new MySqlCommand(qry, mySQLConn);
                            mySQLCmd.ExecuteNonQuery();

                            qry = "CREATE TABLE IF NOT EXISTS " + NameTable + "X(day DATE, " +
                                  "hour INT(2), minutes INT(2), seconds INT(2), millisecondos INT(3), val FLOAT) " +
                                  "ENGINE=INNODB;";

                            mySQLCmd.CommandText = qry;
                            mySQLCmd.ExecuteNonQuery();

                            qry = "CREATE TABLE IF NOT EXISTS " + NameTable + "Y(day DATE, " +
                                  "hour INT(2), minutes INT(2), seconds INT(2), millisecondos INT(3), val FLOAT) " +
                                  "ENGINE=INNODB;";

                            mySQLCmd.CommandText = qry;
                            mySQLCmd.ExecuteNonQuery();

                            qry = "CREATE TABLE IF NOT EXISTS " + NameTable + "Z(day DATE, " +
                                  "hour INT(2), minutes INT(2), seconds INT(2), millisecondos INT(3), val FLOAT) " +
                                  "ENGINE=INNODB;";

                            mySQLCmd.CommandText = qry;
                            mySQLCmd.ExecuteNonQuery();

                        }; break;
                    case SismoDBType.SQLServer:
                        {
                            string qry = "IF NOT EXISTS (SELECT name FROM master.sys.databases WHERE name = N'" + dbname + "')" +
                                         "BEGIN USE master CREATE DATABASE " + dbname + " END";
                            SQLSvrCmd = new SqlCommand(qry, SQLSvrConn);
                            SQLSvrCmd.ExecuteNonQuery();

                            qry = "IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = N'" + NameTable + "X' AND type = 'U')" +
                                  "CREATE TABLE " + NameTable + "X (day DATE, hour INT, minutes INT, seconds INT, milliseconds INT, val FLOAT)";

                            SQLSvrCmd.CommandText = qry;
                            SQLSvrCmd.ExecuteNonQuery();

                            qry = "IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = N'" + NameTable + "Y' AND type = 'U')" +
                                  "CREATE TABLE " + NameTable + "Y (day DATE, hour INT, minutes INT, seconds INT, milliseconds INT, val FLOAT)";

                            SQLSvrCmd.CommandText = qry;
                            SQLSvrCmd.ExecuteNonQuery();

                            qry = "IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = N'" + NameTable + "Z' AND type = 'U')" +
                                  "CREATE TABLE " + NameTable + "Z (day DATE, hour INT, minutes INT, seconds INT, milliseconds INT, val FLOAT)";

                            SQLSvrCmd.CommandText = qry;
                            SQLSvrCmd.ExecuteNonQuery();


                        }; break;
                    default:
                        {
                        }; break;
                }
            }
            catch (Exception e)
            {
                error = true;
                ExError = e;
                return false;
            }
            return true;
        }
    }
}
