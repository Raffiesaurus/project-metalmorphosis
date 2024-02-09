using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] private Camera playerCam;
    [SerializeField] private Camera uiCam;
    [SerializeField] private Camera equipScreenCam;

    private static CameraManager cameraManager = null;
    private void Awake() {
        if (cameraManager == null) {
            cameraManager = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ScreenShake() {
        
    }
}
