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


    }
}
