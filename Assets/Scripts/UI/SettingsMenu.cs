using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {
    [SerializeField] private SpriteRenderer textHighlight;

    [SerializeField] private GameObject audioStuff;
    [SerializeField] private GameObject audioBox;
    [SerializeField] private GameObject audioButton;

    [SerializeField] private Slider masterVolSlider;
    [SerializeField] private Slider musicVolSlider;
    [SerializeField] private Slider sfxVolSlider;

    [SerializeField] private TMP_Text masterVolText;
    [SerializeField] private TMP_Text musicVolText;
    [SerializeField] private TMP_Text sfxVolText;

    [SerializeField] private GameObject graphicsStuff;
    [SerializeField] private GameObject graphicsBox;
    [SerializeField] private GameObject graphicsButton;

    [SerializeField] private GameObject controlsStuff;
    [SerializeField] private GameObject controlsBox;
    [SerializeField] private GameObject controlsButton;

    [SerializeField] private TMP_Text displayResText;
    [SerializeField] private TMP_Text windowModeText;
    [SerializeField] private TMP_Text qualityText;

    private int displayCount = 0;
    private int windowCount = 0;
    private int qualityCount = 0;


    public void Activate() {
        gameObject.SetActive(true);

        graphicsStuff.SetActive(false);
        graphicsBox.transform.position = new Vector3(-579.900024f, 175, 0);

        controlsStuff.SetActive(false);
        controlsBox.transform.position = new Vector3(-579.900024f, -30, 0);

        masterVolSlider.value = AudioManager.GetMasterVolume();
        masterVolText.text = (masterVolSlider.value * 100).ToString("F2");

        musicVolSlider.value = AudioManager.GetMusicVolume();
        musicVolText.text = (musicVolSlider.value * 100).ToString("F2");

        sfxVolSlider.value = AudioManager.GetSFXVolume();
        sfxVolText.text = (sfxVolSlider.value * 100).ToString("F2");

        switch (SettingsManager.GetDisplayRes()) {
            case DisplayRes.Min:
                displayCount = 0;
                displayResText.text = "Min";
                break;
            case DisplayRes.Med:
                displayCount = 1;
                displayResText.text = "Medium";
                break;
            case DisplayRes.Max:
                displayCount = 2;
                displayResText.text = "Max";
                break;
        }

        switch (SettingsManager.GetQuality()) {
            case Quality.Min:
                qualityCount = 0;
                qualityText.text = "Min";
                break;
            case Quality.Med:
                qualityCount = 1;
                qualityText.text = "Medium";
                break;
            case Quality.Max:
                qualityCount = 2;
                qualityText.text = "Max";
                break;
        }

        switch (SettingsManager.GetWindowMode()) {
            case WindowMode.Window:
                windowCount = 0;
                windowModeText.text = "Window";
                break;
            case WindowMode.Full:
                windowCount = 1;
                windowModeText.text = "Full";
                break;
            case WindowMode.Borderless:
                windowCount = 2;
                windowModeText.text = "Borderless";
                break;
        }


        OnAudioButton();
    }

    public void Deactivate() {
        gameObject.SetActive(false);
    }

    public void HighlightButton(BaseEventData eventData) {
        GameObject hoveredObject = ((PointerEventData)eventData).pointerEnter;
        if (hoveredObject.GetComponent<TMP_Text>() != null) {
            textHighlight.transform.gameObject.SetActive(true);
        }
    }

    public void UnhighlightButton(BaseEventData eventData) {
        GameObject hoveredObject = ((PointerEventData)eventData).pointerEnter;
        if (hoveredObject.GetComponent<TMP_Text>() != null) {
            textHighlight.transform.gameObject.SetActive(false);
        }
    }

    public void OnAudioButton() {
        audioStuff.SetActive(true);

        graphicsStuff.SetActive(false);
        graphicsBox.transform.localPosition = new Vector3(-579.900024f, 18, 0);
        graphicsButton.transform.localPosition = graphicsBox.transform.localPosition;

        controlsStuff.SetActive(false);
        controlsBox.transform.localPosition = new Vector3(-579.900024f, -166, 0);
        controlsButton.transform.localPosition = controlsBox.transform.localPosition;
    }

    public void OnGraphicsButton() {
        audioStuff.SetActive(false);

        graphicsStuff.SetActive(true);
        graphicsBox.transform.localPosition = new Vector3(-579.900024f, 175, 0);
        graphicsButton.transform.localPosition = graphicsBox.transform.localPosition;

        controlsStuff.SetActive(false);
        controlsBox.transform.localPosition = new Vector3(-579.900024f, -166, 0);
        controlsButton.transform.localPosition = controlsBox.transform.localPosition;
    }

    public void OnControlsButton() {
        audioStuff.SetActive(false);

        graphicsStuff.SetActive(false);
        graphicsBox.transform.localPosition = new Vector3(-579.900024f, 175, 0);
        graphicsButton.transform.localPosition = graphicsBox.transform.localPosition;

        controlsStuff.SetActive(true);
        controlsBox.transform.localPosition = new Vector3(-579.900024f, -30, 0);
        controlsButton.transform.localPosition = controlsBox.transform.localPosition;
    }

    public void OnMasterVolumeSlider() {
        AudioManager.SetMasterVolume(masterVolSlider.value);
        masterVolText.text = (masterVolSlider.value * 100).ToString("F2");
    }

    public void OnMusicVolumeSlider() {
        AudioManager.SetMuicVolume(musicVolSlider.value);
        musicVolText.text = (musicVolSlider.value * 100).ToString("F2");
    }

    public void OnSFXVolumeSlider() {
        AudioManager.SetSFXVolume(sfxVolSlider.value);
        sfxVolText.text = (sfxVolSlider.value * 100).ToString("F2");
    }

    public void OnDisplayRightButton() {
        displayCount++;
        if (displayCount > 2) {
            displayCount = 0;
        }
        switch (displayCount) {
            case 0:
                SettingsManager.SetDisplayRes(DisplayRes.Min);
                displayResText.text = "Min";
                break;
            case 1:
                SettingsManager.SetDisplayRes(DisplayRes.Med);
                displayResText.text = "Medium";
                break;
            case 2:
                SettingsManager.SetDisplayRes(DisplayRes.Max);
                displayResText.text = "Max";
                break;
        }
    }

    public void OnDisplayLeftButton() {
        displayCount--;
        if (displayCount < 0) {
            displayCount = 2;
        }
        switch (displayCount) {
            case 0:
                SettingsManager.SetDisplayRes(DisplayRes.Min);
                displayResText.text = "Min";
                break;
            case 1:
                SettingsManager.SetDisplayRes(DisplayRes.Med);
                displayResText.text = "Medium";
                break;
            case 2:
                SettingsManager.SetDisplayRes(DisplayRes.Max);
                displayResText.text = "Max";
                break;
        }
    }

    public void OnWindowRightButton() {
        windowCount++;
        if (windowCount > 2) {
            windowCount = 0;
        }
        switch (windowCount) {
            case 0:
                SettingsManager.SetWindowMode(WindowMode.Window);
                windowModeText.text = "Window";
                break;
            case 1:
                SettingsManager.SetWindowMode(WindowMode.Full);
                windowModeText.text = "Full";
                break;
            case 2:
                SettingsManager.SetWindowMode(WindowMode.Borderless);
                windowModeText.text = "Borderless";
                break;
        }
    }

    public void OnWindowLeftButton() {
        windowCount--;
        if (windowCount < 0) {
            windowCount = 2;
        }
        switch (windowCount) {
            case 0:
                SettingsManager.SetWindowMode(WindowMode.Window);
                windowModeText.text = "Window";
                break;
            case 1:
                SettingsManager.SetWindowMode(WindowMode.Full);
                windowModeText.text = "Full";
                break;
            case 2:
                SettingsManager.SetWindowMode(WindowMode.Borderless);
                windowModeText.text = "Borderless";
                break;
        }
    }

    public void OnQualityRightButton() {
        qualityCount++;
        if (qualityCount > 2) {
            qualityCount = 0;
        }
        switch (qualityCount) {
            case 0:
                SettingsManager.SetQuality(Quality.Min);
                qualityText.text = "Min";
                break;
            case 1:
                SettingsManager.SetQuality(Quality.Med);
                qualityText.text = "Medium";
                break;
            case 2:
                SettingsManager.SetQuality(Quality.Max);
                qualityText.text = "Max";
                break;
        }
    }

    public void OnQualityLeftButton() {
        qualityCount--;
        if (qualityCount < 0) {
            qualityCount = 2;
        }
        switch (qualityCount) {
            case 0:
                SettingsManager.SetQuality(Quality.Min);
                qualityText.text = "Min";
                break;
            case 1:
                SettingsManager.SetQuality(Quality.Med);
                qualityText.text = "Medium";
                break;
            case 2:
                SettingsManager.SetQuality(Quality.Max);
                qualityText.text = "Max";
                break;
        }
    }

    public void OnBackButton() {
        UIManager.ActivateMainMenu();
    }
}
