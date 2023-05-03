// Date Created: 2023-24-27
// Description: Handles the input of the companion
using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;
namespace LunarflyArts
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CameraPOVSwitch))]
    public class CompanionActionManager : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 2.0f;
        [SerializeField] private float hoverSpeed = 2.5f;
        private float warningDistanceFromPlayer = 10f;
        private float maximumDistanceFromPlayer = 20f;
        private bool isCompanionLit;
        new Rigidbody2D rigidbody2D;
        private CameraPOVSwitch cameraPOVSwitch;
        private PlayerInputManager inputManager;

        private GameObject fourLeafSigil;
        private PlayerManager playerManager;
        private bool hasShownDistanceWarning = false;
        private CompanionAnimationManager animationManager;
        private CompanionCollisionManager collisionManager;
        private Light2D companionLight;
        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            animationManager = GetComponent<CompanionAnimationManager>();
            inputManager = GetComponent<PlayerInputManager>();
            companionLight = GetComponent<Light2D>();
            collisionManager = GetComponent<CompanionCollisionManager>();
        }
        private void Start()
        {
            cameraPOVSwitch = GetComponent<CameraPOVSwitch>();
            playerManager = FindObjectOfType<PlayerManager>();
            fourLeafSigil = GameObject.FindGameObjectWithTag("Sigil");
        }

        private void FixedUpdate()
        {
            CompanionHorizontalMovement();
            CompanionVerticalMovement();
            CheckForDistance();
        }

        private void LateUpdate()
        {
            if (inputManager.GetSwapCharacters())
            {
                cameraPOVSwitch.SwapCharacterPOV();
            }

            if (inputManager.GetCompanionGlowInput())
            {
                GlowCompanion();
            }

        }
        private void CompanionHorizontalMovement()
        {
            Vector2 currentVelocity = rigidbody2D.velocity;
            currentVelocity.x = inputManager.GetPlayerHorizontalMovement() * movementSpeed;
            rigidbody2D.velocity = currentVelocity;

            if (currentVelocity.x < 0 && transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

            else if (currentVelocity.x > 0 && transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            animationManager.SetIdle(currentVelocity.x == 0);
        }
        private void CompanionVerticalMovement()
        {
            Vector2 currentVelocity = rigidbody2D.velocity;
            currentVelocity.y = inputManager.GetCompanionVerticalMovement() * hoverSpeed;
            rigidbody2D.velocity = currentVelocity;
        }

        private void CheckForDistance()
        {
            float distanceToPlayer = Vector2.Distance(transform.position, playerManager.Instance.transform.position);

            if (distanceToPlayer > warningDistanceFromPlayer && !hasShownDistanceWarning)
            {
                Debug.Log("You are too far from your servant, going further away will cause you to teleport to them.");
                hasShownDistanceWarning = true;
            }
            else if (distanceToPlayer <= warningDistanceFromPlayer)
            {
                hasShownDistanceWarning = false;
            }

            if (distanceToPlayer > maximumDistanceFromPlayer)
            {
                transform.position = playerManager.Instance.transform.position;
                cameraPOVSwitch.SwapCharacterPOV();
            }
        }
        private void GlowCompanion()
        {
            bool glowCompanion = inputManager.GetCompanionGlowInput();

            if (glowCompanion)
            {
                ToggleGlow();
                isCompanionLit = true;
            }
        }

        public bool GetCompanionLitState()
        {
            return isCompanionLit;
        }
        private void ToggleGlow()
        {
            if (companionLight.enabled)
            {
                companionLight.enabled = false;
                isCompanionLit = false;
            }
            else
            {
                companionLight.enabled = true;
            }
        }
    }
}