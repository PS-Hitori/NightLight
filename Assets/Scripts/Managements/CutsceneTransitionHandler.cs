using UnityEngine;

namespace LunarflyArts
{
    // This script is used to transition to a scene after a cutscene is played.
    public class CutsceneTransitionHandler : MonoBehaviour
    {
        private GameObject sceneHandler;
        [SerializeField] private string sceneName;
        private void Start()
        {
            sceneHandler = GameObject.FindGameObjectWithTag("SceneHandler");
        }

        private void OnEnable()
        {
            sceneHandler.GetComponent<SceneHandler>().LoadScene(sceneName);
        }
    }
}