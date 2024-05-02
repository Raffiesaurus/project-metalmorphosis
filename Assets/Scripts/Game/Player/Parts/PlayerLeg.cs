using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeg : PlayerParts {
    [SerializeField] public LegPart legPart = LegPart.Plain;

    [SerializeField] public int ammoBoost = 0;
    [SerializeField] public float healthBoost = 0.0f;
    [SerializeField] public float fuelBoost = 0.0f;
    [SerializeField] public float speedBoost = 1.0f;

    [SerializeField] public SpriteRenderer upperLegImgR = null;
    [SerializeField] public SpriteRenderer lowerLegImgR = null;
    [SerializeField] public SpriteRenderer footImgR = null;

    [SerializeField] public SpriteRenderer upperLegImgL = null;
    [SerializeField] public SpriteRenderer lowerLegImgL = null;
    [SerializeField] public SpriteRenderer footImgL = null;

    public virtual void Awake() {

    }

    public PlayerLeg AssignScript() {
        PlayerLeg legAdded = null;
        switch (legPart) {

            case LegPart.Plain:
                legAdded = gameObject.AddComponent<PlainLeg>();
                break;

            case LegPart.Dumptruck:
                legAdded = gameObject.AddComponent<DumptruckLeg>();
                break;

            case LegPart.Overclocked:
                legAdded = gameObject.AddComponent<OverclockedLeg>();
                break;

            case LegPart.Gassy:
                legAdded = gameObject.AddComponent<GassyLeg>();
                break;

            case LegPart.Heavy_Artillery:
                legAdded = gameObject.AddComponent<HeavyArtilleryLeg>();
                break;
        }
        legAdded.upperLegImgR = upperLegImgR;
        legAdded.lowerLegImgR = lowerLegImgR;
        legAdded.footImgR = footImgR;
        legAdded.upperLegImgL = upperLegImgL;
        legAdded.lowerLegImgL = lowerLegImgL;
        legAdded.footImgL = footImgL;
        Destroy(this);
        return legAdded;
    }

    public virtual void Update() {

    }

    public override void PartInstall() {

    }

    public override void PartUninstall() {

    }

    public void UpdateSprite(Sprite upperLeg, Sprite lowerLeg, Sprite foot) {
        upperLegImgR.sprite = upperLegImgL.sprite = upperLeg;
        lowerLegImgR.sprite = lowerLegImgL.sprite = lowerLeg;
        footImgR.sprite = footImgL.sprite = foot;
    }
}
