﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public enum Suits { Clubs, Spades, Hearts, Diamonds, EmptySuit }
    public enum Values { Six, Seven, Eight, Nine, King, Ten, Ace, Jack, Queen, EmptyValues }
    public enum Trumps
    {
        Six_of_Clubs, Queen_of_Clubs, Queen_of_Spades, Queen_of_Hearts, Queen_of_Diamonds, Jack_of_Clubs, Jack_of_Spades, Jack_of_Hearts, Jack_of_Diamonds, Ace_of_Diamonds,
        Ten_of_Diamonds, King_of_Diamonds, Nine_of_Diamonds, Eight_of_Diamonds, Seven_of_Diamonds, Six_of_Diamonds
    }


    public class Game
    {
        #region Поля
        Player _playerOne;
        Player _playerTwo;
        Player _playerThree;
        Player _playerFour;
        Player[] _arrayPlayers;
        List<Card> _cardDeck;
        List<Card> _cardOnTable;
        List<Card> _tricksTeam1;
        List<Card> _tricksTeam2;
        int _scoreTeam1;
        int _scoreTeam2;
        Random _random;

        #endregion

        #region Свойства

        #endregion



        public Game()
        {

        }


        #region Методы
       public void DealCard()
       {

       }
       public void CardMove()
       {

       }
       public void CheckMove()
       {

       }
       public void RoundResult()
       {

       }
       public void GetScore()
       {

       }
        #endregion



    }
}
