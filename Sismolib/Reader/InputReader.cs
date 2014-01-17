using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NationalInstruments;
using NationalInstruments.DAQmx;
using Sismolib.Utility;

namespace Sismolib
{

    public class InputReader
    {
        public static List<DataConverter> ConversionProcesses = new List<DataConverter>();
        public static List<Thread> ConversioneThread = new List<Thread>();
        public bool error = false;
        public Exception ExError;
        public bool run = false;
        public SismoDBC sismDB;
        Task[] analogInTasks;
        Task analogInTask;
        AIChannel[] AIChannels;
        AnalogSingleChannelReader[] readers;
        AnalogMultiChannelReader reader;
        System.Timers.Timer readingTimer;
        frmLoading load = new frmLoading(5);

        public event DataConvertedEventHandler DataConverted;
        public InputReader()
        {
            load.Show();
            load.SetValue("Creazione del task e timer...");
            sismDB = new SismoDBC();
            analogInTask = new Task();
            AIChannels= new AIChannel[3];
            readingTimer = new System.Timers.Timer();
            readers = new AnalogSingleChannelReader[3];
            readingTimer.Interval = 10;
            readingTimer.Elapsed += new System.Timers.ElapsedEventHandler(readingTimer_Tick);
            readingTimer.AutoReset = true;
            
        }

        /// <summary>
        /// Avvia la lettura dei dati e l'invio al database in automatico se attivato
        /// </summary>
        public void Start()
        {
            try
            {
                load.SetValue("Creazione dei canali...");
                AIChannels[0] = analogInTask.AIChannels.CreateVoltageChannel(Properties.Settings.Default.ChannelNameX, DataConverter.SismoChannelsNamesVett[(int)SismoAxis.X], AITerminalConfiguration.Pseudodifferential, Properties.Settings.Default.MinVoltage, Properties.Settings.Default.MaxVoltage, AIVoltageUnits.Volts);
                AIChannels[1] = analogInTask.AIChannels.CreateVoltageChannel(Properties.Settings.Default.ChannelNameY, DataConverter.SismoChannelsNamesVett[(int)SismoAxis.Y], AITerminalConfiguration.Pseudodifferential, Properties.Settings.Default.MinVoltage, Properties.Settings.Default.MaxVoltage, AIVoltageUnits.Volts);
                AIChannels[2] = analogInTask.AIChannels.CreateVoltageChannel(Properties.Settings.Default.ChannelNameZ, DataConverter.SismoChannelsNamesVett[(int)SismoAxis.Z], AITerminalConfiguration.Pseudodifferential, Properties.Settings.Default.MinVoltage, Properties.Settings.Default.MaxVoltage, AIVoltageUnits.Volts);

                load.SetValue("Configurazione timing...");
                analogInTask.Timing.ConfigureSampleClock("", Properties.Settings.Default.Rate, SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples, 1000);

                load.SetValue("Creazione DB e tabelle...");
                if (Properties.Settings.Default.DBConnectionEnabled)
                {
                    sismDB.ConnectDB();
                    //ok = sismDB.ConfigureConnection(SismoDBC.SismoDBType.SQLServer, ".\\SQLEXPRESS", "Granzy/Tomo-chan", "", "SismoDB");
                    bool ok = sismDB.ConfigureConnection((SismoDBC.SismoDBType)Properties.Settings.Default.DBType,
                                                            Properties.Settings.Default.DBServerAddress,
                                                            Properties.Settings.Default.DBUserID,
                                                            Properties.Settings.Default.DBPassword,
                                                            Properties.Settings.Default.DBName,
                                                            Properties.Settings.Default.DBPooling,
                                                            Properties.Settings.Default.DBTrustedConnection,
                                                            Properties.Settings.Default.DBTimeout);

                    if (ok)
                    {

                        if (sismDB.ConnectDB())
                        {
                            if (sismDB.CreateIfNotExistDB())
                            {
                                load.SetValue("Avvio timer...");
                                Thread.Sleep(500);
                                run = true;
                                readingTimer.Enabled = true;
                            }
                            else
                            {
                                System.Windows.Forms.DialogResult res = System.Windows.Forms.MessageBox.Show(
                                    "La creazione delle tabelle non è riuscito.\r\n Perfavore controllare i permessi dell'utente. \r\nDisattivare la connessione al database?",
                                    "Errore di creazione delle tabelle");

                                if (res == System.Windows.Forms.DialogResult.Yes)
                                {
                                    load.SetValue("Avvio timer...");
                                    Thread.Sleep(500);
                                    run = true;
                                    sismDB = null;
                                    Properties.Settings.Default.DBConnectionEnabled = false;
                                    readingTimer.Enabled = true;
                                    readingTimer.Start();
                                }
                            }
                        }
                        else
                        {
                            System.Windows.Forms.DialogResult res = System.Windows.Forms.MessageBox.Show(
                                "La connessione al database non è riuscita. \r\nDisattivare la connessione al database?",
                                "Errore di connessione al database");

                            if (res == System.Windows.Forms.DialogResult.Yes)
                            {
                                load.SetValue("Avvio timer...");
                                Thread.Sleep(500);
                                run = true;
                                sismDB = null;
                                Properties.Settings.Default.DBConnectionEnabled = false;
                                readingTimer.Enabled = true;
                                readingTimer.Start();
                            }
                        }


                    }
                    else
                    {
                        System.Windows.Forms.DialogResult res = System.Windows.Forms.MessageBox.Show(
                            "La la configurazione al database non è sintatticamente corretta. \r\nDisattivare la connessione al database?",
                            "Erroe sintassi configurazione database");

                        if (res == System.Windows.Forms.DialogResult.Yes)
                        {
                            load.SetValue("Avvio timer...");
                            Thread.Sleep(500);
                            run = true;
                            sismDB = null;
                            Properties.Settings.Default.DBConnectionEnabled = false;
                            readingTimer.Enabled = true;
                            readingTimer.Start();
                        }
                    }
                }
                else
                {
                    load.SetValue("Avvio timer...");
                    Thread.Sleep(500);
                    run = true;
                    sismDB = null;
                    readingTimer.Enabled = true;
                    readingTimer.Start();
                }

            }
            catch (Exception e)
            {
                error = true;
                ExError = e;
                System.Windows.Forms.MessageBox.Show(
                            e.Message,
                            "Erroe");
            }
            finally
            {
                load.CloseFrm();
            }
        }

