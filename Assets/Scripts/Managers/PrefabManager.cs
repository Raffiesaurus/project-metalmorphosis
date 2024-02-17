using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour {
    [SerializeField] public GameObject basicBullet = null;

    private static PrefabManager prefabManager = null;

    private void Awake() {
        if (prefabManager == null) {
            prefabManager = this;
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
            GameObject newBasicBullet = Instantiate(prefabManager.basicBullet);
            newBasicBullet.GetComponent<BasicBullet>().OnFire(startPoint, firePoint, ownerTag);
        }
    }
}
