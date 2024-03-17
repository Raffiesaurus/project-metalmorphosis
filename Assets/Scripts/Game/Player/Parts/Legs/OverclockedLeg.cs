public class OverclockedLeg : PlayerLeg {
    public override void Awake() {
        legPart = LegPart.Overclocked;
        partRarity = PartRarity.Common;

        healthUp = 0;
        ammoUp = 0;
        fuelUp = 0;
        speedUp = 10;
    }
}
