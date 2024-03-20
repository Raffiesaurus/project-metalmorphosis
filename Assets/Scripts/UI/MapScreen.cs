using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MapScreen : MonoBehaviour {
    private bool dragging = false;

    [SerializeField] private Vector3 offset;

    [SerializeField] public GameObject levelUIPrefab;
    [SerializeField] public GameObject bossLevelUIPrefab;
    [SerializeField] public GameObject levelUIParent;
    [SerializeField] public GameObject emptyLevelUIPrefab;
    [HideInInspector] public GameObject bossLevelObject;

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
