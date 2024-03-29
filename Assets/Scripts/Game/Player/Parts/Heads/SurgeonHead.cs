using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgeonHead : PlayerHead {
    public override void Awake() {
        headPart = HeadPart.Surgeon;
        partRarity = PartRarity.Epic;

        healthBoost = 0;
        ammoBoost = 0;
        fuelBoost = 0;
        speedBoost = 0;
        meleeDmgBoost = 0;
        rangeDmgBoost = 0;
        hpGain = 25;
        ammoLoss = -25;
        fuelLoss = -10;
        swapAmmoHp = true;
        bulletBounce = false;
        oneHitMode = false;
        returnDmg = false;
        returnDmgAmount = 0.0f;
    }
}
