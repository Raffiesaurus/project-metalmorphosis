using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarsightedHead : PlayerHead {
    public override void Awake() {
        headPart = HeadPart.Farsighted;
        partRarity = PartRarity.Rare;

        healthBoost = 0;
        ammoBoost = 0;
        fuelBoost = 0;
        speedBoost = 0;
        meleeDmgBoost = -50;
        rangeDmgBoost = 50;
        hpGain = 0;
        ammoLoss = 0;
        swapAmmoHp = false;
        bulletBounce = false;
        oneHitMode = false;
        returnDmg = false;
        returnDmgAmount = 0.0f;
    }
}
