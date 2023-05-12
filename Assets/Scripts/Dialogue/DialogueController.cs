using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LunarflyArts
{
    public class DialogueController : MonoBehaviour
    {
        public StoryScene currentScene;
        public DialogueSystem dialogueSystem;
        private GameObject player;
        private void Start()
        {
            dialogueSystem.TriggerDialogue(currentScene);
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update(){
            if(player.GetComponent<PlayerInputManager>().GetSubmit() || player.GetComponent<PlayerInputManager>().GetClick()){
                if(dialogueSystem.IsDialogueCompleted()){
                    dialogueSystem.PlayNextDialogue();
                }
            }
        }
    }
}
