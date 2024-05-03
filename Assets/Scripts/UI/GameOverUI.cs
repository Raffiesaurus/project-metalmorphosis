using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour {

    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private GameObject defeatScreen;

    public void PlayerWon() {
        AudioManager.PlaySFX(AudioClips.Victory);
        defeatScreen.SetActive(false);
        victoryScreen.SetActive(true);
    }

    public void PlayerDeath() {
        AudioManager.PlaySFX(AudioClips.Defeat);
        defeatScreen.SetActive(true);
        victoryScreen.SetActive(false);
    }

    public void OnMainMenuButton() {
        AudioManager.PlaySFX(AudioClips.Button);
        SceneManager.LoadSceneAsync(0);
    }
}
