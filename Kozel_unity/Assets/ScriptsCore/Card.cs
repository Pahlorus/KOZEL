using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{



    public struct Card
    {
        #region Поля
        private Suits _suit;
        private Values _value;
        #endregion

        #region Свойства
        public Suits Suit
        {
            get { return _suit; }
            set { _suit = value; }
        }
        public Values Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public string Name 
        {
            get { return _value.ToString() + "_of_" + _suit.ToString(); }
        }
        #endregion

        public Card(Suits suit, Values value)
        {
            _suit = suit;
            _value = value;
        }
    }
}
