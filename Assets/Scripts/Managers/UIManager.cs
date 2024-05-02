using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    private static UIManager instance = null;

    [SerializeField] private MainMenu mainMenu;

    [SerializeField] private NewGameMenu newGameMenu;

    [SerializeField] private LoadGameMenu loadGameMenu;

    [SerializeField] private SettingsMenu settingsMenu;

    [SerializeField] private CreditsMenu creditsMenu;

    [SerializeField] private HelpMenu helpMenu;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        DisableAll();
        mainMenu.Activate();
    }

    void DisableAll() {
        mainMenu.Deactivate();
        settingsMenu.Deactivate();
        creditsMenu.Deactivate();
        helpMenu.Deactivate();
        newGameMenu.Deactivate();
        loadGameMenu.Deactivate();
    }

    public static void ActivateMainMenu() {
        instance.DisableAll();
        instance.mainMenu.Activate();
    }

    public static void ActivateSettings() {
        instance.DisableAll();
        instance.settingsMenu.Activate();
    }

    public static void ActivateCredits() {
        instance.DisableAll();
        instance.creditsMenu.Activate();
    }

    public static void ActivateHelp() {
        instance.DisableAll();
        instance.helpMenu.Activate();
    }

    public static void ActivateNewGame() {
        instance.DisableAll();
        instance.newGameMenu.Activate();
    }

    public static void ActivateLoadGame() {
        instance.DisableAll();
        instance.loadGameMenu.Activate();
    }

}
