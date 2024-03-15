using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudyArm : PlayerArm {

    public override void Awake() {
        bulletType = BulletType.None;
        armPart = ArmPart.Judy;
        partRarity = PartRarity.Epic;

        cooldown = 1;
        meleeDamage = 10;
    }

    public override void PartFire(Vector3 mousePos) {
        if (cdCounter <= 0) {
            cdCounter = cooldown;
            player.DealMeleeDamage(meleeDamage);
        }
    }

}