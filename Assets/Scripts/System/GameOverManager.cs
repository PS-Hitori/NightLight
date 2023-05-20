using UnityEngine;
using UnityEngine.SceneManagement;

namespace LunarflyArts
{
    public class GameOverManager : MonoBehaviour
    {
        private GameObject checkpointSystem;
        private GameObject player;

        private void Awake()
        {
            checkpointSystem = GameObject.FindGameObjectWithTag("Checkpoint");
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            if (player.GetComponent<PlayerInputManager>().GetRestartInput())
            {
                ResetToCheckpoint();
            }
            if (player.GetComponent<PlayerInputManager>().GetCancel())
            {
                GoToMainMenu();
            }
        }

        public void ResetToCheckpoint()
        {
            if (checkpointSystem.GetComponent<CheckpointSystem>().GetCheckpoint() == Vector3.zero)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Debug.Log("Resetting to checkpoint");

                GameManager gameManager = FindObjectOfType<GameManager>();

                gameManager.RestoreUIAfterRestart();
                player.GetComponent<PlayerLifeSystem>().ResetLife();
                checkpointSystem.GetComponent<CheckpointSystem>().ResetPlayerToLastCheckpoint();
                Time.timeScale = 1f;
            }
        }

        public void GoToMainMenu()
        {
            Debug.Log("Going to main menu");
            Time.timeScale = 1f;
            SceneManager.LoadScene("NL_Menu");
        }
    }
}
