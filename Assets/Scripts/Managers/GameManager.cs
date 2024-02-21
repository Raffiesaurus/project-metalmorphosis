using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private PlayerMain playerObject;

    private static GameManager instance = null;

    private bool isInEquipMode = false;

    public static bool IsInEquipMode {
        get {
            return instance.isInEquipMode;
        }
        set {
            instance.isInEquipMode = value;
        }
    }

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start() {
        CameraManager.SwitchToGameView();
    }

    // Update is called once per frame
    void Update() {

    }

    public static PlayerMain GetPlayer() {
        return instance.playerObject;
    }
}
