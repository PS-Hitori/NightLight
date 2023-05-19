using UnityEngine;

namespace LunarflyArts
{
    public class PuzzleTrigger : MonoBehaviour
    {
        public GameObject puzzleObject;

        public GameObject puzzleTrigger;

        private void Awake()
        {
            puzzleObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                puzzleObject.SetActive(true);
                puzzleTrigger.SetActive(false);
            }
        }
    }
}
