using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverObject : MonoBehaviour {

    [SerializeField] private float health = 0;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void UpdateHealth(float change) {
        health += change;

        health = Mathf.Clamp(health, 0, 100);

        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
