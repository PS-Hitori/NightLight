using UnityEngine;

namespace LunarflyArts
{
    public class WarpHandler : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        private GameObject interactButton;

        private void Start()
        {
            interactButton = GameObject.FindGameObjectWithTag("Interact");
            interactButton.SetActive(false);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                WarpToScene(sceneName);
            }
        }
        private void WarpToScene(string sceneName)
        {
            SceneHandler.Instance.LoadScene(sceneName);
        }
    }
}