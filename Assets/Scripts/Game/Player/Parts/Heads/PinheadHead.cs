using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinheadHead : PlayerHead {
    public override void Awake() {
        headPart = HeadPart.Pinhead;
        partRarity = PartRarity.Rare;

        healthBoost = 0;
        ammoBoost = 0;
        fuelBoost = 0;
        speedBoost = 0;
        meleeDmgBoost = 0;
        rangeDmgBoost = 0;
        hpGain = 0;
        ammoLoss = 0;
        swapAmmoHp = false;
        bulletBounce = false;
        oneHitMode = false;
        returnDmg = true;
        returnDmgAmount = 25.0f;
    }
}
