// This script is used to store flags that are used in gameplay. This is a singleton class that is attached to the GameManager object.
// Gameplay flags are flags that are used to track the gameplay state of the game. For example, if the player triggered a certain event, or if the player has completed a puzzle.
using UnityEngine;

namespace LunarflyArts
{
    public class GameplayFlags : MonoBehaviour
    {
        private GameplayFlags _instance;

        public GameplayFlags Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<GameplayFlags>();
                }
                return _instance;
            }
        }

        public bool IsBossFightTriggered
        {
            get
            {
                return isBossFightTriggered;
            }
            set
            {
                isBossFightTriggered = value;
            }
        }
        private bool isBossFightTriggered;
    }
}
