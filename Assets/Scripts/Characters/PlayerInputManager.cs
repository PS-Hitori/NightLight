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

        public bool GetCompanionGlowInput()
        {
            return inputActions.ActionsCompanion.Glow.triggered;
        }

        public bool GetGameplayPauseInput()
        {
            return inputActions.Gameplay.Pause.triggered;
        }

        public bool GetInteractInput()
        {
            return inputActions.Gameplay.Interact.triggered;
        }

        private void OnDisable(){
            inputActions.Disable();
        }
    }
}