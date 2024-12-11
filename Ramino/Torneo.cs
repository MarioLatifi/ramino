using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ramino
{
    /*
    Scrivere la classe Torneo in modo che:
    - alla costruzione del torneo siano creati i giocatori partecipanti e definite il numero dipartite che verranno giocate
    - possano essere inseriti i risultati ottenuti in una certa partita da un certo giocatore
    - possa essere decretato il vincitore del torneo(il giocatore con il punteggio più alto)
    */
    public class Torneo
    {
        private Giocatore[] _giocatori;

        public Torneo(int numeroGiocatori, int numeroPartite)
        {
            _giocatori = new Giocatore[numeroGiocatori];
            for (int i = 0; i < numeroGiocatori; i++)
            {
                _giocatori[i] = new Giocatore(i.ToString(), numeroPartite);
            }
        }

        public Torneo(string[] nomiGiocatori, int numeroPartite)
        {
            _giocatori = new Giocatore[nomiGiocatori.Length];
            int i = 0;
            foreach(string nome in nomiGiocatori)
            {
                _giocatori[i] = new Giocatore(nome, numeroPartite);
                i += 1;
            }
        }

        //vincitore --> il giocatore con il punteggio finale più alto (potrebbero essere più di uno!)
        public Giocatore[] getWinner()
        {
            int Max = -1;
            
            int?[] MaxPointsOfPlayers = new int?[_giocatori.Length];
            for(int i=0; i < _giocatori.Length; i++)
            {
                MaxPointsOfPlayers[i]=_giocatori[i].Punteggi[_giocatori[i].Punteggi.Length];
            }
            //ciclo per prendere il valore piú alto tra tutit i players
            for(int i = 0; i < _giocatori.Length; i++)
            {//se ancora non c'é stato un massimo punteggio e l'attuale punteggio non é nullo, il Max diventa questo 
             //oppure questo punteggio non é null e se il max esiste e se questo valore é maggiore di quello prima max é questo valore
                if (Max==-1 && MaxPointsOfPlayers[i] != null|| MaxPointsOfPlayers[i] != null&& MaxPointsOfPlayers[i] > Max && Max!=-1)
                {
                    Max = MaxPointsOfPlayers[i] ?? -1;
                }
            }
            int numOfWinners = 0;
            
            
            for (int i = 0; i < MaxPointsOfPlayers.Length; i++)
            {
                if( MaxPointsOfPlayers[i] == Max)
                {
                    numOfWinners++;
                }
            }
            Giocatore[] winners = new Giocatore[numOfWinners];
            int counter = 0; //PERCHÉ NON POSSIAMO USARE LE LISTEEEEEEEEEEEEEEEEEEEEEE?????
            for (int i = 0; i < MaxPointsOfPlayers.Length; i++)
            {
                if (MaxPointsOfPlayers[i] == Max)
                {
                    winners[counter] = _giocatori[i];
                    counter++;
                }
            }
            return winners;

        }


        
        public void punteggioGiocatoreInPartita(int posizioneGiocatore, int punteggio)
        {
            //controlli su posizione

            //richiamo alla funzione
            
        }

    }
}
