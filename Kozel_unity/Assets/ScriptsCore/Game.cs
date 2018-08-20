using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    
    public interface IGame
    {
        void StartGame();

    }

    public class Awake : MonoBehaviour, IGame
    {
        #region Поля
        private Player[] _arrayPlayers;
        private Card[] _arrayCardOnTable;
        private List<Card> _cardDeck;
        private List<Card> _tricksTeam1;
        private List<Card> _tricksTeam2;
        private bool _isGame;
        private int _scoreTeam1;
        private int _scoreTeam2;
        private const int _scoreLimit = 12;
        private const int _cardDeckQuantity = 36;
        private UnityEngine.Random _random;

        #endregion

        #region Свойства
        
        #endregion
        

        private Func<Card, Card[], bool> _checkFunction =IsCorrectCard;

        private Awake()
        {
            enabled = false;
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

        public void StartGame()
        {
          enabled = true;
        }

        public void DealCardToPlayers()
        {   
            //только при первой раздаче.
            SetSecuencingPlayrs();
        }

        public static bool IsCorrectCard(Card card, Card[] arrayCardOnTable)
        {
            bool isCorrect = false;
            // Проверка.
            if (isCorrect)
            {
                return true;
            }
            else
            {
                return false;
            }
            
            
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
            SetSecuencingPlayrs();
        }

        public void GetEndGameResult()
        {

        }

        public void SetSecuencingPlayrs()
        {

        }

        void Update()
        {

                if (IsCardsOnHands())
                {
                    for (int i = 0; i < _arrayPlayers.Length; i++)
                    {
                        Card card;
                       if( _arrayPlayers[i].GetCard(out card, _arrayCardOnTable, _checkFunction))
                       {
                           _arrayCardOnTable[i] = card;
                       }
                       
                    }
                    if (IsArrayCardOnTableFull())
                    {
                        GetStepResult();
                    }
                }
                else
                {
                    if (_scoreTeam1 < _scoreLimit && _scoreTeam2 < _scoreLimit)
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
