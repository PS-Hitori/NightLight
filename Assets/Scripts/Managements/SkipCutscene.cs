using UnityEngine;

namespace LunarflyArts
{
    public class SkipCutscene : MonoBehaviour
    {
        private GameObject sceneHandler;
        [SerializeField] private string sceneName;

        private void Start()
        {
            sceneHandler = GameObject.FindGameObjectWithTag("SceneHandler");
        }

        // Why the fuck do you skip cutscenes?
        public void Skip(){
            sceneHandler.GetComponent<SceneHandler>().LoadScene(sceneName);
        }
    }
}
