using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (GameManager.GetPlayer() != null)
            transform.position = new Vector3(GameManager.GetPlayer().transform.position.x, transform.position.y, transform.position.z);
    }
}
