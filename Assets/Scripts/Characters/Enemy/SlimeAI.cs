using UnityEngine;

namespace LunarflyArts
{
    public class SlimeAI : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        public GameObject heartPiece;
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

            timeUntilChangeDirection -= Time.deltaTime;

            if (timeUntilChangeDirection <= 0)
            {

                movementDirection *= -1f;
                spriteRenderer.flipX = !spriteRenderer.flipX;
                timeUntilChangeDirection = Random.Range(1f, 5f);
            }


            Vector3 direction = new Vector3(movementDirection, 0f, 0f);
            transform.Translate(direction * movementSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.CompareTag("Player") && collider2D.transform.position.y > transform.position.y + 0.5f)
            {
                Destroy(gameObject);

                float randomNumber = Random.value;
                Debug.Log(randomNumber);

                if (randomNumber <= 0.25f)  // 25% chance (0.25)
                {
                    Debug.Log("Heart Piece!");
                    Instantiate(heartPiece, transform.position, Quaternion.identity);
                }
            }
        }

    }
}
