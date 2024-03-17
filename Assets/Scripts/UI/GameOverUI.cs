using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour {

    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private GameObject defeatScreen;

    public void PlayerWon() {
        defeatScreen.SetActive(false);
        victoryScreen.SetActive(true);
    }

    public void PlayerDeath() {
        defeatScreen.SetActive(true);
        victoryScreen.SetActive(false);
    }

    public void OnMainMenuButton() {
        SceneManager.LoadSceneAsync(0);
    }
}
