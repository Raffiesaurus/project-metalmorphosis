using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsManager : MonoBehaviour {

    private static PartsManager instance = null;

    [SerializeField] private Sprite[] headSprites;
    [SerializeField] private Sprite[] upperArmSprites;
    [SerializeField] private Sprite[] lowerArmSprites;
    [SerializeField] private Sprite[] upperLegSprites;
    [SerializeField] private Sprite[] lowerLegSprites;
    [SerializeField] private Sprite[] footSprites;

    private ArmPart equippedLeftArm;
    public static ArmPart EquippedLeftArm {
        get {
            return instance.equippedLeftArm;
        }
        set {
            instance.equippedLeftArm = value;
            GameManager.GetPlayer().UpdateEquippedItems();
        }
    }

    private ArmPart equippedRightArm;
    public static ArmPart EquippedRightArm {
        get {
            return instance.equippedRightArm;
        }
        set {
            instance.equippedRightArm = value;
            GameManager.GetPlayer().UpdateEquippedItems();
        }
    }

    private LegPart equippedLeg;
    public static LegPart EquippedLeg {
        get {
            return instance.equippedLeg;
        }
        set {
            instance.equippedLeg = value;
            GameManager.GetPlayer().UpdateEquippedItems();
        }
    }

    private HeadPart equippedHead;
    public static HeadPart EquippedHead {
        get {
            return instance.equippedHead;
        }
        set {
            instance.equippedHead = value;
            GameManager.GetPlayer().UpdateEquippedItems();
        }
    }

    public static List<Sprite> GetArmSprites(ArmPart arm) {
        List<Sprite> armSprites = new List<Sprite>();

        switch (arm) {
            case ArmPart.Backfire:
                armSprites.Add(instance.upperArmSprites[0]);
                armSprites.Add(instance.lowerArmSprites[0]);
                break;
            case ArmPart.Punch:
                armSprites.Add(instance.upperArmSprites[1]);
                armSprites.Add(instance.lowerArmSprites[1]);
                break;
            case ArmPart.Chainsaw:
                armSprites.Add(instance.upperArmSprites[2]);
                armSprites.Add(instance.lowerArmSprites[2]);
                break;
            case ArmPart.Bat:
                armSprites.Add(instance.upperArmSprites[3]);
                armSprites.Add(instance.lowerArmSprites[3]);
                break;
            case ArmPart.Lucky_Scalpel:
                armSprites.Add(instance.upperArmSprites[4]);
                armSprites.Add(instance.lowerArmSprites[4]);
                break;
            case ArmPart.Lefty:
                armSprites.Add(instance.upperArmSprites[5]);
                armSprites.Add(instance.lowerArmSprites[5]);
                break;
            case ArmPart.Judy:
                armSprites.Add(instance.upperArmSprites[6]);
                armSprites.Add(instance.lowerArmSprites[6]);
                break;
            case ArmPart.Righty:
                armSprites.Add(instance.upperArmSprites[7]);
                armSprites.Add(instance.lowerArmSprites[7]);
                break;
            case ArmPart.Nail_Gun:
                armSprites.Add(instance.upperArmSprites[8]);
                armSprites.Add(instance.lowerArmSprites[8]);
                break;
            case ArmPart.Blitzburst:
                armSprites.Add(instance.upperArmSprites[9]);
                armSprites.Add(instance.lowerArmSprites[9]);
                break;
            default:
                break;
        }

        return armSprites;
    }

    public static List<Sprite> GetLegSprites(LegPart leg) {
        List<Sprite> legSprites = new List<Sprite>();

        switch (leg) {
            case LegPart.Dumptruck:
                legSprites.Add(instance.upperLegSprites[0]);
                legSprites.Add(instance.lowerLegSprites[0]);
                legSprites.Add(instance.footSprites[0]);
                break;
            case LegPart.Heavy_Artillery:
                legSprites.Add(instance.upperLegSprites[1]);
                legSprites.Add(instance.lowerLegSprites[1]);
                legSprites.Add(instance.footSprites[1]);
                break;
            case LegPart.Gassy:
                legSprites.Add(instance.upperLegSprites[2]);
                legSprites.Add(instance.lowerLegSprites[2]);
                legSprites.Add(instance.footSprites[2]);
                break;
            case LegPart.Overclocked:
                legSprites.Add(instance.upperLegSprites[3]);
                legSprites.Add(instance.lowerLegSprites[3]);
                legSprites.Add(instance.footSprites[3]);
                break;
            case LegPart.Plain:
                legSprites.Add(instance.upperLegSprites[4]);
                legSprites.Add(instance.lowerLegSprites[4]);
                legSprites.Add(instance.footSprites[4]);
                break;
            default:
                break;
        }

        return legSprites;
    }

    public static List<Sprite> GetHeadSprites(HeadPart head) {
        List<Sprite> headSprites = new List<Sprite>();

        switch (head) {
            case HeadPart.Fishbowl:
                headSprites.Add(instance.headSprites[0]);
                break;
            case HeadPart.Surgeon:
                headSprites.Add(instance.headSprites[1]);
                break;
            case HeadPart.Boundman:
                headSprites.Add(instance.headSprites[2]);
                break;
            case HeadPart.Meathead:
                headSprites.Add(instance.headSprites[3]);
                break;
            case HeadPart.Pinhead:
                headSprites.Add(instance.headSprites[4]);
                break;
            case HeadPart.Neurons:
                headSprites.Add(instance.headSprites[5]);
                break;
            case HeadPart.Farsighted:
                headSprites.Add(instance.headSprites[6]);
                break;
            case HeadPart.Nearsighted:
                headSprites.Add(instance.headSprites[7]);
                break;
            case HeadPart.Thinker:
                headSprites.Add(instance.headSprites[8]);
                break;
            case HeadPart.Magnifeye:
                headSprites.Add(instance.headSprites[9]);
                break;
            case HeadPart.Minimifeye:
                headSprites.Add(instance.headSprites[10]);
                break;
            case HeadPart.Plain:
                headSprites.Add(instance.headSprites[11]);
                break;
            default:
                break;
        }

        return headSprites;
    }

    private void Awake() {
        equippedLeftArm = ArmPart.Backfire;
        equippedRightArm = ArmPart.Blitzburst;
        equippedLeg = LegPart.Plain;
        equippedHead = HeadPart.Plain;
        if (instance == null) {
            instance = this;
        }
    }

}
