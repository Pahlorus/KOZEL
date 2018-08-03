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
        public bool IsGame
            {
            get {return _isGame; }
           // set { _isGame = value; }
            }
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

        public void StartGame()
        {
            _isGame = true;
        }

        public void DealCardToPlayers()
        {
            SetSecuencingPlayrs();
        }

        public void PlayerSelectCard(ref Card card, Player player, Card[] arrayCardOnTable)
        {
            if (player.GetCard(ref card, _arrayCardOnTable))
            {
                player.CardsOnHand.Remove(card);
            }
        }

        public bool IsCorrectCard(ref Card card, Player player, Card[] arrayCardOnTable)
        {
            player.CardsOnHand.Add(card);
            return true;
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

        public void MoveSelecteCard(ref Card card)
        {

        }

        public void SetSecuencingPlayrs()
        {

        }

        void Update()
        {

            if (_isGame)
            {
                if (IsCardsOnHands())
                {
                    for (int i = 0; i < _arrayPlayers.Length; i++)
                    {
                        Card card = new Card();
                        PlayerSelectCard( ref card, _arrayPlayers[i], _arrayCardOnTable);
                        if (IsCorrectCard(ref card, _arrayPlayers[i], _arrayCardOnTable))
                        {
                            MoveSelecteCard(ref card);
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
                        _isGame = false;
                    }
                }
            }







        }


        #endregion
    }
}
