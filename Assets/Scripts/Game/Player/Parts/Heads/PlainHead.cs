using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlainHead : PlayerHead {
    public override void Awake() {
        headPart = HeadPart.Plain;
        partRarity = PartRarity.Common;

        healthChange = 0;
        ammoChange = 0;
        fuelChange = 0;
        speedChange = 0;
        meleeDmgChange = 0;
        rangeDmgChange = 0;
        hpGain = 0;
        ammoLoss = 0;
        swapAmmoHp = false;
        bulletBounce = false;
        oneHitMode = false;
        returnDmg = false;
        returnDmgAmount = 0.0f;
    }
}
