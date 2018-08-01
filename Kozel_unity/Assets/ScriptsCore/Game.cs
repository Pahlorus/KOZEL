using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{

    public interface IGame
    {
        void DealCard();
        void MoveCard();
        void CheckMove();
        void RoundResult();
    }



    public enum Suits { Clubs, Spades, Hearts, Diamonds, EmptySuit }
    public enum Values { Six, Seven, Eight, Nine, King, Ten, Ace, Jack, Queen, EmptyValues }
    public enum Trumps
    {
        Six_of_Clubs, Queen_of_Clubs, Queen_of_Spades, Queen_of_Hearts, Queen_of_Diamonds, Jack_of_Clubs, Jack_of_Spades, Jack_of_Hearts, Jack_of_Diamonds, Ace_of_Diamonds,
        Ten_of_Diamonds, King_of_Diamonds, Nine_of_Diamonds, Eight_of_Diamonds, Seven_of_Diamonds, Six_of_Diamonds
    }


    public class Game : MonoBehaviour, IGame
    {
        #region Поля
        private Player _playerOne;
        private Player _playerTwo;
        private Player _playerThree;
        private Player _playerFour;
        private Player[] _arrayPlayers;
        private List<Card> _cardDeck;
        private List<Card> _cardOnTable;
        private List<Card> _tricksTeam1;
        private List<Card> _tricksTeam2;
        private int _scoreTeam1;
        private int _scoreTeam2;
        private Random _random;

        #endregion

        #region Свойства

        #endregion



        public Game()
        {

        }


        #region Методы
       // Раздача карт и проверка на условия пересдачи, перерасдача.
       public void DealCard()
       {

       }
       // Ходы игроков (выбор карты и перемещение ее на стол).
       public void MoveCard()
       {

       }
       // Проверка правильности хода игрока.
       public void CheckMove()
       {

       }
       // Определение результата захода, кто взял карты, кто делает следующий ход, зачисление взятки к соответствующей команде.
       public void RoundResult()
       {

       }
       // Вычисление очков по результатам кона, определение команды выигравшей кон.
       public void GetScore()
       {

       }
        #endregion



    }
}
