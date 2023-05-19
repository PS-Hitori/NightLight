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
            offset.y = transform.position.y - player.position.y;
        }

        private void Update()
        {
            Vector3 targetPosition = player.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

            Vector3 playerVelocity = player.GetComponent<Rigidbody2D>().velocity;
            float playerFacingDirection = Mathf.Sign(player.localScale.x);

            if (playerVelocity.x < 0 && transform.position.x > player.position.x && playerFacingDirection > 0)
            {
                transform.localScale = new Vector3(-0.15f, 0.15f, 1f); 
            }
            else if (playerVelocity.x > 0 && transform.position.x < player.position.x && playerFacingDirection < 0)
            {
                transform.localScale = new Vector3(0.15f, 0.15f, 1f); 
            }
            else if (playerVelocity.x == 0 && playerFacingDirection < 0)
            {
                transform.localScale = new Vector3(-0.15f, 0.15f, 1f); 
            }
            else if (playerVelocity.x == 0 && playerFacingDirection > 0)
            {
                transform.localScale = new Vector3(0.15f, 0.15f, 1f); 
            } 
            if (playerVelocity.x != 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * Mathf.Sign(playerVelocity.x), transform.localScale.y, transform.localScale.z);
            }
        }


    }
}
