using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NewGameMenu : MonoBehaviour {
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
        SceneManager.LoadSceneAsync(1);
    }

    public void OnBackButton() {
        UIManager.ActivateMainMenu();
    }
}