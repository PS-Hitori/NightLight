using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

namespace LunarflyArts
{
    public class SceneHandler : MonoBehaviour
    {
        private static SceneHandler _instance;
        private TransitionHandler _transitionHandler;

        private void Start()
        {
            _transitionHandler = TransitionHandler.Instance;
        }
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
                TransitionHandler.Instance.OnTransitionEnable(true);
                progress = Mathf.MoveTowards(progress, asyncLoad.progress, Time.deltaTime);
                if (progress >= asyncLoad.progress)
                {
                    if (progress >= 0.9f)
                    {
                        asyncLoad.allowSceneActivation = true;
                    }
                }
                Debug.Log("Loading progress: " + progress);
                yield return null;
            }
        }
    }
}
