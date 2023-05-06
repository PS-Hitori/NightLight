// TODO: Fix the issue where the Animator component being null despite being in the children of the TransitionHandler object and calling it in the Awake() function.

using UnityEngine;

namespace LunarflyArts
{
    public class TransitionHandler : MonoBehaviour
    {
        private Animator _animator;
        private static TransitionHandler _instance;

        private bool isTransitionEnabled;

        public bool IsTransitionEnabled
        {
            get
            {
                return isTransitionEnabled;
            }
            set
            {
                isTransitionEnabled = value;
            }
        }

        public static TransitionHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<TransitionHandler>();
                    DontDestroyOnLoad(_instance);
                }
                return _instance;
            }
        }

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            this.gameObject.GetComponentInChildren<Canvas>().enabled = false;
        }

        public bool OnTransitionEnable(bool isTransitionEnabled)
        {
            this.isTransitionEnabled = isTransitionEnabled;
            if (this.isTransitionEnabled)
            {
                this.gameObject.GetComponentInChildren<Canvas>().enabled = true;
                _animator.SetBool("IsTransitionEnabled", isTransitionEnabled);
            }
            if(!this.isTransitionEnabled)
            {
                this.gameObject.GetComponentInChildren<Canvas>().enabled = true;
            }

            Debug.Log("Transition Enabled: " + this.isTransitionEnabled);

            return this.isTransitionEnabled;
        }
    }
}