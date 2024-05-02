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

        //stampa l'evento
        public static void StampaEvento(List<Evento> listaEventi)
        {
            Console.WriteLine("Lista degli Eventi:");
            foreach (Evento evento in listaEventi)
            {
                Console.WriteLine($"Titolo: {evento.Titolo} \n Data: {evento.Data.ToString("dd/MM/yyyy")}\n Capienza: {evento.CapienzaEvento}\n Posti Prenotati: {evento.NumeroPostiPrenotati}");
            }
        }

        //calcola quanti eventi ci sono nella lista
        public int ContaEventi()
        {
            return Eventi.Count;
        }

        //toglierà tutti gli eventi nella lista
        public void RimuoviEvento()
        {
            Eventi.Clear();
        }

        //ritorna la stringa eventi in formato {
        public string ElencoDataTitolo()
        {
            string elencoEventi = "Nome programma evento:";

            foreach (Evento evento in Eventi)
            {
                elencoEventi += evento.ToString();
            }

            return elencoEventi;
        }
    }
}
