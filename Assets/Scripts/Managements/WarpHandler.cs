using UnityEngine;

namespace LunarflyArts
{
    public class WarpHandler : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                SceneHandler.Instance.LoadScene(sceneName);
            }
        }
    }
}