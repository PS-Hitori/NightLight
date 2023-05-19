using UnityEngine;

namespace LunarflyArts
{
    public class CutsceneTrigger : MonoBehaviour
    {
        public GameObject director;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                director.SetActive(true);
            }
        }
    }
}
