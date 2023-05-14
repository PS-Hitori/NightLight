using UnityEngine;

namespace LunarflyArts
{
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