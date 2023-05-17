// This script handles all the Settings
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
namespace LunarflyArts
{
    public class SettingsManager : MonoBehaviour
    {
        [Header("Game Settings")]
        public string[] gameLanguages = new string[] { "English", "Japanese"};
        [Header("Audio Settings")]
        public float masterVolume = 1f;
        public float musicVolume = 1f;
        public float sfxVolume = 1f;
        [Header("Video Settings")]
        public Resolution[] resolutions;
        public bool fullscreen = true;
        public bool vSync = true;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Start(){
            resolutions = Screen.resolutions;

            List<string> _resolutions = new List<string>();

            for(int i = 0; i < resolutions.Length; i++)
            {
                _resolutions.Add(resolutions[i].width + "x" + resolutions[i].height);
            }
        }

        public void SetMasterVolume(float volume)
        {
            masterVolume = volume;
            Debug.Log("Master Volume: " + masterVolume);
        }

        public void SetMusicVolume(float volume)
        {
            musicVolume = volume;
            Debug.Log("Music Volume: " + musicVolume);
        }

        public void SetSFXVolume(float volume)
        {
            sfxVolume = volume;
            Debug.Log("SFX Volume: " + sfxVolume);
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

        public void SetLanguage(int languageIndex)
        {
            Debug.Log("Language: " + gameLanguages[languageIndex]);
        }
    }
}
