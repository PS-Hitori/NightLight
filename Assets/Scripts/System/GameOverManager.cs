using UnityEngine;
using UnityEngine.SceneManagement;

namespace LunarflyArts
{
    public class GameOverManager : MonoBehaviour
    {
        private GameObject gameManager;
        private GameObject checkPoint;
        private GameObject gameOverCanvas;
        private GameObject OnScreenUI;
        private GameObject player;
        private void Awake()
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager");
            checkPoint = GameObject.FindGameObjectWithTag("Checkpoint");
            gameOverCanvas = GameObject.FindGameObjectWithTag("Game Over");
            OnScreenUI = GameObject.FindGameObjectWithTag("UI/On Screen");
            player = GameObject.FindGameObjectWithTag("Player");
        }

        public void ResetToCheckpoint()
        {
            Debug.Log("Resetting scene");
            Time.timeScale = 1f;
            CheckpointSystem checkpointSystem = checkPoint.GetComponent<CheckpointSystem>();
            if (checkpointSystem != null)
            {
                Transform lastCheckpoint = checkpointSystem.LastCheckpoint;
                if (lastCheckpoint != null)
                {
                    GameObject player = GameObject.FindGameObjectWithTag("Player");
                    if (player != null)
                    {
                        Vector3 spawnOffset = new Vector3(2f, 0f, 0f);
                        player.transform.position = lastCheckpoint.position + spawnOffset;
                        gameOverCanvas.SetActive(false);
                        player.GetComponent<PlayerLifeSystem>().ResetLife();
                        OnScreenUI.SetActive(true);
                        Time.timeScale = 1f;
                    }
                }
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
