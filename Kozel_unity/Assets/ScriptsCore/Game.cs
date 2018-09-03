using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{

    public interface ICardGame
    {
        void StartGame();
        void FinishGame();
        int[] ScoreTeam { get; }
        Player[] ArrayPlayers { get; }
        event EventHandler EndGame;

    }

    public class Game : MonoBehaviour, ICardGame
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
        //private System.Random _random;

        #endregion

        #region Properties
        public int[] ScoreTeam
        {
            get { return _scoreTeam; }
        }
        public Player[] ArrayPlayers
        {
            get { return _arrayPlayers; }
        }
        #endregion

        #region Events
        public event EventHandler EndGame;
        #endregion

        private Func<Card, Card[], bool> _checkFunction = IsCorrectCard;

        #region Metods

        private void Awake()
        {
            enabled = false;
            _arrayPlayers = new Player[4];
            _scoreTeam = new int[2];
            _tricksTeam = new List<Card>[2];
            _scoreTeam[0] = 0;
            _scoreTeam[1] = 0;
            _tricksTeam[0] = new List<Card>();
            _tricksTeam[1] = new List<Card>();
            _arrayPlayers[0] = new Player();
            _arrayPlayers[1] = new Player();
            _arrayPlayers[2] = new Player();
            _arrayPlayers[3] = new Player();
            _arrayCardOnTable = new Card[4];
            _cardDeck = new List<Card>();

        }

        public void StartGame()
        {
            enabled = true;
        }

        public void FinishGame()
        {
            enabled = false;
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
            bool isCardsOnHands = false;
            for (int i = 0; i < _arrayPlayers.Length; i++)
            {
                if (_arrayPlayers[i].CardsOnHand.Count != 0)
                {
                    isCardsOnHands = true;
                    break;
                }
            }
            return isCardsOnHands;        
        }

        public bool IsArrayCardOnTableFull()
        {
            bool isArrayCardOnTableFull = true;
            for (int i = 0; i< _arrayCardOnTable.Length; i++)
            {
                if (_arrayCardOnTable[i].Name == null)
                {
                    isArrayCardOnTableFull = false;
                    break;
                }
            }
            return isArrayCardOnTableFull;
        }

        public void GetTrickResult()
        {
            System.Random random = new System.Random();
            int randomIndex = random.Next(_scoreTeam.Length);
            for (int i = 0; i<_arrayCardOnTable.Length; i++)
            {
               _tricksTeam[randomIndex].Add(_arrayCardOnTable[i]);
            }
            // Удалить.
            Debug.Log("Взятку взяла команда" + randomIndex );
            Array.Clear(_arrayCardOnTable, 0, _arrayCardOnTable.Length);
            SetSecuencingPlayrs();
        }

        public void GetGameStepResult()
        {
            System.Random _random = new System.Random();
            int randomIndex = _random.Next(_scoreTeam.Length);
            _scoreTeam[randomIndex] = _scoreTeam[randomIndex]+2;
            _tricksTeam[0].Clear();
            _tricksTeam[1].Clear();
            // Удалить.
            Debug.Log("Раунд выиграла команда" + randomIndex);
            SetSecuencingPlayrs();
        }

        public void GetEndGameResult()
        {
            if (_scoreTeam[0] > _scoreTeam[1])
            {
                // Удалить.
                Debug.Log("Победила команда 1");
            }
            if (_scoreTeam[0] < _scoreTeam[1])
            {
                // Удалить.
                Debug.Log("Победила команда 2");
            }
            if (_scoreTeam[0] == _scoreTeam[1])
            {
                // Удалить.
                Debug.Log("Ничья");
            }
            if (EndGame != null)
            {
                EndGame(this, EventArgs.Empty);
            }
            // Удалить.
            //enabled = false;
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
                // Удалить.
                Thread.Sleep(1000);
            }
                else
                {
                    if ((_scoreTeam[0] < _scoreLimit && _scoreTeam[1] < _scoreLimit)&& (_tricksTeam[0].Count != 0 || _tricksTeam[1].Count != 0))
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
