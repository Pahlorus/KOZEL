using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore;

namespace GameViews
{
    public class CardView : MonoBehaviour
    {

        #region Fields
        private Sprite _faceTexture;
        private Sprite _backTexture;
        private Rect _cardRect;

        [SerializeField]
        private string _name;
        [SerializeField]
        private GameObject _parent;
        #endregion

        #region Properties
        
        #endregion

        /*public CardView(string Name)
        {
            _name = Name;
            _backTexture = Resources.Load<Sprite>("Back_card");
            _faceTexture = Resources.Load<Sprite>(Name);
        }*/
        // Use this for initialization

        public void SetFaceTexture()
        {
            this.GetComponent<SpriteRenderer>().sprite = _faceTexture;
        }

        public void SetBackTexture()
        {
            this.GetComponent<SpriteRenderer>().sprite = _backTexture;
        }

        void Start()
        {


        }

        // Update is called once per frame
        void Update()
        {
         
        }

    }
}
