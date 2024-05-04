using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsawArm : PlayerArm {

    public override void Awake() {
        bulletType = BulletType.None;
        armPart = ArmPart.Chainsaw;
        partRarity = PartRarity.Rare;

        cooldown = 1;
        meleeDamage = 50;
        fuelUsage = 40;
    }

    public override void PartFire(Vector3 mousePos, Vector3 spawnPoint) {
        if (cdCounter <= 0 && player.currentFuel >= fuelUsage) {
            cdCounter = cooldown;
            AudioManager.PlaySFX(AudioClips.MeleeHit);
            player.UpdateFuel(-fuelUsage);
            player.playerAnimator.SetTrigger("LeftArmMelee");
            player.DealMeleeDamage(meleeDamage * ((100 + player.meleeDmgBonus) / 100));
        }
    }

}
