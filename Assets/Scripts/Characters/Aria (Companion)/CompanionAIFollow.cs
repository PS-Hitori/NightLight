// Date Created: 2023-04-27
// Description: Handles the AI of the companion
using UnityEngine;

namespace LunarflyArts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CompanionAIFollow : MonoBehaviour
    {
        private Transform player;
        private Vector2 offsetFromPlayer = new Vector2(1f, 0f);
        private float followSpeed = 2.5f;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void FixedUpdate()
        {
            Vector2 targetPosition;
            if (player.GetComponent<Rigidbody2D>().velocity.x < 0 && transform.localScale.x > 0) // player moving right
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                targetPosition = (Vector2)player.position - offsetFromPlayer;
            }
            else if(player.GetComponent<Rigidbody2D>().velocity.x > 0 && transform.localScale.x < 0)// player moving left
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                targetPosition = (Vector2)player.position + offsetFromPlayer;
            }
            else
            {
                targetPosition = (Vector2)player.position + offsetFromPlayer;
            }

            transform.position = Vector2.Lerp(transform.position, targetPosition, followSpeed);
        }
    }
}