using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBase : MonoBehaviour {

    [SerializeField] public GameObject startPoint = null;

    [SerializeField] public EndPoint endPoint = null;

    [HideInInspector] public LevelType levelType;

    public CoverObject[] coverObjects = null;

    public void Start() {
        coverObjects = GetComponentsInChildren<CoverObject>();
    }

    public void StartLevel() {
        GameManager.GetPlayer().GetComponent<PlayerMain>().SpawnAtPoint(startPoint.transform.position);
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("COLLISION");

        if (collision.gameObject.CompareTag("player")) {
            Debug.Log("Level complete");
        }

    }

}
