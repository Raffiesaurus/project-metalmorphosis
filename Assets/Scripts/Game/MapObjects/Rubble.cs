using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubble : MonoBehaviour {

    private Rigidbody2D rb = null;
    private BoxCollider2D boxCol = null;


    void OnEnable() {
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
    }

}
