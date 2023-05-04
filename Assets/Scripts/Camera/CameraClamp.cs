using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LunarflyArts
{
    public class CameraClamp : MonoBehaviour
    {
        private GameObject player;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void LateUpdate()
        {
            transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, -5.5f, 5.5f), Mathf.Clamp(player.transform.position.y, -3.5f, 3.5f), transform.position.z);
        }
    }
}
