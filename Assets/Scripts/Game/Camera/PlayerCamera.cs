using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    private Vector3 cameraPosition;

    // Start is called before the first frame update
    void Start() {
        cameraPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {

        transform.position = new Vector3(GameManager.GetPlayer().transform.position.x, cameraPosition.y, cameraPosition.z);
    }
}
