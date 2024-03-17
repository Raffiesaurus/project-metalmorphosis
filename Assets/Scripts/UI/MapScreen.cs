using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MapScreen : MonoBehaviour {
    private bool dragging = false;
    [SerializeField] private Vector3 offset;

    public GameObject levelUIObject;
    public GameObject bossLevelUIObject;
    public GameObject levelUIParent;
    public GameObject bossLevelPrefab;

    private void Update() {
        if (dragging) {
            transform.position = CameraManager.GetUICamera().ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseDown() {
        offset = transform.position - CameraManager.GetUICamera().ScreenToWorldPoint(Input.mousePosition) + offset;
        dragging = true;
    }

    private void OnMouseUp() {
        dragging = false;

    }
}
