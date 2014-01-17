using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalInstruments;
using NationalInstruments.DAQmx;


namespace Sismolib
{
    //Classe per un singolo dato recuperato dal sismografo
    public class SismoData : EventArgs
    {
        private double _value;          //valure acquisito
        private DateTime _time;         //data e ora a cui è stato acquisisto il valore
        private SismoDBC.SismoAxis _axis;

        //procedura per il recupero dei dati da un oggetto "NationalInstruments.AnalogWaveformSample" utilizzato dalla libreria DAQmx
        public void ExtractValue(NationalInstruments.AnalogWaveformSample<double> analoginput, SismoDBC.SismoAxis ax)
        {
            _value = analoginput.Value;
            _time = analoginput.TimeStamp;
            _axis = ax;
        }

        //get del valore acquisito
        public double value 
        { 
            get 
            { 
                return _value; 
            } 
        }

        //get della data/ora 
        public DateTime time
        {
            get 
            { 
                return _time; 
            }
        }

        //get del valore acquisito
        public SismoDBC.SismoAxis axis
        {
            get
            {
                return _axis;
            }
        }

        /*
         * non sono necessari i set delle variabili siccome l'unico modo per recuperare i dati è
         * attraverso l'oggetto "NationalInstruments.AnalogWaveformSample"
        */
    }
}
