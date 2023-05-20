// This GameManager handles all the game logic and is the main controller for the game.
using UnityEngine;
using TMPro;
namespace LunarflyArts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject OnScreenUI;
        [SerializeField] private GameObject PauseUI;
        [SerializeField] private GameObject mainUI;
        [SerializeField] private GameObject GameOverCanvas;
        private SceneHandler sceneHandler;
        private bool isPaused = false;
        private GameObject lampCheckpoint;
        private GameObject player;

        private GameManager instance;

        public GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = this;
                }
                return instance;
            }
        }
        private void Awake()
        {
            GameOverCanvas = GameObject.FindGameObjectWithTag("Game Over");
            mainUI = GameObject.FindGameObjectWithTag("UI/On Screen");
            OnScreenUI = GameObject.FindGameObjectWithTag("UI/On Screen");
            PauseUI = GameObject.FindGameObjectWithTag("UI/Pause");
            player = GameObject.FindGameObjectWithTag("Player");
            sceneHandler = FindObjectOfType<SceneHandler>();
            lampCheckpoint = GameObject.FindGameObjectWithTag("Checkpoint");
        }

        private void Start()
        {
            GameOverCanvas.SetActive(false);
            OnScreenUI.SetActive(true);
            PauseUI.SetActive(false);
            mainUI.SetActive(true);
        }

        private void Update()
        {
            if (player.GetComponent<PlayerLifeSystem>().IsPlayerDead() == true)
            {
                ShowGameOverUI();
            }
            PauseScreen();
        }

        private void PauseScreen()
        {
            bool pauseInput = player.GetComponent<PlayerInputManager>().GetGameplayPauseInput();

            if (pauseInput && !isPaused)
            {
                isPaused = true;
                PauseUI.SetActive(true);
                Time.timeScale = 0f; // Pause the game by setting time scale to 0
            }
            else if (pauseInput && isPaused)
            {
                isPaused = false;
                PauseUI.SetActive(false);
                Time.timeScale = 1f; // Unpause the game by setting time scale to 1
            }
        }

        public void RestoreUIAfterRestart()
        {
            OnScreenUI.SetActive(true);
            PauseUI.SetActive(false);
            mainUI.SetActive(true);
            GameOverCanvas.SetActive(false);
        }

        public void ShowGameOverUI()
        {
            GameOverCanvas.SetActive(true);
            PauseUI.SetActive(false);
            OnScreenUI.SetActive(false);
            mainUI.SetActive(false);
        }
    }
}
