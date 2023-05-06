using UnityEngine;

namespace LunarflyArts
{
    public class WarpManagement : MonoBehaviour
    {
        private SceneHandler sceneHandler;
        private GameObject player;
        [SerializeField] private string sceneName;

        private void Awake(){
            sceneHandler = SceneHandler.Instance;
        }

        private void Start(){
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void OnTriggerEnter2D(Collider2D other){
            if(other.CompareTag("Player")){
                sceneHandler.LoadScene(sceneName);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.CompareTag("Player")  ){
                // do nothing
            }
        }
    }
}
