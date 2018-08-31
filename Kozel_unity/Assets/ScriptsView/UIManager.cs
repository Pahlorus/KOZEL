using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameViews
{
    public class UIManager : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private GameObject _menuScreen;
        [SerializeField]
        private GameObject _tableScreen;
        [SerializeField]
        private GameObject _endGameScreen;
        #endregion

        #region Properties
        public static UIManager Instance { get;  set;}


        #endregion

        #region Metods

        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
         
        }


        void Update()
        {

        }

        public  void SwitchMenuOff()
        {
            _menuScreen.SetActive(false);
        }
        public void SwitchMenuOn()
        {
            _menuScreen.SetActive(true);
        }

        public void SwitchTableOff()
        {
            _tableScreen.SetActive(false);
        }

        public void SwitchTableOn()
        {
            _tableScreen.SetActive(true);
        }



        public void SwitchEndGameOn()
        {
            _endGameScreen.SetActive(true);
        }

        public void SwitchEndGameOff()
        {
            _endGameScreen.SetActive(false);
        }



        #endregion
    }
}

