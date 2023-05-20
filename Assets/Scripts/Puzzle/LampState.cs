using UnityEngine;
using UnityEngine.Rendering.Universal;
namespace LunarflyArts
{
    public class LampState : MonoBehaviour
    {
        private Light2D lampLight;
        private bool isLampLit;

        private void Awake()
        {
            lampLight = GetComponentInChildren<Light2D>();
        }

        public void LampLitState()
        {
            if (isLampLit)
            {
                lampLight.enabled = true;
            }
            else
            {
                lampLight.enabled = false;
            }

        }

        public bool GetLampLitState(bool lampState)
        {
            return isLampLit;
        }
    }
}
