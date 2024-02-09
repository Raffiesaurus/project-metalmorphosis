using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBulletArm : PlayerArm {

    public override void Awake() {

    }
    public override void PartFire(Vector3 mousePos) {
        PrefabManager.SpawnAndFire(bulletType, transform.position, mousePos);
    }
}
