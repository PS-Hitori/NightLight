using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
namespace LunarflyArts
{
    public class SkipCutsceneHandler : MonoBehaviour
    {
        private SceneHandler sceneHandler;
        [SerializeField] private string sceneName;

        // bro, who tf watches cutscenes?
        public void SkipCutscene()
        {
            SceneManager.LoadScene(sceneName);

            EditorUtility.DisplayDialog("Cutscene Skipped", "Why the fuck are you watching cutscenes, bro?", "OK");
        }
    }
}