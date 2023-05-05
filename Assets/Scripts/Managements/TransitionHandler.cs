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
                    GameObject transitionHandlerObject = new GameObject("TransitionHandler");
                    _instance = transitionHandlerObject.AddComponent<TransitionHandler>();
                    DontDestroyOnLoad(transitionHandlerObject);
                }
                return _instance;
            }
        }

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            if (_animator == null)
            {
                Debug.LogError("Animator component not found in children!");
            }
        }
        private void Start()
        {

            this.gameObject.SetActive(false);
        }

        public bool OnTransitionEnable(bool isTransitionEnabled)
        {
            this.isTransitionEnabled = isTransitionEnabled;
            if (this.isTransitionEnabled)
            {
                this.gameObject.SetActive(true);
                _animator.SetBool("IsTransitionEnabled", isTransitionEnabled);
            }
            else
            {
                this.gameObject.SetActive(false);
            }

            Debug.Log("Transition Enabled: " + this.isTransitionEnabled);

            return this.isTransitionEnabled;
        }
    }
}