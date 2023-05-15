using UnityEngine;
namespace LunarflyArts
{
    public class PlayerInputManager : MonoBehaviour
    {
        private PlayerInputActions inputActions;
        private void Awake()
        {
            inputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            inputActions.Enable();
        }

        public float GetPlayerHorizontalMovement()
        {
            return inputActions.Movement.HorizontalMovement.ReadValue<float>();
        }

        public bool GetPlayerJumpInput()
        {
            return inputActions.Movement.Jump.triggered;
        }
        public bool GetGameplayPauseInput()
        {
            return inputActions.Gameplay.Pause.triggered;
        }

        public bool GetInteractInput()
        {
            return inputActions.Gameplay.Interact.triggered;
        }

        public bool GetSubmit()
        {
            return inputActions.Menu.Submit.triggered;
        }

        public bool GetCancel()
        {
            return inputActions.Menu.Cancel.triggered;
        }

        public bool GetClick()
        {
            return inputActions.Menu.Click.triggered;
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }
    }
}