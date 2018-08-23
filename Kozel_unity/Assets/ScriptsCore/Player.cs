using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{

    public enum Names { Ivan, Dmitry, Michail, Fedor, Anton, Sergei, Denis, Anatoly, Vladimir };

    public class Player
    {
        #region Fields
        private string _name;
        private bool _typePlayer;
        private List<Card> _cardsOnHand;
        private System.Random _random = new System.Random();
        private BotLogic _logic;
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
            _logic = new BotLogic();
        }
        #region Методы
        public bool GetCard(out Card card, Card[] arrayCardOnTable, Func<Card, Card[], bool> checkFunction)
        {
            // Пока учитывается только выбор карты ботом.
            card = _logic.BotSelectCard(_cardsOnHand, arrayCardOnTable);
            if (checkFunction(card, arrayCardOnTable))
            {
                CardsOnHand.Remove(card);
                return true;
               
            }
            else
            {
                return false;
            }
        }
        #endregion


    }
}
