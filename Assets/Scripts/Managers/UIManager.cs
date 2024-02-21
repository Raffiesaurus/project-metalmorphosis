using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    private static UIManager instance = null;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
}
