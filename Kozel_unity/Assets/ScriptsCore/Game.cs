using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    /*
    public interface IGame
    {
        void DealCard();
        void MoveCard();
        void CheckMove();
        void StepResult();
    }
    */


    public enum Suits {Clubs, Spades, Hearts, Diamonds}
    public enum Values {Six, Seven, Eight, Nine, King, Ten, Ace, Jack, Queen}
    public enum State { Game, Round, Step, EndGame }
    public enum Trumps
    {
        Six_of_Clubs, Queen_of_Clubs, Queen_of_Spades, Queen_of_Hearts, Queen_of_Diamonds, Jack_of_Clubs, Jack_of_Spades, Jack_of_Hearts, Jack_of_Diamonds, Ace_of_Diamonds,
        Ten_of_Diamonds, King_of_Diamonds, Nine_of_Diamonds, Eight_of_Diamonds, Seven_of_Diamonds, Six_of_Diamonds
    }


    public class Game : MonoBehaviour//, IGame
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
        private const int _cardDeckQuantity = 36;
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
            _state = State.Game;
        }


        #region Методы

       public void DealCardToPlayers()
       {

       }
 
       public void PlayersSelectAndMoveCard()
       {

       }

       public void CheckCorrectnessMoveCard()
       {

       }

       public void GetStepScore()
       {

       }
       public void GetEndGameScore()
       {

       }


        void Update()
        {
            switch (_state)
            {
                case State.Game:
                    if (_scoreTeam1 > _scoreLimit || _scoreTeam2 >_scoreLimit)
                    {
                        GetEndGameScore();
                        _state = State.EndGame;
                    }
                    else
                    {
                        DealCardToPlayers();
                        _state = State.Round;
                    }
                    break;
                case State.Round:
                    if ((_tricksTeam1.Count + _tricksTeam2.Count)< _cardDeckQuantity) 
                    {
                        _state = State.Step;
                    }                    
                    else
                    {
                        _state = State.Game;
                    }
                    break;
                case State.Step:
                    PlayersSelectAndMoveCard();
                    CheckCorrectnessMoveCard();
                    GetStepScore();
                    _state = State.Round;
                    break;
            }
        }
        #endregion
    }
}
