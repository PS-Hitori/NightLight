using UnityEngine;

namespace LunarflyArts
{
    public class SlimeAI : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        [SerializeField] private float movementSpeed = 1.5f;
        private float movementDirection = 1f;
        private float timeUntilChangeDirection;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            timeUntilChangeDirection = Random.Range(1f, 5f);
        }

        private void Update()
        {
            // Countdown to changing direction
            timeUntilChangeDirection -= Time.deltaTime;

            if (timeUntilChangeDirection <= 0)
            {
                // Change direction and reset the countdown
                movementDirection *= -1f;
                spriteRenderer.flipX = !spriteRenderer.flipX;
                timeUntilChangeDirection = Random.Range(1f, 5f);
            }

            // Move the slime in the current direction
            Vector3 direction = new Vector3(movementDirection, 0f, 0f);
            transform.Translate(direction * movementSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.CompareTag("Player"))
            {
                if (collider2D.transform.position.y > transform.position.y + 0.5f)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
