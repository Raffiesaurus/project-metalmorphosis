using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    private static UIManager uiManager = null;

    private void Awake() {
        if (uiManager == null) {
            uiManager = this;
        }
    }
}
