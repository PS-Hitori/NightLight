using UnityEngine;

namespace LunarflyArts
{
    public class WarpManagement : MonoBehaviour
    {
        private SceneHandler sceneHandler;
        [SerializeField] private string sceneName;

        private void Awake(){
            sceneHandler = SceneHandler.Instance;
        }

        private void OnTriggerEnter2D(Collider2D other){
            if(other.CompareTag("Player")){
                sceneHandler.LoadScene(sceneName);
            }
        }
    }
}
