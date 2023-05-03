using UnityEngine;
using Cinemachine;

namespace LunarflyArts
{
    public class CameraPOVSwitch : MonoBehaviour
    {
        private CinemachineVirtualCamera lilaPOV;
        private CinemachineVirtualCamera ariaPOV;

        private ControlSchemeManager controlSchemeManager;

        private GameObject player;
        private GameObject companion;

        private StoryFlags storyFlags;

        private bool isCameraInLilaPOV = true;

        public bool IsCameraInLilaPOV { get => isCameraInLilaPOV; set => isCameraInLilaPOV = value; }
        private void Awake()
        {
            storyFlags = StoryFlags.FindObjectOfType<StoryFlags>();
            controlSchemeManager = ControlSchemeManager.FindObjectOfType<ControlSchemeManager>();
        }

        private void Start()
        {
            GetComponents();
            SwapCharacterPOV();
        }

        private void GetComponents()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            companion = GameObject.FindGameObjectWithTag("Companion");

            lilaPOV = GameObject.FindGameObjectWithTag("PlayerVCam").GetComponent<CinemachineVirtualCamera>();
            ariaPOV = GameObject.FindGameObjectWithTag("CompanionVCam").GetComponent<CinemachineVirtualCamera>();
        }

        public void SwapCharacterPOV()
        {
            if (isCameraInLilaPOV)
            {
                lilaPOV.Priority = 1;
                ariaPOV.Priority = 0;

                player.GetComponent<PlayerActionsManager>().enabled = true;
                companion.GetComponent<CompanionActionManager>().enabled = false;
                companion.GetComponent<CompanionAIFollow>().enabled = true;

                controlSchemeManager.SetCharacterUI(CharacterUI.Lila);
            }
            else
            {
                lilaPOV.Priority = 0;
                ariaPOV.Priority = 1;

                player.GetComponent<PlayerActionsManager>().enabled = false;
                companion.GetComponent<CompanionActionManager>().enabled = true;
                companion.GetComponent<CompanionAIFollow>().enabled = false;

                controlSchemeManager.SetCharacterUI(CharacterUI.Aria);
            }
            isCameraInLilaPOV = !isCameraInLilaPOV;
        }

    }
}
