using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsawArm : PlayerArm {

    public override void Awake() {
        bulletType = BulletType.None;
        armPart = ArmPart.Chainsaw;
        partRarity = PartRarity.Rare;
    }

    public override void PartFire(Vector3 mousePos) {
        if (cdCounter <= 0 && player.currentFuel >= fuelUsage) {
            player.UpdateFuel(-fuelUsage);
            player.DealMeleeDamage(meleeDamage);
        }
    }

}
