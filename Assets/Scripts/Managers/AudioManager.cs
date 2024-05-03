using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private float masterVol = 1.0f;
    private float musicVol = 1.0f;
    private float sfxVol = 1.0f;

    private static AudioManager instance = null;

    [SerializeField] private AudioSource bgmSource = null;
    [SerializeField] private AudioSource sfxSource = null;
    [SerializeField] private AudioSource walkSource = null;

    [SerializeField] private AudioClip[] audioClips;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
        bgmSource.volume = musicVol * masterVol;
        sfxSource.volume = sfxVol * masterVol;
        walkSource.volume = sfxVol * masterVol;
    }

    void Update() {

    }

    public static void SetMasterVolume(float volume) {
        instance.masterVol = volume;
        instance.bgmSource.volume = instance.musicVol * instance.masterVol;
        instance.sfxSource.volume = instance.sfxVol * instance.masterVol;
        instance.walkSource.volume = instance.sfxVol * instance.masterVol;
    }

    public static float GetMasterVolume() {
        return instance.masterVol;
    }

    public static void SetMuicVolume(float volume) {
        instance.musicVol = volume;
        instance.bgmSource.volume = instance.musicVol * instance.masterVol;
        instance.sfxSource.volume = instance.sfxVol * instance.masterVol;
        instance.walkSource.volume = instance.sfxVol * instance.masterVol;
    }

    public static float GetMusicVolume() {
        return instance.musicVol;
    }

    public static void SetSFXVolume(float volume) {
        instance.sfxVol = volume;
        instance.bgmSource.volume = instance.musicVol * instance.masterVol;
        instance.sfxSource.volume = instance.sfxVol * instance.masterVol;
        instance.walkSource.volume = instance.sfxVol * instance.masterVol;
    }

    public static float GetSFXVolume() {
        return instance.sfxVol;
    }

    public static void PlaySFX(AudioClips sfx) {
        instance.sfxSource.PlayOneShot(instance.audioClips[(int)sfx], instance.sfxSource.volume);
    }

    public static void PlayWalk() {
        if (!instance.walkSource.isPlaying) {
            instance.walkSource.Play();
        }
    }

    public static void StopWalk() {
        instance.walkSource.Stop();
    }
}
