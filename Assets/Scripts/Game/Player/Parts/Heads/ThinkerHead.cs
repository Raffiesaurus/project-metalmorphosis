using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkerHead : PlayerHead {
    public override void Awake() {
        headPart = HeadPart.Thinker;
        partRarity = PartRarity.Common;

        healthBoost = -25;
        ammoBoost = 0;
        fuelBoost = 0;
        speedBoost = 0.5f;
        meleeDmgBoost = 0;
        rangeDmgBoost = 0;
        hpGain = 0;
        ammoLoss = 0;
        swapAmmoHp = false;
        bulletBounce = false;
        oneHitMode = false;
        returnDmg = false;
        returnDmgAmount = 0.0f;
    }
}
