using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace LunarflyArts
{
    // This class is responsible for managing the dialogue system
    // Similar to Genshin Impact's dialogue system
    public class DialogueSystem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameDisplay;
        [SerializeField] private TextMeshProUGUI textDisplay;
        [SerializeField] private GameObject dialogueBox;
        [SerializeField] private string[] characterNames;
        [TextArea(5, 10)]
        [SerializeField] private string[] characterDialogue;
        private int index;
        private bool isDialogueSystemTriggered;
        private bool isTyping;
        [SerializeField] private float typingSpeed;

        private PlayerInputManager playerInputManager;
        private GameObject gameUI;
        private GameObject dialogueTrigger;

        private void Start()
        {
            dialogueBox.SetActive(false);
            index = 0;
            playerInputManager = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerInputManager>();
            gameUI = GameObject.FindGameObjectWithTag("UI");
            dialogueTrigger = GameObject.FindGameObjectWithTag("DialogueTrigger");
            isDialogueSystemTriggered = false;
        }

        private void Update()
        {
            if (playerInputManager.GetSubmit() || playerInputManager.GetClick())
            {
                if (!isTyping)
                {
                    AdvanceDialogue();
                }
            }
        }
        private IEnumerator TypeSentence(string sentence)
        {
            isTyping = true;
            textDisplay.text = "";
            for (int i = 0; i < sentence.Length; i++)
            {
                textDisplay.text += sentence[i];
                if (playerInputManager.GetSubmit())
                {
                    // Player has pressed submit, stop typing and display the full sentence
                    StopCoroutine("TypeSentence");
                    textDisplay.text = sentence;
                    isTyping = false;
                    yield break;
                }
                yield return new WaitForSeconds(typingSpeed);
            }
            isTyping = false;
        }

        public void SetDialogueSystemTriggered(bool isTriggered)
        {
            if (!isDialogueSystemTriggered)
            {
                isDialogueSystemTriggered = true;
                StartDialogue(characterDialogue, characterNames);
            }
        }

        private IEnumerator TypeDialogue(string dialogue)
        {
            textDisplay.text = "";
            foreach (char letter in dialogue.ToCharArray())
            {
                textDisplay.text += letter;
                yield
                return new WaitForSeconds(0.25f);
            }
        }

        private IEnumerator DisplayDialogue(string name, string sentence)
        {
            nameDisplay.text = name;
            yield
            return StartCoroutine(TypeSentence(sentence));
        }

        private void AdvanceDialogue()
        {

            if (index >= characterDialogue.Length)
            {
                EndDialogue();
                return;
            }

            StartCoroutine(DisplayDialogue(characterNames[index], characterDialogue[index]));
            index++;
        }

        public void StartDialogue(string[] newDialogue, string[] newNpcNames)
        {
            characterDialogue = newDialogue;
            characterNames = newNpcNames;
            index = 0;
            dialogueBox.SetActive(true);
            nameDisplay.text = characterNames[index];
            textDisplay.text = characterDialogue[index];
            gameUI.SetActive(false);
            Time.timeScale = 0f;
        }
        public void EndDialogue()
        {
            dialogueBox.SetActive(false);
            gameUI.SetActive(true);
            Time.timeScale = 1f;
            Destroy(dialogueTrigger);
        }
    }
}
