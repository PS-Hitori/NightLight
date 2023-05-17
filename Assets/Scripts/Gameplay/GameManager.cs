// This GameManager handles all the game logic and is the main controller for the game.
using UnityEngine;

namespace LunarflyArts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private bool isLilaHadLamp = false;
        [SerializeField] private bool isLilaHadMetAria = false;

        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<GameManager>();
                }
                return _instance;
            }
        }

        public bool IsLilaHadLamp
        {
            get => isLilaHadLamp;
            set => isLilaHadLamp = value;
        }

        public bool IsLilaHadMetAria
        {
            get => isLilaHadMetAria;
            set => isLilaHadMetAria = value;
        }
    }
}