        private void DataConverted_Event(object sender, SismoData[] e)
        {
            if (DataConverted != null)
                DataConverted(sender, e);
        }

        /// <summary>
        /// Interrompe l'invio la lettura e l'invio dei dati al database se attivato
        /// </summary>
        public void Stop()
        {
            readingTimer.Enabled = false;
            run = false;
        }

        private void readingTimer_Tick(object sender, EventArgs e)
        {
            if (run)
            {
                try
                {
                    NationalInstruments.AnalogWaveform<double>[] waves = new NationalInstruments.AnalogWaveform<double>[3];
                    DataConverter[] converters = new DataConverter[3];

                    reader = new AnalogMultiChannelReader(analogInTask.Stream);

                    waves = reader.ReadWaveform(100);

                    NationalInstruments.AnalogWaveform<double> wave = waves[0];
                    
                    for(int i=0;i<waves.Length;i++)
                    {
                        converters[i] = new DataConverter();
                        converters[i].data = waves[i];
                        converters[i].DBConnection = sismDB;
                        converters[i].DataConverted += new DataConvertedEventHandler(DataConverted_Event);
                        ConversionProcesses.Add(converters[i]);
                        Thread thrd = new Thread(converters[i].Elaborate);
                        MonitorUtility.MonitorInteface.ConverterProcesses.Add(thrd);
                        thrd.Start();
                    }
                }
                catch (Exception ex)
                {
                    error = true;
                    ExError = ex;
                }
            }
            else
            {
                readingTimer.Enabled = false;
            }
            
        }
    }
}
