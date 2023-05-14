using UnityEngine;

namespace LunarflyArts
{
    public class CheckpointSystem : MonoBehaviour
    {
        public class CheckpointManager : MonoBehaviour
        {
            private Vector2 lastCheckpoint;

            private void OnTriggerEnter2D(Collider2D other)
            {
                if (other.CompareTag("Player"))
                {
                    lastCheckpoint = other.transform.position;
                    Debug.Log("Checkpoint Reached: " + lastCheckpoint);
                }
            }

            public void ResetPlayerToLastCheckpoint(GameObject player)
            {
                player.transform.position = lastCheckpoint;
            }
        }
    }
}
