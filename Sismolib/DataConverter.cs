using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sismolib
{
    public delegate void DataConvertedEventHandler(object sender, SismoData[] e);

    public class DataConverter
    {
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
                SismoDBC.SismoAxis ax;
                
                if (_data.ChannelName == Properties.Settings.Default.ChannelNameX)
                {
                    ax = SismoDBC.SismoAxis.X;
                }
                else if (_data.ChannelName == Properties.Settings.Default.ChannelNameY)
                {
                    ax = SismoDBC.SismoAxis.Y;
                }
                else if (_data.ChannelName == Properties.Settings.Default.ChannelNameZ)
                {
                    ax = SismoDBC.SismoAxis.Y;
                }
                else
                { 
                    ax = SismoDBC.SismoAxis.Undefinied; 
                }
                
                if (ax != SismoDBC.SismoAxis.Undefinied)
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
