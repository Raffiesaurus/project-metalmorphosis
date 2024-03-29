public class GassyLeg : PlayerLeg {
    public override void Awake() {
        legPart = LegPart.Gassy;
        partRarity = PartRarity.Common;

        healthBoost = 0;
        ammoBoost = 0;
        fuelBoost = 50;
        speedBoost = 1;
    }
}
