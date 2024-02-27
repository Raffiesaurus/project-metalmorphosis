using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapScreen : MonoBehaviour {

    private PartDropData partData;
    private string uninstalledPart;

    public void Setup(PartDropData data) {
        partData = data;


    }

    public string GetArmName(ArmPart armNum) {
        switch (armNum) {
            case ArmPart.Backfire:
                return "Backfire";
            case ArmPart.Punch:
                return "Punch";
            case ArmPart.Chainsaw:
                return "Chainsaw";
            case ArmPart.Bat:
                return "Bat";
            case ArmPart.Lucky_Scalpel:
                return "Lucky Scalpel";
            case ArmPart.Lefty:
                return "Lefty";
            case ArmPart.Judy:
                return "Judy";
            case ArmPart.Righty:
                return "Rigty";
            case ArmPart.Nail_Gun:
                return "Nail Gun";
            case ArmPart.Blitzburst:
                return "Blitzburst";
            default:
                return "Uhoh";
        }
    }

    public void Update() {

        if (Input.GetKeyDown(KeyCode.I)) {
            // Installing Part
            if (partData.partType == "Left") {
                PartsManager.EquippedLeftArm = partData.leftArm;
            } else if (partData.partType == "Right") {
                Debug.Log("NEW PART : " + partData.rightArm);
                PartsManager.EquippedRightArm = partData.rightArm;
            }

            GameUIManager.ShowNotification("Installed " + partData.partName + " in " + partData.partType + " arm.");
        } else if (Input.GetKeyDown(KeyCode.U)) {
            // Uninstalling Equipped Part
            if (partData.partType == "Left") {
                uninstalledPart = GetArmName(PartsManager.EquippedLeftArm);
                PartsManager.EquippedLeftArm = ArmPart.Lucky_Scalpel;
            } else if (partData.partType == "Right") {
                uninstalledPart = GetArmName(PartsManager.EquippedRightArm);
                PartsManager.EquippedRightArm = ArmPart.Nail_Gun;
            }
            GameUIManager.ShowNotification("Uninstalled " + uninstalledPart + " from " + partData.partType + " arm.");

        } else if (Input.GetKeyDown(KeyCode.P)) {
            GameUIManager.SwitchToInGame();
        }



    }
}
