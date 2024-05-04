using PrimeTween;
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

    private bool isInSwapScreen = false;
    public static bool IsInSwapScreen {
        get {
            return instance.isInSwapScreen;
        }
        set {
            instance.isInSwapScreen = value;
        }
    }

    [SerializeField] private Camera uiCamera = null;

    [SerializeField] private Slider healthBar = null;
    [SerializeField] private Slider fuelBar = null;

    [SerializeField] private GameObject inGameUI = null;
    [SerializeField] private GameObject mapScreen = null;
    [SerializeField] private GameObject swapUI = null;

    [SerializeField] private PauseMenu pauseScreen = null;

    [SerializeField] private TMP_Text ammoText = null;

    [SerializeField] private TMP_Text notificationText = null;

    [SerializeField] private GameOverUI gameOverScreen = null;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        gameOverScreen.gameObject.SetActive(false);
        pauseScreen.gameObject.SetActive(false);
    }

    public static void UpdateHealthBar(float ratio) {
        instance.healthBar.value = ratio;
    }

    public static void UpdateFuelBar(float ratio) {
        instance.fuelBar.value = ratio;
    }

    public static void UpdateAmmoCount(int count, int maxCount) {
        instance.ammoText.text = count + "/" + maxCount;
    }

    public static void SwitchToMap() {
        instance.isInMapScreen = true;
        instance.isInSwapScreen = false;
        instance.inGameUI.SetActive(false);
        instance.mapScreen.SetActive(true);
        instance.swapUI.SetActive(false);
        CameraManager.SwitchToMapView();
        LevelManager.UpdateLevels();
    }

    public static void SwitchToInGame() {
        instance.isInMapScreen = false;
        instance.isInSwapScreen = false;
        instance.inGameUI.SetActive(true);
        instance.mapScreen.SetActive(false);
        instance.swapUI.SetActive(false);
        CameraManager.SwitchToGameView();
    }

    public static void SwitchToSwapScreen() {
        instance.isInSwapScreen = false;
        instance.isInSwapScreen = true;
        instance.inGameUI.SetActive(true);
        instance.mapScreen.SetActive(false);
        instance.swapUI.SetActive(true);
        CameraManager.SwitchToEquipView();
    }

    public static void ShowNotification(string message) {
        instance.notificationText.text = message;
        Tween.Scale(instance.notificationText.transform, endValue: 1, startValue: 0, duration: 0.75f, ease: Ease.InSine);
        Tween.Scale(instance.notificationText.transform, endValue: 0, startValue: 1, duration: 0.75f, ease: Ease.OutSine, startDelay: 1.25f);
    }

    public static void GameOver(bool victory) {
        instance.isInMapScreen = true;
        CameraManager.SwitchToMapView();
        instance.gameOverScreen.gameObject.SetActive(true);
        if (victory) {
            AudioManager.PlaySFX(AudioClips.Victory);
            instance.gameOverScreen.PlayerWon();
        } else {
            AudioManager.PlaySFX(AudioClips.Defeat);
            instance.gameOverScreen.PlayerDeath();
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!pauseScreen.isActive) {
                pauseScreen.Activate();
            }
        }

        isInMapScreen = gameOverScreen.gameObject.activeInHierarchy || mapScreen.gameObject.activeInHierarchy || pauseScreen.isActive;
    }
}
