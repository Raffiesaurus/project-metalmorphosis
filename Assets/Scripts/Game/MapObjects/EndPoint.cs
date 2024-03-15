using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour {

    public bool hasCompletedLevel = false;

    public void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("player")) {
            if (LevelManager.RemainingEnemies != 0) {
                GameUIManager.ShowNotification("Kill the enemies remaining!");
            } else {
                GameUIManager.ShowNotification("Level Complete");
                hasCompletedLevel = true;
            }
        }

    }
}

