using UnityEngine;

namespace LunarflyArts
{
    public class CutsceneHandler : MonoBehaviour
    {
        private SceneHandler sceneHandler;

        private void Awake()
        {
            sceneHandler = SceneHandler.Instance;
        }

        public void OnEnable()
        {
            sceneHandler.LoadScene("NL_EXT_StarlightVillage");
        }
    }
}
