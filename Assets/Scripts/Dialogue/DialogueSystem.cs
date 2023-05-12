using System.Collections;
using UnityEngine;
using TMPro;

namespace LunarflyArts
{
    // This class is responsible for managing the dialogue system
    // Similar to Genshin Impact's dialogue system
    public class DialogueSystem : MonoBehaviour
    {
        public TextMeshProUGUI speakerNameText;
        public TextMeshProUGUI dialogueText;

        private int dialogueIndex = 0;
        private StoryScene currentScene;
        private DialogueState dialogueState = DialogueState.Finished;

        private enum DialogueState { Speaking, Finished }

        // Added: reference to the game manager to freeze time
        private GameManager gameManager;

        private void Awake()
        {
            // Added: get a reference to the game manager
            gameManager = FindObjectOfType<GameManager>();
        }

        // Added: method to trigger the dialogue and start playing the first line
        public void TriggerDialogue(StoryScene storyScene)
        {
            currentScene = storyScene;
            dialogueIndex = 0;
            speakerNameText.text = currentScene.dialogues[dialogueIndex].speaker.speakerName;
            StartCoroutine(DialogueCoroutine(currentScene.dialogues[dialogueIndex].dialogue));
        }

        // Modified: method to play the next dialogue line or close the dialog box if no more lines
        public void PlayNextDialogue()
        {
            if (dialogueIndex < currentScene.dialogues.Count - 1)
            {
                dialogueIndex++;
                speakerNameText.text = currentScene.dialogues[dialogueIndex].speaker.speakerName;
                StartCoroutine(DialogueCoroutine(currentScene.dialogues[dialogueIndex].dialogue));
            }
            else
            {
                dialogueIndex = 0;
                currentScene = null;
                speakerNameText.text = "";
                dialogueText.text = "";
                gameObject.SetActive(false); // Added: hide the dialog box
                gameManager.UnfreezeTime(); // Added: unfreeze time
            }
        }

        public bool IsDialogueCompleted()
        {
            return dialogueState == DialogueState.Finished;
        }

        public bool IsDialogueInLastSentence()
        {
            return dialogueIndex == currentScene.dialogues.Count - 1;
        }

        private IEnumerator DialogueCoroutine(string dialogue)
        {
            dialogueText.text = "";
            dialogueState = DialogueState.Speaking;
            int dialogueCharacterIndex = 0;

            // Added: freeze time while the dialog box is active
            gameManager.FreezeTime();

            while (dialogueState != DialogueState.Finished)
            {
                dialogueText.text += dialogue[dialogueCharacterIndex];
                yield return new WaitForSeconds(0.05f);
                if (++dialogueCharacterIndex == dialogue.Length)
                {
                    dialogueState = DialogueState.Finished;
                }
            }

            // Added: unfreeze time when the dialogue line is finished
            gameManager.UnfreezeTime();
        }
    }
}
