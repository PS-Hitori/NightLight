using UnityEngine;

namespace LunarflyArts
{
    public class CheckpointSystem : MonoBehaviour
    {
        private Transform lastCheckpoint;
        private LampState lampState;
        private AudioSource audioSource;

        private void Start()
        {
            lampState = gameObject.GetComponentInChildren<LampState>();
            audioSource = gameObject.GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                lastCheckpoint = this.transform;
                lampState.GetLampLitState();
                Debug.Log("Checkpoint: " + this.transform.position);
                audioSource.Play();
            }
        }

        public void ResetPlayerToLastCheckpoint(GameObject player)
        {
            player.transform.position = lastCheckpoint.position;
        }

        public Transform LastCheckpoint
        {
            get { return lastCheckpoint; }
        }
    }
}
