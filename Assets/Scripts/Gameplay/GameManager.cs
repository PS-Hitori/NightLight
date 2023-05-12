using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LunarflyArts
{
    public class GameManager : MonoBehaviour
    {
        private GameObject player;

        private void Start(){
            player = GameObject.FindGameObjectWithTag("Player");
        }
        public void FreezeTime()
        {
            player.GetComponent<PlayerInputManager>().enabled = false;
        }

        public void UnfreezeTime()
        {
            player.GetComponent<PlayerInputManager>().enabled = true;

        }
    }
}
