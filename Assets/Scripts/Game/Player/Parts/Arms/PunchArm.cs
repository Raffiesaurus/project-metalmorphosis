using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchArm : PlayerArm {

    public override void Awake() {
        bulletType = BulletType.None;
        armPart = ArmPart.Punch;
        partRarity = PartRarity.Epic;

        cooldown = 1.25f;
        meleeDamage = 40;
        fuelUsage = 35;
    }

    public override void PartFire(Vector3 mousePos, Vector3 spawnPoint) {
        if (cdCounter <= 0 && player.currentFuel >= fuelUsage) {
            cdCounter = cooldown;
            player.UpdateFuel(-fuelUsage);
            player.DealMeleeDamage(meleeDamage * ((100 + player.meleeDmgBonus) / 100));
        }
    }

}
