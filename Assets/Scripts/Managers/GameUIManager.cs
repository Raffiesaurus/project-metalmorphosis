using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {

    private static GameUIManager gameUIManager = null;

    [SerializeField] private Camera uiCamera = null;

    [SerializeField] private Slider healthBar = null;
    [SerializeField] private Slider fuelBar = null;
    [SerializeField] private TMP_Text ammoText = null;

    private void Awake() {
        if (gameUIManager == null) {
            gameUIManager = this;
        }
    }

    public static void UpdateHealthBar(float ratio) {
        gameUIManager.healthBar.value = ratio;
    }

    public static void UpdateFuelBar(float ratio) {
        gameUIManager.fuelBar.value = ratio;
    }

    public static void UpdateAmmoCount(int count, int maxCount) {
        gameUIManager.ammoText.text = "Ammo: " + count + "/" + maxCount;
    }
}
