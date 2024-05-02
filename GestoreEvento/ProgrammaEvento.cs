using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEvento
{
    public class ProgrammaEvento
    {
        private string _titolo;
        public string Titolo
        {
            get
            {
                return _titolo;
            }
            set
            {
                _titolo = value;
            }
        }
        public List<Evento> Eventi { get; private set; }

        public ProgrammaEvento(string titolo)
        {
            Titolo = titolo;
            Eventi = new List<Evento>();
        }

        //aggiungerà l'evento nella lista
        public void AggiungiEvento(Evento evento)
        {
            Eventi.Add(evento);
        }

        //controlla se gli eventi sono stanziati nella stessa data
        public List<Evento> EventiInData(DateTime data)
        {
            List<Evento> eventiInData = new List<Evento>();

            foreach (Evento evento in Eventi)
            {
                if (evento.Data.Date == data.Date)
                {
                    eventiInData.Add(evento);
                }
            }

            return eventiInData;
        }


    }
}
