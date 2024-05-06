using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [SerializeField] private SpriteRenderer textHighlight;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Activate() {
        gameObject.SetActive(true);
    }

    public void Deactivate() {
        gameObject.SetActive(false);
    }

    public void HighlightButton(BaseEventData eventData) {
        AudioManager.PlaySFX(AudioClips.ButtonHover);
        Vector3 buttonPosition = ((PointerEventData)eventData).pointerEnter.transform.position;
        buttonPosition.y += 9;
        buttonPosition.x -= 35;
        textHighlight.transform.position = buttonPosition;
    }

    public void OnPlayButton() {
        AudioManager.PlaySFX(AudioClips.Button);
        UIManager.ActivateNewGame();     
    }

    public void OnSettingsButton() {
        AudioManager.PlaySFX(AudioClips.Button);
        UIManager.ActivateSettings();
    }

    public void OnLoadButton() {
        AudioManager.PlaySFX(AudioClips.Button);
        UIManager.ActivateLoadGame();
    }

    public void OnCreditsButton() {
        AudioManager.PlaySFX(AudioClips.Button);
        UIManager.ActivateCredits();
    }

    public void OnHelpButton() {
        AudioManager.PlaySFX(AudioClips.Button);
        UIManager.ActivateHelp();
    }

    public void OnExitButton() {
        AudioManager.PlaySFX(AudioClips.Button);
        Application.Quit();
    }
}
