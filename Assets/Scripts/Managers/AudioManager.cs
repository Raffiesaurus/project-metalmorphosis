using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    private static AudioManager audioManager = null;
    private void Awake() {
        if (audioManager == null) {
            audioManager = this;
        }
    }
    void Update() {

    }
}
