using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnifeyeHead : PlayerHead {
    public override void Awake() {
        headPart = HeadPart.Magnifeye;
        partRarity = PartRarity.Common;

        healthBoost = 0;
        ammoBoost = 0;
        fuelBoost = 0;
        speedBoost = 0;
        meleeDmgBoost = -25;
        rangeDmgBoost = 25;
        hpGain = 0;
        ammoLoss = 0;
        swapAmmoHp = false;
        bulletBounce = false;
        oneHitMode = false;
        returnDmg = false;
        returnDmgAmount = 0.0f;
    }
}