using UnityEngine;

namespace LunarflyArts
{
    public class PlayerCompanionFollow : MonoBehaviour
    {
        private Transform player;
        private Vector3 offset;

        [SerializeField] private float followSpeed = 5f;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            offset = transform.position - player.position;
            offset.y = transform.position.y - player.position.y; // adjust for the height of the companion
        }

        private void Update()
        {
            Vector3 targetPosition = player.position + offset;

            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

            // Get the player's velocity and facing direction
            Vector3 playerVelocity = player.GetComponent<Rigidbody2D>().velocity;
            float playerFacingDirection = Mathf.Sign(player.localScale.x);

            // Flip the companion if the player is moving left and the companion is to the right of the player
            if (playerVelocity.x < 0 && transform.position.x > player.position.x && playerFacingDirection > 0)
            {
                transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
            }
            // Flip the companion if the player is moving right and the companion is to the left of the player
            else if (playerVelocity.x > 0 && transform.position.x < player.position.x && playerFacingDirection < 0)
            {
                transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
    }
}
