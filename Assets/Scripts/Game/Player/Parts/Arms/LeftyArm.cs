using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftyArm : PlayerArm {

    public override void Awake() {
        bulletType = BulletType.None;
        armPart = ArmPart.Lefty;
        partRarity = PartRarity.Common;
    }

    public override void PartFire(Vector3 mousePos, Vector3 spawnPoint) {
        player.playerAnimator.SetTrigger("LeftArmMelee");
        player.UpdateDamageReductionPercentage(50);
    }
}
