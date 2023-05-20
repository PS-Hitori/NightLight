using UnityEngine;

namespace LunarflyArts
{
    public class CheckpointSystem : MonoBehaviour
    {
        private Vector3 lastCheckpoint;
        private LampState lampState;
        private AudioSource audioSource;
        private GameObject player;

        private void Start()
        {
            lampState = GetComponentInChildren<LampState>();
            audioSource = GetComponent<AudioSource>();
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                lastCheckpoint = transform.position;
                lampState.LampLitState();
                audioSource.Play();
            }
        }

        public void ResetPlayerToLastCheckpoint()
        {
            player.transform.position = lastCheckpoint;
        }

        public Vector3 GetCheckpoint(){
            return lastCheckpoint;
        }
    }
}
