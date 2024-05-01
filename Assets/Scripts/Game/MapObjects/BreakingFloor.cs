using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingFloor : MonoBehaviour {
    private Rigidbody2D rb = null;
    private BoxCollider2D boxCol = null;

    [SerializeField] private float destroyTime = 0.0f;

    void OnEnable() {
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("player"))
            Destroy(gameObject, destroyTime);
    }
}
