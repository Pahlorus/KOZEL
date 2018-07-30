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
        private int _seatNumber;
        private List<Card> _cardsOnHand;
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

        Random random = new Random();
        
        // Конструктор игрока.
        public Player(string name)
        {
            _cardsOnHand = new List<Card>();
            _typePlayer = true;
            _name = name;
            _seatNumber = 0;
        }


    }
}
