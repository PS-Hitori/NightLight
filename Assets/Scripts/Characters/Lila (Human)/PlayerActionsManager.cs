// Date Created: 03/07/2019 19:03
// Description: Handles the actions of the player and companion
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace LunarflyArts
{
    [RequireComponent(typeof(PlayerCollisionManager), typeof(CameraPOVSwitch))]
    public class PlayerActionsManager : MonoBehaviour
    {
        private float movementSpeed = 3.5f;
        private float jumpForce = 5.5f;

        new Rigidbody2D rigidbody2D;
        private DistanceJoint2D joint2D;
        private PlayerInputManager inputManager;
        private PlayerCollisionManager collisionManager;
        private PlayerAnimatorHandler animatorHandler;
        private CameraPOVSwitch cameraPOVSwitch;
        private GameObject sigil;
        private bool isJumping;

        // For grappling
        private float distanceBetweenPlayerAndSigil = 25f;
        private float dashForce = 10f; // The force applied to the player when they dash/boost
        private float dashDuration = 0.5f; // The length of time the dash/boost lasts
        private float dashCooldown = 2f; // The length of time between dashes/boosts
        private Vector3 dashDirection; // The direction the player should dash/boost in
        private LayerMask grappleLayerMask; // The layer mask used for grapple detection
        private bool isGrappleable;

        private bool isLightSigilDetected;
        private float pullSpeed = 25f; // The speed at which the player is pulled towards the grapple point

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            animatorHandler = GetComponent<PlayerAnimatorHandler>();
            inputManager = GetComponent<PlayerInputManager>();
            collisionManager = GetComponent<PlayerCollisionManager>();
            sigil = GameObject.FindGameObjectWithTag("Sigil");
        }

        private void Start()
        {
            cameraPOVSwitch = GetComponent<CameraPOVSwitch>();
            grappleLayerMask = LayerMask.GetMask("Sigil");
        }

        private void FixedUpdate()
        {
            PlayerMovement();
            PlayerJump();
            //PlayerGrapple();
        }

        private void LateUpdate()
        {
            if (inputManager.GetSwapCharacters())
            {
                cameraPOVSwitch.SwapCharacterPOV();
            }
        }
        private void PlayerMovement()
        {
            Vector2 currentVelocity = rigidbody2D.velocity;
            currentVelocity.x = inputManager.GetPlayerHorizontalMovement() * movementSpeed;
            rigidbody2D.velocity = currentVelocity;

            // Flip the player's sprite when moving to the left
            if (currentVelocity.x < 0 && transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            // Flip the player's sprite back when moving to the right
            else if (currentVelocity.x > 0 && transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

            animatorHandler.SetIdle(rigidbody2D.velocity.x == 0); // Set the animator's isIdle parameter to true if the player is not moving
            animatorHandler.SetRunning(rigidbody2D.velocity.x != 0); // Set the animator's isRunning parameter to true if the player is moving
        }

        private void PlayerGrapple()
        {
            // Check if the player is looking at a light sigil
            if (!isLightSigilDetected)
                return;
            // Get the direction from the player to the sigil
            Vector3 directionToSigil = sigil.transform.position;

            // Raycast to detect grappleable objects
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, directionToSigil, Mathf.Infinity, grappleLayerMask);
            isGrappleable = hit.collider != null && hit.collider.CompareTag("Sigil");

            Debug.DrawRay(this.transform.position, directionToSigil, Color.red);
            // Check for grapple input and start the grapple if the player is looking at a grappleable object
            if (inputManager.GetPlayerGrappleInput() && isGrappleable)
            {
                StartCoroutine(GrappleDash(hit));
            }
        }

        private IEnumerator GrappleDash(RaycastHit2D hit)
        {
            Vector3 dashDirection = hit.point;
            Vector3 startPos = transform.position;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;

            // Add force to the player to start the dash/boost
            rb.AddForce(((Vector2)hit.point - (Vector2)transform.position).normalized * dashForce, ForceMode2D.Impulse);

            // Wait until the end of the dash/boost
            float startTime = Time.time;
            while (Time.time < startTime + dashDuration)
            {
                yield return null;
            }

            // Stop the player's movement
            rb.velocity = Vector2.zero;

            // Calculate the direction from the player to the grapple point
            Vector3 pullDirection = ((Vector2)hit.point - (Vector2)transform.position).normalized;

            // Pull the player towards the grapple point until they reach it
            float pullStartTime = Time.time;
            float pullDuration = Vector3.Distance(transform.position, hit.point) / pullSpeed;
            while (Time.time < pullStartTime + pullDuration)
            {
                rb.MovePosition(transform.position + pullDirection * pullSpeed * Time.deltaTime);
                yield return null;
            }

            // Set the player's position to the exact grapple point
            transform.position = hit.point;

            // Reset gravity scale, set the movement and wait for the cooldown before enabling grapple again
            rb.gravityScale = 1f;
            movementSpeed = 3.5f;
            yield return new WaitForSeconds(dashCooldown);
            isGrappleable = true;
        }


        public void SetCanGrapple(bool canGrapple)
        {
            isGrappleable = canGrapple;
        }

        private void PlayerJump()
        {
            if (inputManager.GetPlayerJumpInput() && !isJumping)
            {
                rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                animatorHandler.SetJumping(true);
                isJumping = true;
            }

            if (rigidbody2D.velocity.y == 0)
            {
                animatorHandler.SetJumping(false);
                isJumping = false;
            }
        }


        public void SetIsJumping(bool jumping)
        {
            isJumping = jumping;
        }

        public bool IsLightSigilDetected
        {
            get { return isLightSigilDetected; }
            set { isLightSigilDetected = value; }
        }
    }
}