using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour {

    [SerializeField] public GameObject basicBullet = null;

    [SerializeField] public GameObject armDrop = null;
    [SerializeField] public GameObject legDrop = null;
    [SerializeField] public GameObject headDrop = null;

    private static PrefabManager instance = null;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public static void SpawnAndFire(BulletType prefabType, Vector3 startPoint, Vector3 firePoint, string ownerTag) {
        if (prefabType == BulletType.BasicBullet) {
            GameObject newBasicBullet = Instantiate(instance.basicBullet);
            newBasicBullet.GetComponent<BasicBullet>().OnFire(startPoint, firePoint, ownerTag);
        }
    }

    public static void SpawnDroppablePart(PartType type, PartRarity rarity, Vector2 spawnPoint) {
        GameObject droppedPart;
        if (type == PartType.Arm) {
            droppedPart = Instantiate(instance.armDrop);
            droppedPart.GetComponent<DroppedArm>().SetData(type, spawnPoint, rarity);
        } else if (type == PartType.Leg) {
            droppedPart = Instantiate(instance.legDrop);
        } else if (type == PartType.Head) {
            droppedPart = Instantiate(instance.headDrop);
        }
    }
}
