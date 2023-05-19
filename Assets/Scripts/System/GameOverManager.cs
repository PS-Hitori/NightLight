using UnityEngine;
using UnityEngine.SceneManagement;
namespace LunarflyArts
{
    public class GameOverManager : MonoBehaviour
    {
        private GameObject gameManager;

        private void Awake()
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager");
        }

        public void ResetToCheckpoint()
        {
            Debug.Log("Resetting scene");
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void GoToMainMenu()
        {
            Debug.Log("Going to main menu");
            Time.timeScale = 1f;
            SceneManager.LoadScene("NL_Menu");
        }
    }
}
