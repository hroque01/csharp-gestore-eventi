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

                //Prenotazioni
                //Chiedere all'utente di prenotare i posti
                Console.Write("Vuoi prenotare dei posti? si/no: ");
                string risposta = Console.ReadLine();

                do //Chiedi all'utente nel mentre che la rispsota e' SI
                {
                    Console.Write("Quanti posti desidere prenotare? ");
                    int numPosti = int.Parse(Console.ReadLine());

                    try
                    {
                        nuovoEvento.PrenotaPosti(numPosti);
                        Console.WriteLine("Prenotazione effettuata con successo");
                        Console.WriteLine($"Posti prenotati: {nuovoEvento.PostiPrenotati} \t posti disponibili: {nuovoEvento.PostiDisponibili}");

                        if (nuovoEvento.PostiDisponibili == 0) //Se non ci sono posti disponibili, concludi
                        {
                            Console.WriteLine("Non ci sono più posti disponibili. Impossibile prenotare ulteriori posti.");
                            break;
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    Console.Write("Vuoi prenotare altri posti? si/no: ");
                    risposta = Console.ReadLine();

                } while (risposta.ToLower() == "si");

                //Disdetta
                //Chiedere all'utente di prenotare i posti
                Console.Write("Vuoi disdire dei posti? si/no: ");
                string rispostaDisdetta = Console.ReadLine();

                do //Chiedi all'utente nel mentre che la rispsota e' SI
                {
                    Console.Write("Quanti posti vuoi desidere? ");
                    int numPosti = int.Parse(Console.ReadLine());

                    try
                    {
                        nuovoEvento.DisdiciPosti(numPosti);
                        Console.WriteLine("Prenotazione effettuata con successo");
                        Console.WriteLine($"Posti prenotati: {nuovoEvento.PostiPrenotati} \t posti disponibili: {nuovoEvento.PostiDisponibili}"); 
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    Console.Write("Vuoi disdire altri posti? si/no: ");
                    rispostaDisdetta = Console.ReadLine();

                } while (rispostaDisdetta.ToLower() == "si");

            }

        }
    }
}