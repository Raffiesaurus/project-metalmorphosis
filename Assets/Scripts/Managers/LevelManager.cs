using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField] private GameObject[] morgueLevels;
    [SerializeField] private GameObject[] cityLevels;

    [SerializeField] private GameObject levelParent;

    [SerializeField] private GameObject spawnLevel;

    private LevelBase currentLevel;

    private static LevelManager instance = null;
    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start() {
        currentLevel = levelParent.GetComponentInChildren<LevelBase>();
        if (currentLevel != null) {
            currentLevel.StartLevel();
        } else {
            GameObject newLevel = Instantiate(spawnLevel);
            newLevel.transform.SetParent(levelParent.transform);
            newLevel.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            newLevel.GetComponent<LevelBase>().StartLevel();
        }
    }

    void Update() {

    }
}
