using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField] private GameObject[] morgueLevels;
    [SerializeField] private GameObject[] cityLevels;

    [SerializeField] private GameObject levelParent;

    [SerializeField] private GameObject spawnLevel;

    private LevelBase currentLevel;

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update() {
        /*if (currentLevel == null) {
            currentLevel = levelParent.GetComponentInChildren<LevelBase>();
        }*/
    }
}
