using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class Evento
    {

        //Variabili della classe evento
        private string titolo;
        private DateTime data;
        private int capienza;
        private int posti;

        //Funzione Get&Set
        public string Titolo
        {
            get { return titolo; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Il titolo non può essere vuoto.");
                titolo = value;
            }
        }

        public DateTime Data
        {
            get { return data; }

            set
            {
                if (value < DateTime.Today)
                   throw new ArgumentOutOfRangeException("Inserisci una data che deve ancora venire.");
                data = value;
            }
        }
        
        public int CapienzaMassima
        {
            get { return capienza; }
        }

        public int PostiPrenotati
        {
            get { return posti; }
        }

        //Costruttore
        public Evento(string titolo, DateTime data, int capienza)
        {
            try
            {
                Titolo = titolo;
                Data = data;

                if (capienza < 0)
                    throw new ArgumentException("La capienza massima deve essere un numero positivo");
                this.capienza = capienza;
                posti = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }

        //Metodi
        public int PrenotaPosti (int postiDaPrenotare)
        {
            if (postiDaPrenotare <= 0)
                throw new ArgumentException("Il numero di posti deve essere un numero positivo");
            if (DateTime.Today >= Data)
                throw new InvalidOperationException("Non è possibile prenotare un evento che è già passato.");
            if (postiDaPrenotare > capienza - posti)
                throw new InvalidOperationException("NOn ci sono abbastanza posti disponibili");
            return posti += postiDaPrenotare;
        }

        public int DisdiciPosti(int disdiciPosti)
        {
            if (disdiciPosti <= 0)
                throw new ArgumentException("Il numero di posti deve essere un numero positivo");
            if (DateTime.Today >= Data)
                throw new InvalidOperationException("Non è possibile prenotare un evento che è già passato.");
            if (disdiciPosti > posti)
                throw new InvalidOperationException("Non è possibile disdire più posti di quelli prenotati.");
            return posti -= disdiciPosti;
        }
        public override string ToString()
        {
            return $"{Data.ToString("dd/MM/yyyy")} - {Titolo}";
        }


    }
}
