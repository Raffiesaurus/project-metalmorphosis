using UnityEngine;

public class HeavyArtilleryLeg : PlayerLeg {
    public override void Awake() {
        legPart = LegPart.Heavy_Artillery;
        partRarity = PartRarity.Common;

        healthBoost = 0;
        ammoBoost = 25;
        fuelBoost = 0;
        speedBoost = 1;
    }
}