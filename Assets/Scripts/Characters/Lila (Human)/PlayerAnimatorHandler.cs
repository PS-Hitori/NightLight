using UnityEngine;

namespace LunarflyArts
{
    public class PlayerAnimatorHandler : MonoBehaviour
    {
        private Animator animator;
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void SetIdle(bool isIdle){
            animator.SetBool("isIdle", isIdle);
        }

        public void SetRunning(bool isRunning){
            animator.SetBool("isRunning", isRunning);
        }

        public void SetJumping(bool isJumping){
            animator.SetBool("isJumping", isJumping);
        }

        public bool GetIdle(){
            return animator.GetBool("isIdle");
        }

        public bool GetRunning(){
            return animator.GetBool("isRunning");
        }

        public bool GetJumping(){
            return animator.GetBool("isJumping");
        }
    }
}