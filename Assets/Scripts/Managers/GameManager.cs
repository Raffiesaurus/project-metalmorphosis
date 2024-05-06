using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private PlayerMain playerObject;

    [SerializeField] private SwapScreen swapScreen;

    private static GameManager instance = null;

    private bool bulletBounce = false;
    public static bool BulletBounce {
        get {
            return instance.bulletBounce;
        }
        set {
            instance.bulletBounce = value;
        }
    }

    private bool oneHitMode = false;
    public static bool OneHitMode {
        get {
            return instance.oneHitMode;
        }
        set {
            instance.oneHitMode = value;
        }
    }

    private bool playerReturnDamage = false;
    public static bool PlayerReturnDamage {
        get {
            return instance.playerReturnDamage;
        }
        set {
            instance.playerReturnDamage = value;
        }
    }

    private float playerReturnDamageAmount = 0.0f;
    public static float PlayerReturnDamageAmount {
        get {
            return instance.playerReturnDamageAmount;
        }
        set {
            instance.playerReturnDamageAmount = value;
        }
    }


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
        if (instance.playerObject)
            return instance.playerObject;
        else
            return null;
    }

    public static void SetupSwap(PartDropData data) {
        instance.swapScreen.gameObject.SetActive(true);
        instance.swapScreen.Setup(data);
    }

    public static void BackToGameFromSwap() {
        instance.swapScreen.gameObject.SetActive(false);
    }

    public static void GameOver(bool victory) {
        GameUIManager.GameOver(victory);
    }
}
