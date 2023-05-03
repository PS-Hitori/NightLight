using UnityEngine;

namespace LunarflyArts
{
    public class StateFlags : MonoBehaviour
    {
        private StateFlags _instance;

        private GameObject player, companion;

        GameplayFlags gameplayFlags;
        StoryFlags storyFlags;
        SceneFlags sceneFlags;
        public StateFlags Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<StateFlags>();
                }
                return _instance;
            }
        }
        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            companion = GameObject.FindGameObjectWithTag("Companion");
        }

        private void Start()
        {
          
        }
    }
}
