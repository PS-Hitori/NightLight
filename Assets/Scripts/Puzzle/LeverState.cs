using UnityEngine;
namespace LunarflyArts
{
    public class LeverState : MonoBehaviour
    {
        public GameObject targetObject;
        public bool showObjectOnActivation;
        private Animator animator;
        private PlayerInputManager inputManager;
        private bool isActivated;

        private void Awake()
        {
            inputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputManager>();
            animator = GetComponent<Animator>();
        }

        public void ToggleState()
        {
            animator.SetTrigger("isActivated");
            isActivated = true;
            Debug.Log("Lever Activated: " + isActivated);
            showObjectOnActivation = true;

            if (targetObject != null)
            {
                if(showObjectOnActivation){
                    Destroy(targetObject);
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Companion"))
            {
                Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (inputManager.GetInteractInput() && other.gameObject.CompareTag("Player"))
            {
                if (!isActivated)
                {
                    ToggleState();
                }
                else
                {
                    Debug.Log("Lever Already Activated");
                }
            }
        }
    }
}
