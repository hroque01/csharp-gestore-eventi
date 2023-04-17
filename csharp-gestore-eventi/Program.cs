using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creazione evento
            //{
            //    //Chidere all'utente di inseririe un nuovo evento
            //    Console.Write("Inserisci il nome dell'evento: ");
            //    string titolo = Console.ReadLine();

            //    //Chiedere all'utente la data dell'evento
            //    Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
            //    DateTime dateTime = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                

            //    //Chiedere all'utente di inserire il numero di posti totali
            //    Console.Write("Inserisci il numeri di posti totali: ");
            //    int capienza = int.Parse(Console.ReadLine());

            //    Evento nuovoEvento = new Evento(titolo, dateTime, capienza);

            //    //Prenotazioni
            //    //Chiedere all'utente di prenotare i posti
            //    Console.Write("Vuoi prenotare dei posti? si/no: ");
            //    string risposta = Console.ReadLine();

            //    if (risposta.ToLower() == "si")
            //    {
            //        do //Chiedi all'utente nel mentre che la rispsota e' SI
            //        {
            //            Console.Write("Quanti posti desidere prenotare? ");
            //            int numPosti = int.Parse(Console.ReadLine());

            //            try
            //            {
            //                nuovoEvento.PrenotaPosti(numPosti);
            //                Console.WriteLine("Prenotazione effettuata con successo");
            //                Console.WriteLine($"Posti prenotati: {nuovoEvento.PostiPrenotati} \t posti disponibili: {nuovoEvento.PostiDisponibili}");

            //                if (nuovoEvento.PostiDisponibili == 0) //Se non ci sono posti disponibili, concludi
            //                {
            //                    Console.WriteLine("Non ci sono più posti disponibili. Impossibile prenotare ulteriori posti.");
            //                    break;
            //                }

            //            }
            //            catch (Exception e)
            //            {
            //                Console.WriteLine(e.Message);
            //            }

            //            Console.Write("Vuoi prenotare altri posti? si/no: ");
            //            risposta = Console.ReadLine();

            //        } while (risposta.ToLower() == "si");
            //    }
                

            //    //Disdetta
            //    //Chiedere all'utente di prenotare i posti
            //    Console.Write("Vuoi disdire dei posti? si/no: ");
            //    string rispostaDisdetta = Console.ReadLine();

            //    if (rispostaDisdetta.ToLower() == "si")
            //    {
            //        do
            //        {
            //            Console.Write("Quanti posti vuoi desidere? ");
            //            int numPosti = int.Parse(Console.ReadLine());

            //            try
            //            {
            //                nuovoEvento.DisdiciPosti(numPosti);
            //                Console.WriteLine("Prenotazione effettuata con successo");
            //                Console.WriteLine($"Posti prenotati: {nuovoEvento.PostiPrenotati} \t posti disponibili: {nuovoEvento.PostiDisponibili}");
            //            }
            //            catch (Exception e)
            //            {
            //                Console.WriteLine(e.Message);
            //            }

            //            Console.Write("Vuoi disdire altri posti? si/no: ");
            //            rispostaDisdetta = Console.ReadLine();
            //        } while (rispostaDisdetta.ToLower() == "si");              
            //    }
            //}

            //Creazione Lista eventi
            {
                //Chiedo all'utente come si chiama la lista di eventi
                Console.Write("Inserisci il nome del tuo programma Eventi: ");
                string ListaTitolo = Console.ReadLine();

                //Chiedo all'utente quanti eventi vuole aggiungere
                Console.Write("Indica il numero di eventi da inserire: ");
                int numEventi;

                //Se numEventi non viene inserito un numero valido
                while (!int.TryParse(Console.ReadLine(), out numEventi))
                {
                    Console.Write("Inserisci un numero valido");
                }

                //creazione del programma
                ProgrammaEventi programma = new ProgrammaEventi(ListaTitolo);


                int eventoAggiunti = 0;
                while (eventoAggiunti < numEventi)
                {
                    Console.Write("Inserisci i dati del {0}o" , eventoAggiunti + 1);

                    Console.Write(" evento: ");
                    string titoloEvento = Console.ReadLine();

                    Console.Write("Data (dd/mm/yyyy): ");
                    DateTime dataEvento;
                    while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataEvento))
                    {
                        Console.Write("Inserisci una data valida (dd/mm/yyyy): ");
                    }

                    Console.Write("Inserisci il numero di posti totali: ");
                    int capienzaMassima;

                    while (!(int.TryParse(Console.ReadLine(), out capienzaMassima) && capienzaMassima > 0))
                    {
                        Console.Write("Inserisci un numero valido (maggiore di zero): ");
                    }

                    try
                    {
                        //Creiamo un nuovo evento con i dati inseriti dall'utente
                        Evento evento = new Evento(titoloEvento, dataEvento, capienzaMassima);

                        //Aggiungiamo l'evento alla lista degli eventi del programma
                        programma.AggiungiLista(evento);

                        Console.WriteLine("Evento aggiunto con successo.\n");
                        eventoAggiunti++;
                    }
                    catch (ArgumentNullException e)
                    {
                        Console.WriteLine($"Errore: {e.Message}\n");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"Errore: {e.Message}\n");
                    }

                    Console.WriteLine($"Il numero di eventi nel vostro programma e' {Evento.count}");


                }
            }


        }
    }
}