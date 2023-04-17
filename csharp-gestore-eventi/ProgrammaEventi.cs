using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class ProgrammaEventi
    {
        //Variabili
        public string Titolo { get; set; }
        public List<Evento> Eventi { get; set; }

        //Costruttore
        public ProgrammaEventi(string titolo)
        {
            Titolo = titolo;
            Eventi = new List<Evento>();
        }

        //Metodi
        //Aggiunge un evento alla lista
        public void AggiungiLista(Evento evento)
        {
            if (evento == null)
            {
                throw new ArgumentNullException(nameof(evento), "L'evento non può essere nullo.");
            }

            Eventi.Add(evento);
        }

        //Questo ci garantisce di trovare tutti gli eventi in base alla data
        public List<Evento> GetEventiPerData(DateTime data)
        {
            return Eventi.FindAll(e => e.Data.Date == data.Date);
        }

        //Questo ci garantisce di stampare gli eventi
        public static string StampaEventi(List<Evento> Eventi)
        {
            string output = "Lista eventi:\n";
            foreach ( Evento e in Eventi )
            {
                output += e.ToString();
            }
            return output;
        }

        //Questo ci garantisce di contare gli eventi in programma
        public int GetNumeroEventi()
        {
            return Eventi.Count;
        }

        //Questo ci garantisce di svuotare la lista degli eventi
        public void SvuotaListaEventi()
        {
            Eventi.Clear();
        }

        //Questo ci garantisce di vedere tutti gli eventi
        public string StampaProgrammaEventi()
        {
            string result = $"{Titolo}:\n";
            foreach (Evento evento in Eventi)
            {
                result += $"{evento.Data} - {evento.Titolo}\n";
            }
            return result;
        }





    }
}
