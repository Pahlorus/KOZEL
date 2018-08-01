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



    public enum Suits {Clubs, Spades, Hearts, Diamonds}
    public enum Values {Six, Seven, Eight, Nine, King, Ten, Ace, Jack, Queen}
    public enum State { StartGame, Game, Round, FinishGame }
    public enum Trumps
    {
        Six_of_Clubs, Queen_of_Clubs, Queen_of_Spades, Queen_of_Hearts, Queen_of_Diamonds, Jack_of_Clubs, Jack_of_Spades, Jack_of_Hearts, Jack_of_Diamonds, Ace_of_Diamonds,
        Ten_of_Diamonds, King_of_Diamonds, Nine_of_Diamonds, Eight_of_Diamonds, Seven_of_Diamonds, Six_of_Diamonds
    }


    public class Game : MonoBehaviour, IGame
    {
        #region Поля
        private Player[] _arrayPlayers;
        private List<Card> _cardDeck;
        private List<Card> _cardOnTable;
        private List<Card> _tricksTeam1;
        private List<Card> _tricksTeam2;
        private State _state;
        private int _scoreTeam1;
        private int _scoreTeam2;
        private const int _scoreLimit = 12;
        private Random _random;

        #endregion

        #region Свойства

        #endregion



        public Game()
        {
            _arrayPlayers = new Player[4];
            _arrayPlayers[0] = new Player();
            _arrayPlayers[1] = new Player();
            _arrayPlayers[2] = new Player();
            _arrayPlayers[3] = new Player();
            _state = State.StartGame;
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


        void Update()
        {
            switch (_state)
            {
                case State.StartGame:
                     DealCard();
                    _state = State.Game;
                    break;
                case State.Game:
                    if (_scoreTeam1 < _scoreLimit || _scoreTeam1 < _scoreLimit) 
                    {
                        _state = State.Round;
                    }                    
                    else
                    {
                        GetScore();
                        _state = State.FinishGame;
                    }
                    break;
                case State.Round:
                    MoveCard();
                    CheckMove();
                    RoundResult();
                    _state = State.Game;
                    break;
            }
        }
        #endregion
    }
}
