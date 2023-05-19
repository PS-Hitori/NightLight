using UnityEngine;
using Cinemachine;
namespace LunarflyArts
{
    public class OnSceneWarp : MonoBehaviour
    {
        [SerializeField] private GameObject warpLocation;
        [SerializeField] private CinemachineVirtualCamera vcam1;
        [SerializeField] private CinemachineVirtualCamera vcam2;
        private bool CMVCam1 = true;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Companion"))
            {
                other.gameObject.transform.position = warpLocation.transform.position;
                SwitchPriorityCamera();
            }
        }

        private void SwitchPriorityCamera(){
            if(CMVCam1){
                vcam1.Priority = 0;
                vcam2.Priority = 1;
            }
            else {
                vcam1.Priority = 1;
                vcam2.Priority = 0;
            }
            CMVCam1 = !CMVCam1;
        }
    }
}
