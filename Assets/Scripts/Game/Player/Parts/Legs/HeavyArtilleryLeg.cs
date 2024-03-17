using UnityEngine;

public class HeavyArtilleryLeg : PlayerLeg {
    public override void Awake() {
        legPart = LegPart.Heavy_Artillery;
        partRarity = PartRarity.Common;

        healthUp = 0;
        ammoUp = 25;
        fuelUp = 0;
        speedUp = 1;
        Debug.Log("Hih i " + this);
    }
}
