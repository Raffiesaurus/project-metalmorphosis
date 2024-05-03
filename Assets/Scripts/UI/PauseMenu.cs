using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public bool isActive = false;

    public void Activate() {
        AudioManager.PlaySFX(AudioClips.Button);
        isActive = true;
        GameUIManager.IsInMapScreen = true;
        GameUIManager.IsInSwapScreen = true;
        gameObject.SetActive(true);
    }

    public void OnResumeButton() {
        AudioManager.PlaySFX(AudioClips.Button);
        isActive = false;
        GameUIManager.IsInMapScreen = false;
        GameUIManager.IsInSwapScreen = false;
        gameObject.SetActive(false);
    }

    public void OnQuitButton() {
        AudioManager.PlaySFX(AudioClips.Button);
        SceneManager.LoadSceneAsync(0);
    }
}
