using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightyArm : PlayerArm {

    public override void Awake() {
        bulletType = BulletType.None;
        armPart = ArmPart.Righty;
        partRarity = PartRarity.Common;
    }

    public override void PartFire(Vector3 mousePos) {
        player.UpdateDamageReductionPercentage(50);
    }
}