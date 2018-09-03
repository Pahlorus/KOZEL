using System;
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
        private Dictionary<string, Transform> _cardDeck;

        #endregion

        #region Fields Initialized in Unity
        [SerializeField]
        private GameObject _table;
        [SerializeField]
        private GameObject _deck;
        [SerializeField]
        private GameObject _hand_0;
        [SerializeField]
        private GameObject _hand_1;
        [SerializeField]
        private GameObject _hand_2;
        [SerializeField]
        private GameObject _hand_3;
        [SerializeField]
        private GameObject _slotOnTable_0;
        [SerializeField]
        private GameObject _slotOnTable_1;
        [SerializeField]
        private GameObject _slotOnTable_2;
        [SerializeField]
        private GameObject _slotOnTable_3;
        [SerializeField]
        private Transform _cardPref;

        #endregion

        #region Properties

        #endregion


        #region Metods

        void Awake ()
        {
            _cardDeck = new Dictionary<string, Transform>();
            CreateCardView();
            enabled = false;

        }

        public void StartGame()
        {
            _game = new GameObject("Game", typeof(Game)).GetComponent<Game>();
            _game.transform.SetParent(this.transform);
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
            // Удалить.
            enabled =true;
        }
        public void CreateCardView()
        {
            for (int i = 0; i < Enum.GetNames(typeof(Suits)).Length; i++)
            {
                for (int j = 0; j < Enum.GetNames(typeof(Values)).Length; j++)
                {
                    Transform card = Instantiate(_cardPref, _deck.transform);
                    card.name = ((Suits)i).ToString() + "_of_" + ((Values)j).ToString();
                    card.transform.localScale = new Vector3(0.6f, 0.6f, 1.0f);
                    _cardDeck.Add(((Suits)i).ToString() + "_of_" + ((Values)j).ToString(), card);

                }
            }
        }


        void PlayersCardDraw()
        {
            foreach(Card card in _game.ArrayPlayers[0].CardsOnHand)
            {
                _cardDeck[card.Name].SetParent(_hand_0.transform);
            }
            foreach (Card card in _game.ArrayPlayers[1].CardsOnHand)
            {
                _cardDeck[card.Name].SetParent(_hand_1.transform);
            }
            foreach (Card card in _game.ArrayPlayers[2].CardsOnHand)
            {
                _cardDeck[card.Name].SetParent(_hand_2.transform);
            }
            foreach (Card card in _game.ArrayPlayers[3].CardsOnHand)
            {
                _cardDeck[card.Name].SetParent(_hand_3.transform);
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
            PlayersCardDraw();

        }

        #endregion

    }
}
