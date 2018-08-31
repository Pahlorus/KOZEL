using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore;

namespace GameViews
{
    public class GameView : MonoBehaviour
    {
        
        #region Fields
        private Game _game;
        private GameObject _cardDeck;

        [SerializeField]
        public Transform CardPref;

        #endregion

        #region Properties

        #endregion
       

        #region Metods

        void Awake ()
        {


        }

        public void StartGame()
        {
            _game = new GameObject("Game", typeof(Game)).GetComponent<Game>();
            _game.transform.SetParent(GameObject.Find("GameView").transform);
            _game.EndGame += Game_EndGame;
            UIManager.Instance.SwitchMenuOff();
            UIManager.Instance.SwitchTableOn();
            _game.StartGame();
        }

        public void StoptGame()
        {
            _game.EndGame -= Game_EndGame;
            Destroy(_game.gameObject);
            UIManager.Instance.SwitchEndGameOff();
            UIManager.Instance.SwitchMenuOn();
        }

        void PlayersCardDraw()
        {
            foreach(Card card in _game.ArrayPlayers[0].CardsOnHand)
            {

            }

        }

        void TableCardDraw()
        {

        }

        void TriksCardDraw()
        {

        }

        public void Game_EndGame(object sender, System.EventArgs e)
        {
            _game.FinishGame();
            UIManager.Instance.SwitchEndGameOn();
            UIManager.Instance.SwitchTableOff();
        }
        void Update ()
        {
		
	    }
        #endregion

    }
}
