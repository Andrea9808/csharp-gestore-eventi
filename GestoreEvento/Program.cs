namespace GestoreEvento
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //EVENTO
            try
            {
                Console.WriteLine("Inserisci i dettagli del nuovo evento:");

                //titolo
                Console.Write("Inserisci il nome dell'evento: ");
                string titolo = Console.ReadLine();

                //data
                Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
                DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                //capienza
                Console.Write("Inserisci il numero di posti totali: ");
                int capienzaEvento = int.Parse(Console.ReadLine());

                Evento nuovoEvento = new Evento(titolo, data, capienzaEvento);

                Console.WriteLine();
                Console.Write("Vuoi effettuare delle prenotazioni? (si/no): ");
                string risposta = Console.ReadLine();

                Console.WriteLine();

                if (risposta == "si")
                {
                    //posti prenotati
                    Console.WriteLine("Quanti posti desideri prenotare? ");
                    int numeroPostiCheSiVoglionoPrenotare = int.Parse(Console.ReadLine());

                    // effettua le prenotazioni utilizzando il metodo PrenotaPosti
                    int postiPrenotati = nuovoEvento.PrenotaPosti(numeroPostiCheSiVoglionoPrenotare);

                    Console.WriteLine();
                    Console.WriteLine($"Numero di posti prenotati: {postiPrenotati}");
                    Console.WriteLine($"Numero di posti disponibili: {nuovoEvento.CapienzaEvento - postiPrenotati}");
                }

                Console.WriteLine();

                while (risposta == "si")
                {
                    Console.WriteLine("Vuoi disdire dei posti? (si/no): ");
                    risposta = Console.ReadLine();

                    if (risposta == "si")
                    {
                        Console.WriteLine($"Ok, va bene!");
                        //posti da disdire
                        Console.WriteLine($"Indica il numero dei posti che vuoi disdire: ");
                        int numeroPostiCheSiVoglionoDisdire = int.Parse(Console.ReadLine());

                        // effettua le disdette utilizzando il metodo DisdisciPosti
                        int postiCancellati = nuovoEvento.DisdisciPosti(numeroPostiCheSiVoglionoDisdire);

                        Console.WriteLine();
                        Console.WriteLine($"Numero di posti prenotati: {nuovoEvento.NumeroPostiPrenotati}");
                        Console.WriteLine($"Numero di posti disponibili: {nuovoEvento.CapienzaEvento - nuovoEvento.NumeroPostiPrenotati}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Si è verificato un errore: {e.Message}");
            }







            //PROGRAMMA EVENTO
            try
            {
                Console.WriteLine($"Inserisci il nome del tuo programma evento:");
                string titoloProgramma = Console.ReadLine();

                Console.WriteLine($"Quanti eventi vuoi aggiungere:");
                int quantitàEventi = int.Parse(Console.ReadLine());

                if (quantitàEventi < 0)
                {
                    throw new Exception("Non puoi inserire valori negativi");
                }

                ProgrammaEvento programmaEventi = new ProgrammaEvento(titoloProgramma);

                for (int i = 0; i < quantitàEventi; i++)
                {
                    try
                    {
                        Console.WriteLine();
                        Console.Write($"Inserisci il nome del {i + 1}' evento: ");
                        string evento = Console.ReadLine();

                        //se il campo è vuoto
                        if (String.IsNullOrEmpty(evento))
                        {
                            throw new Exception("Il campo non può essere vuoto");
                        }

                        Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
                        DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                        //se la data è al passato
                        if (data < DateTime.Now)
                        {
                            throw new Exception("La data non può essere minore di oggi");
                        }

                        Console.Write("Inserisci il numero di posti totali: ");
                        int capienzaEvento = int.Parse(Console.ReadLine());

                        //se la capienza è negativa
                        if (capienzaEvento <= 0)
                        {
                            throw new Exception("La capienza deve essere positiva");
                        }

                        programmaEventi.AggiungiEvento(new Evento(evento, data, capienzaEvento));
                        
                    }
                    
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Si è verificato un errore: {ex.Message}. Riprova!");
                        i--;
                    }
                }

                //STAMPA ELEMENTI(StampaEvento())
                Console.WriteLine();
                ProgrammaEvento.StampaEvento(programmaEventi.Eventi);

                //STAMPA ELEMENTI(ContaEventi())
                Console.WriteLine();
                Console.WriteLine($"Il numero di eventi nel programma è  {programmaEventi.ContaEventi()}");


                //STAMPA GLI ELEMENTI CHE HANNO LA STESSA DATA (EventiInData())
                Console.Write("Inserisci una data (gg/mm/yyyy): ");
                DateTime dataInserita = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                List<Evento> eventiInData = programmaEventi.EventiInData(dataInserita);
                string elencoEventiInData = programmaEventi.ElencoDataTitolo(eventiInData);
                Console.WriteLine(elencoEventiInData);

            }

            catch (Exception e)
            {
                Console.WriteLine($"Si è verificato un errore: {e.Message}");
            }


        }
    }
}