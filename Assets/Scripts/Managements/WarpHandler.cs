using UnityEngine;

namespace LunarflyArts
{    public class WarpHandler : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
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