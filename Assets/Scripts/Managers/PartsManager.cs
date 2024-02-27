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

    private void Awake() {
        equippedLeftArm = ArmPart.Lucky_Scalpel;
        equippedRightArm = ArmPart.Nail_Gun;
        if (instance == null) {
            instance = this;
        }
    }

}
