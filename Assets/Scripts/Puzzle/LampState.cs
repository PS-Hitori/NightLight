using UnityEngine;
using UnityEngine.Rendering.Universal;
namespace LunarflyArts
{
    public class LampState : MonoBehaviour
    {
        private Light2D lampLight;
        private PlayerInputManager inputManager;
        private GameObject player;
        private bool isLampLit;

        private void Awake(){
            lampLight = GetComponentInChildren<Light2D>();
            inputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputManager>();
            player = GameObject.FindGameObjectWithTag("Player");
        }

        public void LampLitState(){
            isLampLit = true;
            lampLight.enabled = true;
            Debug.Log("Lamp Lit: " + isLampLit);
        }

        public bool GetLampLitState(){
            return isLampLit;
        }

        private void OnCollisionEnter2D(Collision2D other){
            if(other.gameObject.CompareTag("Player")){
                Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
        }

        private void OnTriggerStay2D(Collider2D other){
           
        }
    }
}
