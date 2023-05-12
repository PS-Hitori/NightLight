using UnityEngine;
using System.Collections.Generic;
namespace LunarflyArts
{
    [CreateAssetMenu(fileName = "New Story Scene", menuName = "Dialogue System/ Create Story Scene")]
    public class StoryScene : ScriptableObject
    {
        public List<Dialogue> dialogues;
        public StoryScene nextScene;

        [System.Serializable]
        public struct Dialogue {
            public Speaker speaker;
            public string dialogue;
        }
    }
}
