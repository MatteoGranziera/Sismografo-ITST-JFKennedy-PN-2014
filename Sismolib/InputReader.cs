using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NationalInstruments;
using NationalInstruments.DAQmx;

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
        
        public event DataConvertedEventHandler DataConverted;

        public InputReader()
        {
            sismDB = new SismoDBC();
            analogInTasks = new Task[3];
            analogInTask = new Task();
            AIChannels= new AIChannel[3];
            for (int i = 0; i < analogInTasks.Length; i++)
            {
                analogInTasks[i] = new Task();
            }
            readingTimer = new System.Timers.Timer();
            readers = new AnalogSingleChannelReader[3];
            readingTimer.Interval = 1000;
            readingTimer.Elapsed += new System.Timers.ElapsedEventHandler(readingTimer_Tick);
            readingTimer.AutoReset = false;
        }

        /// <summary>
        /// Avvia la lettura dei dati e l'invio al database in automatico se attivato
        /// </summary>
        public void Start()
        {
            try
            {
                
                AIChannels[0] = analogInTask.AIChannels.CreateVoltageChannel(Properties.Settings.Default.ChannelNameX, "AIChannelX", AITerminalConfiguration.Pseudodifferential, Properties.Settings.Default.MinVoltage, Properties.Settings.Default.MaxVoltage, AIVoltageUnits.Volts);
                AIChannels[1] = analogInTask.AIChannels.CreateVoltageChannel(Properties.Settings.Default.ChannelNameY, "AIChannelY", AITerminalConfiguration.Pseudodifferential, Properties.Settings.Default.MinVoltage, Properties.Settings.Default.MaxVoltage, AIVoltageUnits.Volts);
                AIChannels[2] = analogInTask.AIChannels.CreateVoltageChannel(Properties.Settings.Default.ChannelNameZ, "AIChannelZ", AITerminalConfiguration.Pseudodifferential, Properties.Settings.Default.MinVoltage, Properties.Settings.Default.MaxVoltage, AIVoltageUnits.Volts);

                analogInTask.Timing.ConfigureSampleClock("", Properties.Settings.Default.Rate, SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples, 10);

                /*AIChannels[0] = analogInTasks[0].AIChannels.CreateVoltageChannel(Properties.Settings.Default.ChannelNameX, "AIChannelX", AITerminalConfiguration.Pseudodifferential, Properties.Settings.Default.MinVoltage, Properties.Settings.Default.MaxVoltage, AIVoltageUnits.Volts);
                AIChannels[1] = analogInTasks[1].AIChannels.CreateVoltageChannel(Properties.Settings.Default.ChannelNameX, "AIChannelY", AITerminalConfiguration.Pseudodifferential, Properties.Settings.Default.MinVoltage, Properties.Settings.Default.MaxVoltage, AIVoltageUnits.Volts);
                AIChannels[2] = analogInTasks[2].AIChannels.CreateVoltageChannel(Properties.Settings.Default.ChannelNameX, "AIChannelZ", AITerminalConfiguration.Pseudodifferential, Properties.Settings.Default.MinVoltage, Properties.Settings.Default.MaxVoltage, AIVoltageUnits.Volts);

                for (int i = 0; i < analogInTasks.Length; i++)
                {
                    analogInTasks[i].Timing.ConfigureSampleClock("", Properties.Settings.Default.Rate, SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples, 10);
                    readers[i] = new AnalogSingleChannelReader(analogInTasks[i].Stream);
                }*/
                
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

                    waves = reader.ReadWaveform(10000);

                    NationalInstruments.AnalogWaveform<double> wave = waves[0];
                    
                    for(int i=0;i<waves.Length;i++)
                    {
                        converters[i] = new DataConverter();
                        converters[i].data = waves[i];
                        converters[i].DBConnection = sismDB;
                        converters[i].DataConverted += new DataConvertedEventHandler(DataConverted_Event);
                        ConversionProcesses.Add(converters[i]);
                        Thread thrd = new Thread(converters[i].Elaborate);
                        ConversioneThread.Add(thrd);
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
