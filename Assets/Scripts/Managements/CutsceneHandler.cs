using UnityEngine;

namespace LunarflyArts
{
    public class CutsceneHandler : MonoBehaviour
    {
        private SceneHandler sceneHandler;
        [SerializeField] private string sceneName;

        private void Awake()
        {
            sceneHandler = SceneHandler.Instance;
        }

        public void OnEnable()
        {
            sceneHandler.LoadScene(sceneName);
        }
    }
}
