using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

namespace LunarflyArts
{
    public class SceneHandler : MonoBehaviour
    {
        private static SceneHandler _instance;
        private GameObject transition;

        private void Awake()
        {
            transition = GameObject.FindGameObjectWithTag("Transition");
        }

        private void Start(){
            transition.SetActive(false);
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
        private IEnumerator LoadSceneAsyc(string sceneName)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            asyncLoad.allowSceneActivation = false;
            float progress = 0f;
            while (!asyncLoad.isDone)
            {
                progress = Mathf.MoveTowards(progress, asyncLoad.progress, Time.deltaTime);
                if(progress >= asyncLoad.progress)
                {
                    transition.SetActive(true);
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