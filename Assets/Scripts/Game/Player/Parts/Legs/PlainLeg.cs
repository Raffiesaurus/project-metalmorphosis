public class PlainLeg : PlayerLeg {
    public override void Awake() {
        legPart = LegPart.Plain;
        partRarity = PartRarity.Common;

        healthUp = 0;
        ammoUp = 0;
        fuelUp = 0;
        speedUp = 1;
    }
}
