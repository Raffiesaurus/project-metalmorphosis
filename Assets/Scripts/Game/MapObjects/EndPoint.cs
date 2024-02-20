using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour {
    public void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "player") {
            Debug.Log("Level complete");
        }

    }
}
