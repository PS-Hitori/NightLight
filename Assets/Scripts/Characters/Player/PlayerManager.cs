using UnityEngine;

namespace LunarflyArts
{
    [RequireComponent(typeof(PlayerInputManager))]

    public class PlayerManager : MonoBehaviour
    {
        private PlayerManager _instance;
        public PlayerManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<PlayerManager>();
                }
                return _instance;
            }
        }
    }
}