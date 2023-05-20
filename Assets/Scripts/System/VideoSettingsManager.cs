using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LunarflyArts
{
    public class VideoSettingsManager : MonoBehaviour
    {
        [Header("Video Settings")]
        public Resolution[] resolutions;
        public bool fullscreen = true;
        public bool vSync = true;

        private void Start()
        {
            resolutions = Screen.resolutions;

            List<string> _resolutions = new List<string>();

            for (int i = 0; i < resolutions.Length; i++)
            {
                _resolutions.Add(resolutions[i].width + "x" + resolutions[i].height);
            }
        }
        public void SetResolution(int resolutionIndex)
        {
            resolutions = Screen.resolutions;
            Debug.Log("Resolution: " + resolutions[resolutionIndex].width + "x" + resolutions[resolutionIndex].height);
        }

        public void SetFullscreen(bool fullscreen)
        {
            Screen.fullScreen = fullscreen;
            Debug.Log("Fullscreen: " + fullscreen);
        }

        public void SetVSync(bool vSync)
        {
            this.vSync = vSync;
            Debug.Log("VSync: " + vSync);
        }
    }
}
