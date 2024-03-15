using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBase : MonoBehaviour {

    [SerializeField] public GameObject startPoint = null;

    [SerializeField] public EndPoint endPoint = null;

    [HideInInspector] public LevelType levelType;

    [HideInInspector] public int enemyCount;

    [HideInInspector] public MapLevelPrefab connectedUIMap;

    public CoverObject[] coverObjects = null;

    public void Start() {
        coverObjects = GetComponentsInChildren<CoverObject>();
    }

    public void StartLevel() {
        GameManager.GetPlayer().GetComponent<PlayerMain>().SpawnAtPoint(startPoint.transform.position);
        GameManager.GetPlayer().GetComponent<PlayerMain>().UpdateEquippedItems();
        GameUIManager.ShowNotification("Level Start!");
    }

    private void Update() {
        EnemyUnit[] enemies = GetComponentsInChildren<EnemyUnit>();
        enemyCount = enemies.Length;

        if (endPoint.hasCompletedLevel) {
            OnLevelComplete();
        }
    }

    void OnLevelComplete() {
        endPoint.hasCompletedLevel = false;
        connectedUIMap.hasCompletedLevel = true;
        GameManager.SwitchToMap();
        Destroy(gameObject);
    }
}
