using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverObject : MonoBehaviour {

    [SerializeField] private float health = 0;

    public void UpdateHealth(float healthChange) {
        if (GameManager.OneHitMode && healthChange < 0) {
            healthChange = -999999999;
        }
        health += healthChange;

        health = Mathf.Clamp(health, 0, 100);

        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
