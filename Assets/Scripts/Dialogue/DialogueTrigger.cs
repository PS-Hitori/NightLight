using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LunarflyArts
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] private DialogueSystem dialogueSystem;

        private void Start(){
            dialogueSystem = GameObject.FindGameObjectWithTag("DialogueSystem").GetComponent<DialogueSystem>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                dialogueSystem.SetDialogueSystemTriggered(true);
            }
        }
    }
}
