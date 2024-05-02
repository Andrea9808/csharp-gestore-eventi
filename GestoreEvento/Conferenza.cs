using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEvento
{
    public class Conferenza : Evento
    {
        private string _relatore;
        public string Relatore
        {
            get
            {
                return _relatore;
            }
            set
            {
                _relatore = value;
            }
        }

        private double _prezzo;
        public double Prezzo
        {
            get
            {
                return _prezzo;
            }
            set
            {
                _prezzo = value;
            }
        }

        public Conferenza(string titolo, DateTime data, int capienzaEvento, string relatore, double prezzo)
           : base(titolo, data, capienzaEvento)
        {
            Relatore = relatore;
            Prezzo = prezzo;
        }


        public string DataOraFormattata()
        {
            return $"{Data.ToString("dd/MM/yyyy")} - {Data.ToString("HH:mm")}";
        }


        public string PrezzoFormattato()
        {
            return Prezzo.ToString("0.00") + " euro";
        }

        public override string ToString()
        {
            
            return $"Nome Conferenza: Data e ora: {DataOraFormattata()} - Titolo Conferenza {Titolo} - Relatore: {Relatore} - Prezzo {PrezzoFormattato()}";
        }

    }
}
