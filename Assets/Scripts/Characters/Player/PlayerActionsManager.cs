using UnityEngine;
namespace LunarflyArts
{
    [RequireComponent(typeof(PlayerCollisionManager))]
    public class PlayerActionsManager : MonoBehaviour
    {
        private float movementSpeed = 3.5f;
        private float jumpForce = 5.5f;

        new Rigidbody2D rigidbody2D;
        private PlayerInputManager inputManager;
        private PlayerCollisionManager collisionManager;
        private PlayerAnimatorHandler animatorHandler;
        private GameObject companion;
        private bool isJumping;

        private void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            animatorHandler = GetComponent<PlayerAnimatorHandler>();
            inputManager = GetComponent<PlayerInputManager>();
            collisionManager = GetComponent<PlayerCollisionManager>();
        }

        private void FixedUpdate()
        {
            PlayerMovement();
            PlayerJump();
        }
        private void PlayerMovement()
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

            animatorHandler.SetIdle(rigidbody2D.velocity.x == 0);
            animatorHandler.SetRunning(rigidbody2D.velocity.x != 0);
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
    }
}