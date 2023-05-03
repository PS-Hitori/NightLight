using UnityEngine;

namespace LunarflyArts
{
    public class ButtonState : MonoBehaviour
    {
        private Animator animator;
        private GameObject player;

        private bool isActivated;
        private void Awake()
        {
            animator = GetComponent<Animator>();
            player = GameObject.FindGameObjectWithTag("Player");
        }

        public void ToggleState()
        {
            animator.SetTrigger("isActivated");
            isActivated = true;
            Debug.Log("Button Activated: " + isActivated);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Companion"))
            {
                Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (!isActivated)
                {
                    ToggleState();
                }
                else
                {
                    Debug.Log("Button Already Activated");
                }
            }
        }
    }
}