public class DumptruckLeg : PlayerLeg {
    public override void Awake() {
        legPart = LegPart.Dumptruck;
        partRarity = PartRarity.Rare;

        healthBoost = 50;
        ammoBoost = 0;
        fuelBoost = 0;
        speedBoost = 1;
    }
}
