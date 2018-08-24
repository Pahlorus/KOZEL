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

    public class Game : MonoBehaviour, IGame
    {
        #region Fields
        private Player[] _arrayPlayers;
        private Card[] _arrayCardOnTable;
        private List<Card> _cardDeck;
        private List<Card>[] _tricksTeam;
        private int[] _scoreTeam;
        private const int _scoreLimit = 12;
        private const int _cardDeckQuantity = 36;
        public const int _quantityCardForPlayer = 9;
        private System.Random _random;

        #endregion

        #region Properties

        #endregion


        private Func<Card, Card[], bool> _checkFunction = IsCorrectCard;




        #region Metods

        private void Awake()
        {
            enabled = true;
            _arrayPlayers = new Player[4];
            _scoreTeam = new int[2];
            _tricksTeam = new List<Card>[2];
            _arrayPlayers[0] = new Player();
            _arrayPlayers[1] = new Player();
            _arrayPlayers[2] = new Player();
            _arrayPlayers[3] = new Player();
            _arrayCardOnTable = new Card[4];
            _cardDeck = new List<Card>();
            FillingCardDeck();
        }

        public void StartGame()
        {
            enabled = true;
        }
        public void FillingCardDeck()
        {
            // Наполнение колоды карт.
            for (int i = 0; i < Enum.GetNames(typeof(Suits)).Length; i++)
            {
                for (int j = 0; j < Enum.GetNames(typeof(Values)).Length; j++)
                {
                    _cardDeck.Add(new Card((Suits)i, (Values)j));
                }
            }

            // Перемешивание карт.
            /* List<Card> _newCardDeck = new List<Card>();
             while (_cardDeck.Count > 0)
             {
                 int CardToMove = _random.Next(_cardDeck.Count);
                 _newCardDeck.Add(_cardDeck[CardToMove]);
                 _cardDeck.RemoveAt(CardToMove);
             }
             _cardDeck = _newCardDeck;*/
        }

        public void DealCardToPlayers()
        {   
            for(int i = 0; i < _arrayPlayers.Length; i++)
            {
                for (int j = 0; j < _quantityCardForPlayer; j++)
                {

                    _arrayPlayers[i].CardsOnHand.Add(_cardDeck[0]);
                    _cardDeck.RemoveAt(0);
                }
            }

            // Только при первой раздаче, далее должны быть хваления.
            SetSecuencingPlayrs();
        }

        public static bool IsCorrectCard(Card card, Card[] arrayCardOnTable)
        {      
            return true;
        }

        public bool IsCardsOnHands()
        {
            if (_arrayPlayers[0].CardsOnHand.Count!=0 || _arrayPlayers[1].CardsOnHand.Count != 0 || _arrayPlayers[2].CardsOnHand.Count != 0 | _arrayPlayers[3].CardsOnHand.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool IsArrayCardOnTableFull()
        {
           return true;
        }

        public void GetTrickResult()
        {
            System.Random random = new System.Random();
            int randomIndex = random.Next(_scoreTeam.Length);
            for (int i = 0; i<_arrayCardOnTable.Length; i++)
            {
                _tricksTeam[randomIndex].Add(_arrayCardOnTable[i]);
            }
            Array.Clear(_arrayCardOnTable, 0, _arrayCardOnTable.Length);
            SetSecuencingPlayrs();
        }
        public void ReturnCardToCardDeck()
        {

        }

        public void GetGameStepResult()
        {
            int randomIndex = _random.Next(_scoreTeam.Length);
            _scoreTeam[randomIndex] = _scoreTeam[randomIndex]+1;
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
                        GetTrickResult();
                    }
                }
                else
                {
                    if (_cardDeck.Count == 0)
                    {
                        GetGameStepResult();
                    }
                    if (_scoreTeam[0] < _scoreLimit && _scoreTeam[1] < _scoreLimit)
                    {
                        FillingCardDeck();
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
