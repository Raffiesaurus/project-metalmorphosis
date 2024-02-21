using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    private static AudioManager instance = null;
    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    void Update() {

    }
}
