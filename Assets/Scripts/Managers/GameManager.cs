using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private PlayerMain playerObject;

    private static GameManager gameManager = null;
    private void Awake() {
        if (gameManager == null) {
            gameManager = this;
        }
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public static PlayerMain GetPlayer() {
        return gameManager.playerObject;
    }
}
