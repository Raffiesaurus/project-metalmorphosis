using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailGunArm : PlayerArm {

    public override void Awake() {
        bulletType = BulletType.BasicBullet;
        armPart = ArmPart.Nail_Gun;
        partRarity = PartRarity.Common;
    }
    public override void PartFire(Vector3 mousePos) {
        if (cdCounter <= 0 && player.currentAmmo >= ammoUsage) {
            player.UpdateAmmo(-ammoUsage);
            cdCounter = cooldown;
            PrefabManager.SpawnAndFire(bulletType, transform.position, mousePos, gameObject.tag);
        }
    }

}
