using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private PlayerMain playerObject;

    [SerializeField] private SwapScreen swapScreen;

    private static GameManager instance = null;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start() {
        GameUIManager.SwitchToMap();
    }

    // Update is called once per frame
    void Update() {

    }

    public static void SwitchToLevel() {
        GameUIManager.SwitchToInGame();
    }

    public static void SwitchToMap() {
        GameUIManager.SwitchToMap();
    }

    public static PlayerMain GetPlayer() {
        return instance.playerObject;
    }

    public static void SetupSwap(PartDropData data) {
        instance.swapScreen.gameObject.SetActive(true);
        instance.swapScreen.Setup(data);
    }

    public static void BackToGameFromSwap() {
        instance.swapScreen.gameObject.SetActive(false);
    }
}
