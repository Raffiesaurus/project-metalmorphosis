using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadGameMenu : MonoBehaviour {
    [SerializeField] private SpriteRenderer textHighlight;

    public void Activate() {
        gameObject.SetActive(true);
    }

    public void Deactivate() {
        gameObject.SetActive(false);
    }

    public void HighlightButton(BaseEventData eventData) {
        AudioManager.PlaySFX(AudioClips.ButtonHover);
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

    public void OnSaveSlot() {
        AudioManager.PlaySFX(AudioClips.Button);
        SceneManager.LoadSceneAsync(1);
    }

    public void OnBackButton() {
        AudioManager.PlaySFX(AudioClips.Button); 
        UIManager.ActivateMainMenu();
    }
}
