using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class OneWayCover : MonoBehaviour {

    private Rigidbody2D rb = null;
    private BoxCollider2D boxCol = null;

    void OnEnable() {
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    public bool CheckSide(float x) {

        return (x < transform.position.x);

    }
}
