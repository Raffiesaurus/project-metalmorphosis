using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishbowlHead : PlayerHead {
    public override void Awake() {
        headPart = HeadPart.Fishbowl;
        partRarity = PartRarity.Epic;

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
        oneHitMode = true;
        returnDmg = false;
        returnDmgAmount = 0.0f;
    }
}
