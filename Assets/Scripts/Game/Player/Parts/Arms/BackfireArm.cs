using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackfireArm : PlayerArm {

    public override void Awake() {
        bulletType = BulletType.Grenade;
        armPart = ArmPart.Backfire;
        partRarity = PartRarity.Epic;

        cooldown = 2;
        meleeDamage = 0;
        ammoUsage = 15;
        fuelUsage = 15;
    }

    public override void PartFire(Vector3 mousePos, Vector3 spawnPoint) {
        if (cdCounter <= 0 && player.currentAmmo >= ammoUsage && player.currentFuel >= fuelUsage) {
            player.UpdateAmmo(-ammoUsage);
            player.UpdateFuel(-fuelUsage);
            cdCounter = cooldown;
            PrefabManager.SpawnAndFire(bulletType, spawnPoint, mousePos, gameObject.tag);
        }
    }

}
