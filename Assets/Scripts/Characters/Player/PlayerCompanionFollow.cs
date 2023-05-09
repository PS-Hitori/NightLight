using UnityEngine;

namespace LunarflyArts
{
    public class PlayerCompanionFollow : MonoBehaviour
    {
        private Transform player;
        private Vector3 offset;

        [SerializeField] private float followSpeed = 5f;
        [SerializeField] private float flipThreshold = 0.25f;

        private void Awake(){
            player = GameObject.FindGameObjectWithTag("Player").transform;
            offset = transform.position - player.position;
            offset.y = transform.position.y - player.position.y; // adjust for the height of the companion
        }

        private void Update(){
            // Calculate the target position
            Vector3 targetPosition = player.position + offset;

            // Smoothly move towards the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

            // Flip the sprite if necessary
            float distanceToPlayer = Mathf.Abs(transform.position.x - player.position.x);
            if (distanceToPlayer > flipThreshold)
            {
                if (transform.position.x < player.position.x)
                {
                    transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                }
                else if (transform.position.x > player.position.x)
                {
                    transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
                }
            }
        }
    }
}