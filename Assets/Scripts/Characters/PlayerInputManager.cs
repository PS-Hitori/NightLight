/// Date Created: 2023-04-27
/// Description: Handles the input of the player and companion
using UnityEngine;
using UnityEngine.InputSystem;
namespace LunarflyArts
{
    public class PlayerInputManager : MonoBehaviour
    {
        public enum InputType { Keyboard, Xbox, PS }
        public InputType currentInputType = InputType.Keyboard;
        private PlayerInputActions inputActions;
        private void Awake()
        {
            inputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            inputActions.Enable();
        }

        // Method to get the player's horizontal movement input
        public float GetPlayerHorizontalMovement()
        {
            return inputActions.Movement.HorizontalMovement.ReadValue<float>();
        }

        // Method to get the jump input()
        public bool GetPlayerJumpInput()
        {
            return inputActions.Movement.Jump.triggered;
        }

        // Method to get the companion's glow input
        public bool GetCompanionGlowInput()
        {
            return inputActions.ActionsCompanion.Glow.triggered;
        }

        // Method to get the gameplay pause input
        public bool GetGameplayPauseInput()
        {
            return inputActions.Gameplay.Pause.triggered;
        }

        // Method to get the interact input (globally used by both characters)
        public bool GetInteractInput()
        {
            return inputActions.Gameplay.Interact.triggered;
        }

    }
}