using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour {
    public void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("player")) {
            GameUIManager.ShowNotification("Level Complete");
            //Debug.Break();
        }

    }
}

