using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour {

    [SerializeField] public GameObject basicBullet = null;
    [SerializeField] public GameObject grenadeBullet = null;
    [SerializeField] public GameObject blitzBullet = null;

    [SerializeField] public GameObject armDrop = null;
    [SerializeField] public GameObject legDrop = null;
    [SerializeField] public GameObject headDrop = null;

    [SerializeField] public GameObject partDropParent = null;

    [SerializeField] public GameObject partDropUIParent = null;
    [SerializeField] public GameObject pickupPartUI = null;

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

    public static void SpawnAndFire(BulletType prefabType, Vector3 startPoint, Vector3 firePoint, GameObject owner) {
        if (prefabType == BulletType.BasicBullet) {
            GameObject newBasicBullet = Instantiate(instance.basicBullet);
            newBasicBullet.GetComponent<BasicBullet>().OnFire(startPoint, firePoint, owner);
        } else if (prefabType == BulletType.Grenade) {
            GameObject newGrenadeBullet = Instantiate(instance.grenadeBullet);
            newGrenadeBullet.GetComponent<GrenadeBullet>().OnFire(startPoint, firePoint, owner);
        } else if (prefabType == BulletType.BlitzBullet) {
            GameObject newBlitzBullet = Instantiate(instance.blitzBullet);
            newBlitzBullet.GetComponent<BlitzBullet>().OnFire(startPoint, firePoint, owner);
        }
    }

    public static void SpawnDroppablePart(PartType type, PartRarity rarity, Vector2 spawnPoint) {
        GameObject droppedPart = null;
        if (type == PartType.Arm) {
            droppedPart = Instantiate(instance.armDrop);
            droppedPart.GetComponent<DroppedArm>().SetData(type, spawnPoint, rarity);
        } else if (type == PartType.Leg) {
            droppedPart = Instantiate(instance.legDrop);
            droppedPart.GetComponent<DroppedLeg>().SetData(type, spawnPoint, rarity);
        } else if (type == PartType.Head) {
            droppedPart = Instantiate(instance.headDrop);
            droppedPart.GetComponent<DroppedHead>().SetData(type, spawnPoint, rarity);
        }
        droppedPart.transform.SetParent(instance.partDropParent.transform);
    }

    public static void ShowPickupUI(PartDropData uidata, GameObject droppedObject) {
        GameObject newUI = Instantiate(instance.pickupPartUI);
        newUI.transform.SetParent(instance.partDropUIParent.transform);
        newUI.transform.localPosition = Vector3.zero;
        newUI.transform.localScale = Vector3.one * 40;
        newUI.GetComponent<PickupPartUI>().SetData(uidata, droppedObject);
    }

    public static void HidePickupUI() {
        if (instance == null || instance.partDropUIParent == null) return;
        PickupPartUI[] allUIObjects = instance.partDropUIParent.GetComponentsInChildren<PickupPartUI>();
        if (allUIObjects == null) return;
        foreach (PickupPartUI uiObject in allUIObjects) {
            Destroy(uiObject.gameObject);
        }
    }
}
