﻿namespace Ramino
{
    /*
     * Scrivere la classe Giocatore in modo che sia possibile:
- memorizzare il punteggio ottenuto in una certa partita (ricorda che i punteggi si sommano e che non è possibile inserire il punteggio della partita x se la partita x-1 non è stata già inserita)
- verificare in quale partita è stato raggiungo esattamente un certo punteggio (restituire null se quel punteggio esatto non è stato mai ottenuto) --> utilizzare la ricerca binaria (dovete implementare voi la ricerca binaria e non utilizzare quella già presente nelle librerie)



Scrivere un main che:
- istanzia un Torneo 
- simula le partite
- individua il vincitore
- verifica in quale partita i giocatore del torneo hanno ottenuto esattamente P punti (con P richiesto in input o generato in modo random)
     */
    public class Giocatore
    {
        public string Nome {  get; set; }
        public int?[] Punteggi { get; private set; }
        

        public int NumeroPartite
        { 
            get
            {
                return Punteggi.Length;
            } 
        }

        public Giocatore(string nome, int partite)
        {
            Nome = nome;
            Punteggi = new int?[partite];
        }

        public void MemorizzaPunteggioPartita(int punteggio, int partita)
        {
            //verifico che il punteggio sia accettabile
            if (punteggio < 0 || punteggio > 100) throw new ArgumentOutOfRangeException("punteggio errato");
            //verifico che la partita sia accettabile
            if(partita < 1 || partita >= NumeroPartite) throw new ArgumentOutOfRangeException("numero partita errato");
            //verifico che la partita precedente sia stata memorizzata
            if (partita > 1 && Punteggi[partita - 2] == null) throw new ArgumentException($"non è possibile salvare il punteggio per la partita {partita} perchè non è ancora stato definito il punteggio della partita {partita-1}");
            //salvo il punteggio
            if(partita==1)
                Punteggi[partita-1] = punteggio;
            else
                Punteggi[partita - 1] = Punteggi[partita - 2]+punteggio;
        }


        /// <summary>
        /// ricerca binaria con la restituzione della partita in cui si è raggiunto il punteggio richiesto
        /// 
        /// </summary>
        /// <param name="punteggioDaCercare"></param>
        /// <returns>il numero della partita in cui si è raggiunto esattamente quel punteggio (attenzione che l'indice e la partita sono sfasati di 1)</returns>
        public int? RicercaPartitaPerPunteggio(int punteggioDaCercare)
        {
            int inizio = 0;
            int fine = Punteggi.Length - 1;
            int meta = (inizio + fine) / 2;
            do
            {
                if (Punteggi[meta] == punteggioDaCercare)
                {
                    return (meta);
                }
                if (Punteggi[meta] < punteggioDaCercare)
                {
                    inizio = meta + 1;
                    meta = (inizio + fine) / 2;
                }
                else
                {
                    fine = meta - 1;
                }
                if (fine == inizio && punteggioDaCercare == Punteggi[inizio]) { return inizio; }
            } while (fine - inizio == 1);
            return null;
        }
    }
}
