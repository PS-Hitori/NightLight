using UnityEngine;

namespace LunarflyArts
{
    public class CompanionAnimationManager : MonoBehaviour
    {
       private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void SetIdle(bool isIdle){
            animator.SetBool("isIdle", isIdle);
        }
    }
}
