using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LunarflyArts
{
    public class DoorWarpHandler : MonoBehaviour
    {
        private GameObject player;
        private GameObject interactButton;
        [SerializeField] private string sceneName;
        private bool isInteracting;
        private bool isInRange;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            interactButton = GameObject.FindGameObjectWithTag("Interact");
            interactButton.SetActive(false);
            isInteracting = false;
            isInRange = false;
        }

        private void Update()
        {
            if (isInRange && !isInteracting && player.GetComponent<PlayerInputManager>().GetInteractInput())
            {
                isInteracting = true;
                WarpToScene(sceneName);
            }
            else if (isInteracting && !player.GetComponent<PlayerInputManager>().GetInteractInput())
            {
                isInteracting = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isInRange = true;
                interactButton.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isInRange = false;
                interactButton.SetActive(false);
            }
        }

        private void WarpToScene(string sceneName)
        {
            SceneHandler.Instance.LoadScene(sceneName);
        }
    }
}
