using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevelPrefab : MonoBehaviour {
    public bool hasStartedLevel = false;
    public bool hasCompletedLevel = false;

    public LevelType levelType;

    public string tempName = "";

    public List<GameObject> preConnection;
    public List<GameObject> postConnection;
}
