using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlitzburstArm : PlayerArm {

    public override void Awake() {
        bulletType = BulletType.BlitzBullet;
        armPart = ArmPart.Blitzburst;
        partRarity = PartRarity.Rare;

        cooldown = 0.2f;
        ammoUsage = 1;
    }

    public override void PartFire(Vector3 mousePos, Vector3 spawnPoint) {
        if (cdCounter <= 0 && player.currentAmmo >= ammoUsage) {
            player.UpdateAmmo(-ammoUsage);
            cdCounter = cooldown;
            PrefabManager.SpawnAndFire(bulletType, spawnPoint, mousePos, gameObject.tag);
        }
    }

}
