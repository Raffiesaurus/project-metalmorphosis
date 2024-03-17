public class DumptruckLeg : PlayerLeg {
    public override void Awake() {
        legPart = LegPart.Dumptruck;
        partRarity = PartRarity.Rare;

        healthUp = 50;
        ammoUp = 0;
        fuelUp = 0;
        speedUp = 1;
    }
}
