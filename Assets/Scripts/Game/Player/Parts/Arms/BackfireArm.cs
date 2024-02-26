using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackfireArm : PlayerArm {

    public override void Awake() {
        bulletType = BulletType.Grenade;
        armPart = ArmPart.Backfire;
        partRarity = PartRarity.Epic;
    }
    public override void PartFire(Vector3 mousePos) {
        if (cdCounter <= 0 && player.currentAmmo >= ammoUsage && player.currentFuel >= fuelUsage) {
            player.UpdateAmmo(-ammoUsage);
            player.UpdateFuel(-fuelUsage);
            cdCounter = cooldown;
            PrefabManager.SpawnAndFire(bulletType, transform.position, mousePos, gameObject.tag);
        }
    }

}
