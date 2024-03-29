public class OverclockedLeg : PlayerLeg {
    public override void Awake() {
        legPart = LegPart.Overclocked;
        partRarity = PartRarity.Common;

        healthBoost = 0;
        ammoBoost = 0;
        fuelBoost = 0;
        speedBoost = 3;
    }
}
