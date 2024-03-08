using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    [SerializeField] private GameObject[] morgueLevels;
    [SerializeField] private GameObject[] cityLevels;

    [SerializeField] private GameObject levelParent;

    [SerializeField] private GameObject spawnLevel;

    [Header("Map Generation")]
    [SerializeField] private int maxLevel = 20;
    [SerializeField] private int maxPuzzle = 5;
    [SerializeField] private int maxRest = 5;

    [SerializeField] private int levelsPerGame = 10;
    [SerializeField] private int levelsPerRow = 6;

    [SerializeField] private MapScreen mapScreen;

    private LevelBase[] orderedLevels;

    private LevelBase currentLevel;

    private int remainingEnemies;
    public static int RemainingEnemies {
        get {
            return instance.remainingEnemies;
        }
    }

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
        if (currentLevel != null) {
            remainingEnemies = currentLevel.enemyCount;
        }
    }

    void GenerateLevelMap() {
        int runGens = 4;
        int[] randomlyChosenFirstLevel = new int[runGens];
        int[] randomlyChosenSecondLevel = new int[runGens];
        ArrayList chosenLevelsPerRowPerRunGen = new ArrayList();
        MapLevelPrefab[,] mapLevels = new MapLevelPrefab[levelsPerGame - 1, levelsPerRow];

        for (int i = 0; i < levelsPerGame - 1; i++) {
            for (int j = 0; j < levelsPerRow; j++) {
                GameObject newLevelPrefab = Instantiate(mapScreen.levelUIObject, mapScreen.levelUIParent.transform, false);
                mapLevels[i, j] = newLevelPrefab.GetComponent<MapLevelPrefab>();
            }
        }


        MapLevelPrefab bossLevel = new MapLevelPrefab();
        //bossLevel.SetLevelType(LevelType.Boss);
        bossLevel.tempName = (levelsPerGame - 1).ToString() + " BOSS";

        for (int i = 0; i < levelsPerGame - 1; i++) {
            for (int j = 0; j < levelsPerRow; j++) {
                mapLevels[i, j].tempName = i.ToString() + " " + j.ToString();
                mapLevels[i, j].gameObject.name = i.ToString() + " " + j.ToString();
                mapLevels[i, j].row = i;
                mapLevels[i, j].col = j;
            }
        }

        foreach (MapLevelPrefab level in mapLevels) {
            //Debug.Log(level.tempName);
        }
        //Debug.Log(bossLevel.tempName);

        for (int runCount = 0; runCount < runGens; runCount++) {
            ArrayList chosenLevelsPerRow = new ArrayList();

            int randLevel;
            int randLevel2;
            int minLevel;
            int maxLevel;
            //Choosing a random starting level

            do {
                randLevel = Random.Range(0, levelsPerRow - 1);
                if (runCount < 2) {
                    while (randomlyChosenFirstLevel.Contains(randLevel)) {
                        randLevel = Random.Range(0, levelsPerRow - 1);
                    }
                }

                minLevel = randLevel - 1;
                if (minLevel < 0) {
                    minLevel = 0;
                }
                maxLevel = randLevel + 1;
                if (maxLevel > levelsPerRow - 1) {
                    maxLevel = levelsPerRow - 1;
                }
                randLevel2 = Random.Range(minLevel, maxLevel + 1);
                if (runCount < 2) {
                    while (randomlyChosenSecondLevel.Contains(randLevel)) {
                        randLevel2 = Random.Range(minLevel, maxLevel + 1);
                    }
                }
            } while (CheckCrossingPaths(randLevel, randLevel2, 0, chosenLevelsPerRowPerRunGen));

            randomlyChosenFirstLevel.Append(randLevel);
            randomlyChosenSecondLevel.Append(randLevel2);

            if (!mapLevels[0, randLevel].postConnection.Contains(mapLevels[1, randLevel2].gameObject)) {
                mapLevels[0, randLevel].postConnection.Add(mapLevels[1, randLevel2].gameObject);
            }

            if (!mapLevels[1, randLevel2].preConnection.Contains(mapLevels[0, randLevel].gameObject)) {
                mapLevels[1, randLevel2].preConnection.Add(mapLevels[0, randLevel].gameObject);
            }

            //Debug.Log("Linkning 0 " + randLevel + " and 1 " + randLevel2);
            chosenLevelsPerRow.Add(randLevel);
            chosenLevelsPerRow.Add(randLevel2);

            for (int rowCount = 2; rowCount < levelsPerGame - 1; rowCount++) {
                int nextLevel;
                do {
                    minLevel = (int)chosenLevelsPerRow[^1] - 1;
                    //Debug.Log("Min Level: " + minLevel);
                    if (minLevel < 0) {
                        minLevel = 0;
                    }
                    //Debug.Log("Max Level: " + maxLevel);
                    maxLevel = (int)chosenLevelsPerRow[^1] + 1;
                    if (maxLevel > levelsPerRow - 1) {
                        maxLevel = levelsPerRow - 1;
                    }
                    nextLevel = Random.Range(minLevel, maxLevel + 1);
                    //Debug.Log("Next Level: " + nextLevel);
                } while (CheckCrossingPaths((int)chosenLevelsPerRow[^1], nextLevel, chosenLevelsPerRow.Count - 1, chosenLevelsPerRowPerRunGen));

                if (!mapLevels[rowCount - 1, (int)chosenLevelsPerRow[^1]].postConnection.Contains(mapLevels[rowCount, nextLevel].gameObject)) {
                    mapLevels[rowCount - 1, (int)chosenLevelsPerRow[^1]].postConnection.Add(mapLevels[rowCount, nextLevel].gameObject);
                }

                if (!mapLevels[rowCount, nextLevel].preConnection.Contains(mapLevels[rowCount - 1, (int)chosenLevelsPerRow[^1]].gameObject)) {
                    mapLevels[rowCount, nextLevel].preConnection.Add(mapLevels[rowCount - 1, (int)chosenLevelsPerRow[^1]].gameObject);
                }

                //Debug.Log("Linkning " + (rowCount - 1) + " " + (int)chosenLevelsPerRow[^1] + " and " + rowCount + " " + nextLevel);
                chosenLevelsPerRow.Add(nextLevel);
            }


            chosenLevelsPerRowPerRunGen.Add(chosenLevelsPerRow);

        }


        foreach (ArrayList element in chosenLevelsPerRowPerRunGen) {
            /*Debug.Log("-------------------------------------------");
            //Debug.Log(element);
            foreach (int element2 in element) {
                Debug.Log(element2);
            }*/
        }

        foreach (MapLevelPrefab mapLevel in mapLevels) {
            /*if (mapLevel.tempName.StartsWith("0")) {
                mapLevel.SetLevelType(LevelType.Rest);
            }*/
            if (mapLevel.preConnection.Count == 0 && mapLevel.postConnection.Count == 0) {
                Destroy(mapLevel.transform.GetChild(0).gameObject);
            } else {
                if (mapLevel.tempName.StartsWith((levelsPerGame - 2).ToString())) {
                    mapLevel.SetLevelType(LevelType.Rest);
                } else if (mapLevel.tempName.StartsWith(((levelsPerGame - 2) / 2).ToString())) {
                    mapLevel.SetLevelType(LevelType.Puzzle);
                } else {
                    if (mapLevel.tempName.StartsWith("0") || mapLevel.tempName.StartsWith("1")) {
                        mapLevel.SetLevelType(LevelType.Combat);
                    } else {
                        int randChance = Random.Range(1, 10);
                        if (randChance == 1) {
                            mapLevel.SetLevelType(LevelType.Rest);
                        } else if (randChance == 2) {
                            mapLevel.SetLevelType(LevelType.Puzzle);
                        } else {
                            mapLevel.SetLevelType(LevelType.Combat);
                        }
                    }
                }
            }

        }


    }

    bool CheckCrossingPaths(int preRandLevel, int currentRandLevel, int prevRow, ArrayList chosenLevelsPerRowPerRunGen) {
        foreach (ArrayList rowPerGen in chosenLevelsPerRowPerRunGen) {
            //Debug.Log("kek? " + rowPerGen[prevRow] + " " + rowPerGen[prevRow+1]);
            if (preRandLevel == (int)rowPerGen[prevRow] + 1 || preRandLevel == (int)rowPerGen[prevRow] - 1) {
                //Debug.Log("NEIGHBOURING STARTING POINT");
                /*
                 * I am connecting to randlevel2 from randlevel
                 * randlevel is a neighbour
                 * my neighbour is connecting to rowpergen[1]
                 * if i am lower value than neighbour, i am crossing paths with higher value next node
                 * vice versa
                 * 
                 */
                if (preRandLevel < (int)rowPerGen[prevRow]) {
                    if (currentRandLevel > (int)rowPerGen[prevRow + 1]) {
                        //Debug.Log("SMOL IM SORRY IM CROSSING YOUR PATH " + preRandLevel + currentRandLevel + " " + (int)rowPerGen[prevRow] + (int)rowPerGen[prevRow + 1]);
                        return true;
                    }
                } else {
                    if (currentRandLevel < (int)rowPerGen[prevRow + 1]) {
                        //Debug.Log("BIG IM SORRY IM CROSSING YOUR PATH " + preRandLevel + currentRandLevel + " " + (int)rowPerGen[prevRow] + (int)rowPerGen[prevRow + 1]);
                        return true;
                    }
                }

            }
        }
        return false;
    }
}
