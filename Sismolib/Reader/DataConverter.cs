using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sismolib
{
    public delegate void DataConvertedEventHandler(object sender, SismoData[] e);

    public class DataConverter
    {
        /// <summary>
        /// stringhe per i nomi nomi dei canali
        /// </summary>
        public static string[] SismoChannelsNamesVett = { "AIChannelX", "AIChannelY", "AIChannelZ" };

        private NationalInstruments.AnalogWaveform<double> _data;
        private SismoData[] _datasInDouble;
        public bool error = false;
        public Exception ExError;
        public SismoDBC DBConnection;

        public event DataConvertedEventHandler DataConverted;

        public NationalInstruments.AnalogWaveform<double> data
        {
            get
            { 
                return _data; 
            }
            set 
            {
                _data = value;
            }
        }

        public SismoData[] datasInDouble
        {
            get
            { 
                return _datasInDouble; 
            }
        }

        public void Elaborate()
        {
            try
            {
                _datasInDouble = new SismoData[_data.SampleCount];
                Sismolib.SismoAxis ax;

                if (_data.ChannelName == SismoChannelsNamesVett[(int)SismoAxis.X])
                {
                    ax = SismoAxis.X;
                }
                else if (_data.ChannelName == SismoChannelsNamesVett[(int)SismoAxis.Y])
                {
                    ax = SismoAxis.Y;
                }
                else if (_data.ChannelName == SismoChannelsNamesVett[(int)SismoAxis.Z])
                {
                    ax = SismoAxis.Z;
                }
                else
                { 
                    ax = SismoAxis.Undefinied; 
                }
                
                if (ax != SismoAxis.Undefinied)
                {

                    for (int i = 0; i < _data.SampleCount; i++)
                    {
                        _datasInDouble[i] = new SismoData();
                        _datasInDouble[i].ExtractValue(_data.Samples[i], ax);
                    }

                    if (DataConverted != null)
                        DataConverted(this, _datasInDouble);

                    if (DBConnection != null)
                    {
                        DBConnection.SendData(ax, _datasInDouble);
                    }
                }

            }
            catch (Exception e)
            {
                error= true;
                ExError = e;
            }
            error = false;
        }
    }
}
