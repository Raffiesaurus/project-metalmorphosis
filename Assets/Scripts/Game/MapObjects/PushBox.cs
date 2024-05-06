using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour {
    private Rigidbody2D rb = null;
    private BoxCollider2D boxCol = null;
    
    private Vector3 spawnPoint = Vector3.zero;

    void OnEnable() {
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
        spawnPoint = transform.localPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
    }

    public void ResetPosition() {
        transform.position = spawnPoint;
    }
}
