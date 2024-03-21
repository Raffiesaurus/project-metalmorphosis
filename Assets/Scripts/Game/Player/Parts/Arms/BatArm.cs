using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatArm : PlayerArm {

    private int comboCount = 0;
    private int maxComboCount = 3;

    public override void Awake() {
        bulletType = BulletType.None;
        armPart = ArmPart.Bat;
        partRarity = PartRarity.Rare;

        cooldown = 0.5f;
        meleeDamage = 15;
    }

    public override void PartFire(Vector3 mousePos, Vector3 spawnPoint) {
        if (cdCounter <= 0) {
            CancelInvoke();
            cdCounter = cooldown;
            comboCount++;
            Invoke(nameof(ResetCombo), 1.0f);
            player.DealMeleeDamage(meleeDamage * comboCount);
            if (comboCount >= maxComboCount) {
                ResetCombo();
                CancelInvoke();
            }
        }
    }

    private void ResetCombo() {
        comboCount = 0;
    }
}
