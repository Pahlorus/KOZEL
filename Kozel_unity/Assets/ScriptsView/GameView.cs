using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore;

namespace GameView
{
    public class GameView : MonoBehaviour
    {
        private IGame _game;

        // Use this for initialization
        void Start()
        {
            _game = new Game();
    
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
