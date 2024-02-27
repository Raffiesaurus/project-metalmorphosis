using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    [SerializeField] private Camera playerCam;
    [SerializeField] private Camera uiCam;
    [SerializeField] private Camera equipScreenCam;

    private static CameraManager instance = null;
    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.M)) {
            SwitchToEquipView();
        }

        if (Input.GetKeyDown(KeyCode.N)) {
            SwitchToGameView();
        }

    }

    public static void ScreenShake() {

    }

    public static Camera GetPlayerCamera() {
        return instance.playerCam;
    }

    public static Camera GetUICamera() {
        return instance.uiCam;
    }

    public static Camera GetEquipScreenCamera() {
        return instance.equipScreenCam;
    }

    public static void SwitchToEquipView() {
        GameManager.IsInEquipMode = true;
        instance.playerCam.enabled = false;
        instance.uiCam.enabled = true;
        instance.equipScreenCam.enabled = true;
    }

    public static void SwitchToGameView() {
        instance.playerCam.enabled = true;
        instance.uiCam.enabled = true;
        instance.equipScreenCam.enabled = false;
        GameManager.IsInEquipMode = false;
    }
}
