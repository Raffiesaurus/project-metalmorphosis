using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyScalpelArm : PlayerArm {

    public override void Awake() {
        bulletType = BulletType.None;
        armPart = ArmPart.Lucky_Scalpel;
        partRarity = PartRarity.Common;

        cooldown = 3;
        meleeDamage = 10;
        fuelUsage = 20;
    }


    public override void PartFire(Vector3 mousePos) {
        if (cdCounter <= 0 && player.currentFuel >= fuelUsage) {
            cdCounter = cooldown;
            player.UpdateFuel(-fuelUsage);
            player.DealMeleeDamage(meleeDamage);
        }
    }
}
