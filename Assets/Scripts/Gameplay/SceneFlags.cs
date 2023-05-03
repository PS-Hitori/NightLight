// This script is used to store flags that are used in scenes. This is a singleton class that is attached to the GameManager object.
// Scene flags are flags that are used to track the area that the player is in like if the player is in the forest, or if the player is in the village.
using UnityEngine;

namespace LunarflyArts
{
    public class SceneFlags : MonoBehaviour
    {
        private SceneFlags _instance;
        public SceneFlags Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<SceneFlags>();
                }
                return _instance;
            }
        }
    }
}
