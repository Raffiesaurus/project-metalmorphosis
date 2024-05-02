using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour {

    private DisplayRes displayRes = DisplayRes.Max;
    private WindowMode windowMode = WindowMode.Full;
    private Quality quality = Quality.Max;

    private static SettingsManager instance = null;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public static DisplayRes GetDisplayRes() {
        return instance.displayRes;
    }

    public static WindowMode GetWindowMode() {
        return instance.windowMode;
    }

    public static Quality GetQuality() {
        return instance.quality;
    }

    public static void SetQuality(Quality quality) {
        instance.quality = quality;
    }

    public static void SetDisplayRes(DisplayRes displayRes) {
        instance.displayRes = displayRes;
    }

    public static void SetWindowMode(WindowMode windowMode) {
        instance.windowMode = windowMode;
    }
}
