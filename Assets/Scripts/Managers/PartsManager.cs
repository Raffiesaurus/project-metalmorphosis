using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsManager : MonoBehaviour {

    private static PartsManager instance = null;

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

    private void Awake() {
        equippedLeftArm = ArmPart.Backfire;
        equippedRightArm = ArmPart.Blitzburst;
        equippedLeg = LegPart.Plain;
        equippedHead = HeadPart.Boundman;
        if (instance == null) {
            instance = this;
        }
    }

}
