using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField] private GameObject[] morgueLevels;
    [SerializeField] private GameObject[] cityLevels;

    [SerializeField] private GameObject levelParent;

    [SerializeField] private GameObject spawnLevel;

    [Header("Map Generation")]
    [SerializeField] private int maxLevel = 10;
    [SerializeField] private int maxPuzzle = 2;
    [SerializeField] private int maxRest = 2;

    private LevelBase[] orderedLevels;

    private LevelBase currentLevel;

    private static LevelManager instance = null;
    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        GenerateLevelMap();
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

    void GenerateLevelMap() {
        List<LevelBase> allLevels = new();

        int genRestMaps = 0;
        int genPuzzleMaps = 0;

        for (int i = 0; i < maxLevel - 1; i++) {
            LevelBase newLevel = new();
            if (genPuzzleMaps >= maxPuzzle && genRestMaps >= maxRest) {
                newLevel.levelType = LevelType.Combat;
            } else {
                int randLevelType = Random.Range(0, 3);
                if (randLevelType == 0) {
                    newLevel.levelType = LevelType.Combat;
                } else {
                    if (randLevelType == 1 && genPuzzleMaps < maxPuzzle) {
                        newLevel.levelType = LevelType.Puzzle;
                        genPuzzleMaps++;
                    } else if (randLevelType == 2 && genRestMaps < maxRest) {
                        newLevel.levelType = LevelType.Rest;
                        genRestMaps++;
                    } else {
                        newLevel.levelType = LevelType.Combat;
                    }
                }
            }
            allLevels.Add(newLevel);
        }

        LevelBase bossLevel = new() {
            levelType = LevelType.Boss
        };
        allLevels.Add(bossLevel);

        foreach (LevelBase level in allLevels) {
            //Debug.Log(level.levelType);
        }


    }
}
