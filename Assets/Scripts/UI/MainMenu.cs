using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnPlayButton() {
        SceneManager.LoadSceneAsync(1);
    }

    public void OnExitButton() {
        Application.Quit();
    }
}
