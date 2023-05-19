using UnityEngine;

namespace LunarflyArts
{
    public class CheckpointSystem : MonoBehaviour
    {
        private Vector2 lastCheckpoint;
        private LampState lampState;

        private void Start()
        {
            lampState = gameObject.GetComponentInChildren<LampState>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                lastCheckpoint = other.transform.position;
                lampState.GetLampLitState();
                Debug.Log("Checkpoint: " + this.transform.position);
            }
        }

        public void ResetPlayerToLastCheckpoint(GameObject player)
        {
            player.transform.position = lastCheckpoint;
        }
    }
}
