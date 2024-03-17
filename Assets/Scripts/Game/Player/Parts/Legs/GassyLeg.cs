public class GassyLeg : PlayerLeg {
    public override void Awake() {
        legPart = LegPart.Gassy;
        partRarity = PartRarity.Common;

        healthUp = 0;
        ammoUp = 0;
        fuelUp = 50;
        speedUp = 1;
    }
}
