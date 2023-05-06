using UnityEngine;
using TMPro;
namespace LunarflyArts
{
    public class DebugController : MonoBehaviour
    {
        private DebugMaster debugMaster;
        [Header("Debug Settings")]
        [SerializeField] private bool setDebugModeFlag;
        
        private void Awake(){
            debugMaster = new DebugMaster();
            debugMaster.IsGameInDebugMode = setDebugModeFlag;  
        }

        private void Update(){
            if(debugMaster.IsGameInDebugMode){
                Debug.Log("Debugging mode enabled");
            }
        }
    }
}