using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

namespace LunarflyArts
{
    public class SceneHandler : MonoBehaviour
    {
        private static SceneHandler _instance;
        public static SceneHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject sceneHandlerObject = new GameObject("SceneHandler");
                    _instance = sceneHandlerObject.AddComponent<SceneHandler>();
                    DontDestroyOnLoad(sceneHandlerObject);
                }
                return _instance;
            }
        }
        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsyc(sceneName));
        }

        private static IEnumerator LoadSceneAsyc(string sceneName)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            asyncLoad.allowSceneActivation = false;
            float progress = 0f;
            while (!asyncLoad.isDone)
            {
                progress = Mathf.MoveTowards(progress, asyncLoad.progress, Time.deltaTime);
                if (progress >= asyncLoad.progress)
                {
                    if (progress >= 0.9f)
                    {
                        asyncLoad.allowSceneActivation = true;
                    }
                }
                yield return null;
            }
        }
    }
}
