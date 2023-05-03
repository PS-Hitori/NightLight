// This script is used to store flags that are used in the story. This is a singleton class that is attached to the GameManager object.
// Story flags are flags that are used to track the state of the story in-game, for example if a player met a certain character or if the player has completed a certain scene.
using UnityEngine;

namespace LunarflyArts
{
    public class StoryFlags : MonoBehaviour
    {
        private StoryFlags _instance;

        public StoryFlags Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<StoryFlags>();
                }
                return _instance;
            }
        }
    }
}
