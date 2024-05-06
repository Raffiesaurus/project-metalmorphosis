using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyScalpelArm : PlayerArm {

    public override void Awake() {
        bulletType = BulletType.None;
        armPart = ArmPart.Lucky_Scalpel;
        partRarity = PartRarity.Common;

        cooldown = 3;
        meleeDamage = 20;
        fuelUsage = 20;
    }


    public override void PartFire(Vector3 mousePos, Vector3 spawnPoint) {
        if (cdCounter <= 0 && player.currentFuel >= fuelUsage) {
            cdCounter = cooldown;
            player.UpdateFuel(-fuelUsage);
            AudioManager.PlaySFX(AudioClips.MeleeHit);
            player.playerAnimator.SetTrigger("LeftArmMelee");
            player.DealMeleeDamage(meleeDamage * ((100 + player.meleeDmgBonus) / 100));
        }
    }
}
