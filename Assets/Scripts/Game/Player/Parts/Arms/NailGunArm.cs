using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailGunArm : PlayerArm {

    public override void Awake() {
        bulletType = BulletType.BasicBullet;
        armPart = ArmPart.Nail_Gun;
    }
    public override void PartFire(Vector3 mousePos) {
        if (cdCounter <= 0 && player.ammo >= ammoUsage) {
            player.UpdateAmmo(-ammoUsage);
            cdCounter = cooldown;
            PrefabManager.SpawnAndFire(bulletType, transform.position, mousePos);
        }
    }

}
