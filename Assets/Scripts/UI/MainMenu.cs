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
        Vector3 buttonPosition = ((PointerEventData)eventData).pointerEnter.transform.position;
        buttonPosition.y += 9;
        buttonPosition.x -= 35;
        textHighlight.transform.position = buttonPosition;
    }

    public void OnPlayButton() {
        UIManager.ActivateNewGame();     
    }

    public void OnSettingsButton() {
        UIManager.ActivateSettings();
    }

    public void OnLoadButton() {
        UIManager.ActivateLoadGame();
    }

    public void OnCreditsButton() {
        UIManager.ActivateCredits();
    }

    public void OnHelpButton() {
        UIManager.ActivateHelp();
    }

    public void OnExitButton() {
        Application.Quit();
    }
}
