using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creazione evento
            {
                //Chidere all'utente di inseririe un nuovo evento
                Console.Write("Inserisci il nome dell'evento: ");
                string titolo = Console.ReadLine();
       
                //Chiedere all'utente la data dell'evento
                Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
                DateTime dateTime = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                //Chiedere all'utente di inserire il numero di posti totali
                Console.Write("Inserisci il numeri di posti totali: ");
                int capienza = int.Parse(Console.ReadLine());

                Evento nuovoEvento = new Evento(titolo, dateTime, capienza);

                // Chiedere all'utente di effettuare prenotazioni
                while (true)
                {
                    Console.Write("Quanti posti vuoi prenotare? (0 per uscire): ");
                    int prenotati = int.Parse(Console.ReadLine());

                    if (prenotati == 0)
                        break;

                    try
                    {
                        nuovoEvento.PrenotaPosti(prenotati);
                        Console.WriteLine("Hai prenotato {0} posti. Posti disponibili: {1}", prenotati, nuovoEvento.PostiDisponibili);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Errore: " + ex.Message);
                    }
                }

                // Chiedere all'utente di disdire posti
                while (true)
                {
                    Console.Write("Quanti posti vuoi disdire? (0 per uscire): ");
                    int disdetti = int.Parse(Console.ReadLine());

                    if (disdetti == 0)
                        break;

                    try
                    {
                        nuovoEvento.DisdiciPosti(disdetti);
                        Console.WriteLine("Hai disdetto {0} posti. Posti disponibili: {1}", disdetti, nuovoEvento.PostiDisponibili);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Errore: " + ex.Message);
                    }
                }
            }

            //Prenotazioni



        }
    }
}