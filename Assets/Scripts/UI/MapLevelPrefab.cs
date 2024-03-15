using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapLevelPrefab : MonoBehaviour {
    [SerializeField] public TextMeshProUGUI levelText = null;
    [SerializeField] public GameObject[] arrowObjects = null;
    [SerializeField] public Button levelStartButton = null;
    [SerializeField] public Image disabledImage = null;
    [SerializeField] public Image completedImage = null;
    public bool hasStartedLevel = false;
    public bool hasCompletedLevel = false;
    public bool canClick = false;
    public int row = 0;
    public int col = 0;
    public LevelType levelType;

    public string tempName = "";

    public List<GameObject> preConnection;
    public List<GameObject> postConnection;

    public void SetLevelType(LevelType type) {
        levelType = type;
        //levelText = GetComponentInChildren<TMP_Text>();
        if (levelType == LevelType.Combat) {
            levelText.text = "C";
        } else if (levelType == LevelType.Boss) {
            levelText.text = "B";
        } else if (levelType == LevelType.Rest) {
            levelText.text = "R";
        } else {
            levelText.text = "P";
        }
        SetArrowDirections();
    }

    public void SetArrowDirections() {
        foreach (GameObject arrowObj in arrowObjects) {
            arrowObj.SetActive(false);
        }
        /*        for (int i = 0; i < postConnection.Count; i++) {
                    arrowObjects[i].SetActive(true);
                    GameObject mapLevelObject = postConnection[i];
                    Debug.Log(mapLevelObject.name);
                    Debug.Log(gameObject.name);
                    Vector2 dirVec = mapLevelObject.transform.localPosition - gameObject.transform.localPosition;
                    float angle = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg;
                    arrowObjects[i].transform.eulerAngles = new(0, 0, angle);
                    Debug.Log("Angle: " + angle);
                }*/
        foreach (GameObject mapLevelObject in postConnection) {
            MapLevelPrefab level = mapLevelObject.GetComponent<MapLevelPrefab>();
            if (level.col == col) {
                arrowObjects[1].SetActive(true);
            } else if (level.col < col) {
                arrowObjects[0].SetActive(true);
            } else if (level.col > col) {
                arrowObjects[2].SetActive(true);
            }
        }

    }

    private void Update() {
        if (levelStartButton != null) {
            levelStartButton.enabled = canClick;
            disabledImage.gameObject.SetActive(!levelStartButton.enabled);
            if (hasCompletedLevel) {
                disabledImage.gameObject.SetActive(false);
                completedImage.gameObject.SetActive(true);
            } else {
                completedImage.gameObject.SetActive(false);
            }
        } else {
            disabledImage.gameObject.SetActive(false);
            completedImage.gameObject.SetActive(false);
        }

    }

    public void OnLevelStart() {
        hasStartedLevel = true;
        LevelManager.StartLevel(this, levelType);
    }
}
