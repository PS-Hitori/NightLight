using UnityEngine;
using UnityEngine.InputSystem;
namespace LunarflyArts
{
    public class CanvasHandler : MonoBehaviour
    {
        private GameObject homeCanvas;
        private GameObject loadGameCanvas;
        private GameObject optionCanvas;
        private GameObject options_audio;
        private GameObject options_video;
        private static CanvasHandler _instance;

        private PlayerInputActions _inputActions;

        public static CanvasHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject canvasHandlerObject = new GameObject("CanvasHandler");
                    _instance = canvasHandlerObject.AddComponent<CanvasHandler>();
                    DontDestroyOnLoad(canvasHandlerObject);
                }

                return _instance;
            }
        }

        private void Awake()
        {
            homeCanvas = GameObject.FindGameObjectWithTag("Menu");
            loadGameCanvas = GameObject.FindGameObjectWithTag("Load");
            optionCanvas = GameObject.FindGameObjectWithTag("Options");
            options_audio = GameObject.FindGameObjectWithTag("Options/Audio");
            options_video = GameObject.FindGameObjectWithTag("Options/Video");
        }

        private void Start()
        {
            ShowHomeCanvas();
        }

        public void ShowHomeCanvas()
        {
            homeCanvas.SetActive(true);
            loadGameCanvas.SetActive(false);
            optionCanvas.SetActive(false);    
            options_audio.SetActive(false);
            options_video.SetActive(false);
        }

        public void ShowLoadGameCanvas()
        {
            homeCanvas.SetActive(false);
            loadGameCanvas.SetActive(true);
            optionCanvas.SetActive(false); 
            options_audio.SetActive(false);
            options_video.SetActive(false);
        }

        public void ShowOptionCanvas()
        {
            homeCanvas.SetActive(false);
            loadGameCanvas.SetActive(false);
            optionCanvas.SetActive(true);
            options_audio.SetActive(false);
            options_video.SetActive(false);
        }

        public void ShowOptionsAudio()
        {
            homeCanvas.SetActive(false);
            loadGameCanvas.SetActive(false);
            optionCanvas.SetActive(false);   
            options_audio.SetActive(true);
            options_video.SetActive(false);
        }

        public void ShowOptionsVideo()
        {
            homeCanvas.SetActive(false);
            loadGameCanvas.SetActive(false);
            optionCanvas.SetActive(false);    
            options_audio.SetActive(false);
            options_video.SetActive(true);
        }

        public void QuitGame()
        {
            UnityEngine.Application.Quit();
        }
        private void OnEnable()
        {
            if (_inputActions == null)
            {
                _inputActions = new PlayerInputActions();
                _inputActions.Menu.Enable();
                _inputActions.Menu.Cancel.performed += ctx => ReturnToHomeCanvas();
            }
        }

        private void OnDisable()
        {
            if (_inputActions != null)
            {
                _inputActions.Menu.Cancel.performed -= ctx => ReturnToHomeCanvas();
                _inputActions.Menu.Disable();
            }
        }
        private void ReturnToHomeCanvas()
        {
            ShowHomeCanvas();
        }
    }
}
