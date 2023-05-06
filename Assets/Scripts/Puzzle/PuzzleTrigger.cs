using UnityEngine;

namespace LunarflyArts
{
    public class PuzzleTrigger : MonoBehaviour
    {
        public string puzzleTag;
        public GameObject objectToActivate;

        private bool isActivated = false;

        private void OnTriggerEnter(Collider other)
        {
            if (!isActivated)
            {
                isActivated = true;
                ActivateObject();
            }
        }

        private void ActivateObject()
        {
            objectToActivate.SetActive(true);

            Debug.Log("Puzzle Triggered: " + puzzleTag);
        }
    }
}
