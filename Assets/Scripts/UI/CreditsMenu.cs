using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreditsMenu : MonoBehaviour
{
    [SerializeField] private SpriteRenderer textHighlight;

    public void Activate() {
        gameObject.SetActive(true);
    }

    public void Deactivate() {
        gameObject.SetActive(false);
    }

    public void HighlightButton(BaseEventData eventData) {
        GameObject hoveredObject = ((PointerEventData)eventData).pointerEnter;
        if (hoveredObject.GetComponent<TMP_Text>() != null) {
            AudioManager.PlaySFX(AudioClips.ButtonHover);
            textHighlight.transform.gameObject.SetActive(true);
        }
    }

    public void UnhighlightButton(BaseEventData eventData) {
        GameObject hoveredObject = ((PointerEventData)eventData).pointerEnter;
        if (hoveredObject.GetComponent<TMP_Text>() != null) {
            textHighlight.transform.gameObject.SetActive(false);
        }
    }

    public void OnBackButton() {
        AudioManager.PlaySFX(AudioClips.Button); 
        UIManager.ActivateMainMenu();
    }
}
