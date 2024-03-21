using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MapScreen : MonoBehaviour {

    [SerializeField] public GameObject levelUIPrefab;
    [SerializeField] public GameObject bossLevelUIPrefab;
    [SerializeField] public GameObject levelUIParent;
    [SerializeField] public GameObject emptyLevelUIPrefab;

    [SerializeField] public Sprite combatImage;
    [SerializeField] public Sprite restImage;
    [SerializeField] public Sprite puzzleImage;

    [HideInInspector] public GameObject bossLevelObject;

   
}
