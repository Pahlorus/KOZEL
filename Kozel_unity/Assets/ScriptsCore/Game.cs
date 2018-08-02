using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    /*
    public interface IGame
    {
        void DealCard();
        void MoveCard();
        void CheckMove();
        void StepResult();
    }
    */


   




    public class Game : MonoBehaviour//, IGame
    {
        #region Поля
        private Player[] _arrayPlayers;
        private Card[] _arrayCardOnTable;
        private List<Card> _cardDeck;
        private List<Card> _tricksTeam1;
        private List<Card> _tricksTeam2;
        private int _scoreTeam1;
        private int _scoreTeam2;
        private const int _scoreLimit = 12;
        private const int _cardDeckQuantity = 36;
        private Random _random;

        #endregion

        #region Свойства

        #endregion



        public Game()
        {
            _arrayPlayers = new Player[4];
            _arrayPlayers[0] = new Player();
            _arrayPlayers[1] = new Player();
            _arrayPlayers[2] = new Player();
            _arrayPlayers[3] = new Player();
            _arrayCardOnTable = new Card[4];
            _cardDeck = new List<Card>();
            _tricksTeam1 = new List<Card>();
            _tricksTeam2 = new List<Card>();
            
        }


        #region Методы

       public void DealCardToPlayers()
       {

       }
 
       public void PlayersSelectAndMoveCard()
       {

       }

       public void CheckCorrectnessMoveCard()
       {

       }
       public bool IsCardsOnHands()
       {
            return true;
       }
       public bool IsArrayCardOnTableFull()
       {
           return true;
       }
        public void GetStepResult()
       {

       }
       public void GetEndGameResult()
       {

       }

        void Start()
        {
            _scoreTeam1 = 0;
            _scoreTeam2 = 0;
            DealCardToPlayers();
        }
            void Update()
        {

            if (IsCardsOnHands())
            {
                for (int i = 0; i < _arrayPlayers.Length; i++)
                {
                    if (_arrayCardOnTable[i].Name == null)
                    {
                        PlayersSelectAndMoveCard();
                        CheckCorrectnessMoveCard();
                    }
                }
                if (IsArrayCardOnTableFull())
                {
                    GetStepResult();
                }            
            }
            else
            {            
                if (_scoreTeam1< _scoreLimit && _scoreTeam1 < _scoreLimit)
                {
                    DealCardToPlayers();
                }
                else
                {
                    GetEndGameResult();
                }   
            }
            






        }
        #endregion
    }
}
