using UnityEngine;
namespace LunarflyArts
{
    public class CutsceneHandler : MonoBehaviour
    {
        private SceneHandler sceneHandler;
        [SerializeField] private string sceneName;

        public void OnEnable()
        {
            sceneHandler.LoadScene(sceneName);
        }
    }
}
