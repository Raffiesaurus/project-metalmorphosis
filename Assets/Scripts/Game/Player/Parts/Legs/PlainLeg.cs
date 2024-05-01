public class PlainLeg : PlayerLeg {
    public override void Awake() {
        legPart = LegPart.Plain;
        partRarity = PartRarity.Common;

        healthBoost = 0;
        ammoBoost = 0;
        fuelBoost = 0;
        speedBoost = 1;
    }
}
