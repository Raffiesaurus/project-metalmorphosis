using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private float masterVol = 1.0f;
    private float musicVol = 1.0f;
    private float sfxVol = 1.0f;

    private static AudioManager instance = null;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Update() {

    }

    public static void SetMasterVolume(float volume) {
        instance.masterVol = volume;
    }

    public static float GetMasterVolume() {
        return instance.masterVol;
    }

    public static void SetMuicVolume(float volume) {
        instance.musicVol = volume;
    }

    public static float GetMusicVolume() {
        return instance.musicVol;
    }

    public static void SetSFXVolume(float volume) {
        instance.sfxVol = volume;
    }

    public static float GetSFXVolume() {
        return instance.sfxVol;
    }


}
