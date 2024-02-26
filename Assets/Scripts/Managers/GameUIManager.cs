using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {

    private static GameUIManager instance = null;

    private bool isInMapScreen = false;
    public static bool IsInMapScreen {
        get {
            return instance.isInMapScreen;
        }
        set {
            instance.isInMapScreen = value;
        }
    }

    [SerializeField] private Camera uiCamera = null;

    [SerializeField] private Slider healthBar = null;
    [SerializeField] private Slider fuelBar = null;

    [SerializeField] private GameObject inGameUI = null;
    [SerializeField] private GameObject mapScreen = null;

    [SerializeField] private TMP_Text ammoText = null;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public static void UpdateHealthBar(float ratio) {
        instance.healthBar.value = ratio;
    }

    public static void UpdateFuelBar(float ratio) {
        instance.fuelBar.value = ratio;
    }

    public static void UpdateAmmoCount(int count, int maxCount) {
        instance.ammoText.text = "Ammo: " + count + "/" + maxCount;
    }

    public static void SwitchToMap() {
        instance.isInMapScreen = true;
        instance.inGameUI.SetActive(false);
        instance.mapScreen.SetActive(true);
    }

    public static void SwitchToInGame() {
        instance.isInMapScreen = false;
        instance.inGameUI.SetActive(true);
        instance.mapScreen.SetActive(false);
    }
}
