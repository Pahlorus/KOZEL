using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public enum Names { Ivan, Dmitry, Michail, Fedor, Anton, Sergei, Denis, Anatoly, Vladimir };

    public class Player
    {
        #region Поля
        private string _name;
        private bool _typePlayer;
        private List<Card> _cardsOnHand;
        private System.Random _random = new System.Random();
        #endregion

        #region Свойства
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public bool TypePlayer
        {
            get { return _typePlayer; }
            set { _typePlayer = value; }
        }
        public int SeatNumber
        {
            get { return _seatNumber; }
            set { _seatNumber = value; }
        }
        public List<Card> CardsOnHand
        {
            get { return _cardsOnHand; }
            set { _cardsOnHand = value; }
        }
        #endregion



        // Конструктор игрока.
        public Player(string name)
        {
            _cardsOnHand = new List<Card>();
            _typePlayer = true;
            _name = name;
        }

        // Конструктор бота.
        public Player()
        {
            _cardsOnHand = new List<Card>();
            _typePlayer = false;
            int index = _random.Next(Enum.GetNames(typeof(Names)).Length);
            _name = Enum.GetName(typeof(Names), index);
        }
        #region Методы
        public Card GetCard()
        {
            Card card = null;
            return card;
        }
        #endregion


    }
}
