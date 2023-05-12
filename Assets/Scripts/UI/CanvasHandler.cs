using UnityEngine;
using UnityEngine.InputSystem;
namespace LunarflyArts
{
    public class CanvasHandler : MonoBehaviour
    {
        private GameObject homeCanvas;
        private GameObject loadGameCanvas;
        private GameObject optionCanvas;
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
        }

        public void ShowLoadGameCanvas()
        {
            homeCanvas.SetActive(false);
            loadGameCanvas.SetActive(true);
            optionCanvas.SetActive(false);
        }

        public void ShowOptionCanvas()
        {
            homeCanvas.SetActive(false);
            loadGameCanvas.SetActive(false);
            optionCanvas.SetActive(true);
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
