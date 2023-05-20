using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
namespace LunarflyArts
{
    public class AudioSettingsManager : MonoBehaviour
    {
        [Header("Audio Settings")]
        public float masterVolume = 1f;
        public float musicVolume = 1f;
        public float sfxVolume = 1f;
        public AudioMixer audioMixer;
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

    }
}
