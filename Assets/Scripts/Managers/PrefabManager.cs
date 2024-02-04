using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour {
    [SerializeField] public GameObject basicBullet = null;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void SpawnAndFire(BulletType prefabType, Vector3 startPoint, Vector3 firePoint) {
        if (prefabType == BulletType.BasicBullet) {
            //GameObject newBasicBullet = Instantiate(basicBullet);
            //newBasicBullet.GetComponent<BasicBullet>().OnFire(startPoint, firePoint);
        }
    }
}
