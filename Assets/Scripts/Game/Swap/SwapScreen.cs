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

    public string GetLegName(LegPart legNum) {
        switch (legNum) {
            case LegPart.Overclocked:
                return "Overclocked";
            case LegPart.Heavy_Artillery:
                return "Heavy Artillery";
            case LegPart.Plain:
                return "Plain";
            case LegPart.Gassy:
                return "Gassy";
            case LegPart.Dumptruck:
                return "Dumptruck";
            default:
                return "Uhoh";
        }
    }

    public void Update() {

        if (Input.GetKeyDown(KeyCode.I)) {
            // Installing Part
            if (partData.partType == "Left") {
                PartsManager.EquippedLeftArm = partData.leftArm;
                GameUIManager.ShowNotification("Installed " + partData.partName + " in " + partData.partType + " arm.");
            } else if (partData.partType == "Right") {
                PartsManager.EquippedRightArm = partData.rightArm;
                GameUIManager.ShowNotification("Installed " + partData.partName + " in " + partData.partType + " arm.");
            } else if (partData.partType == "Legs") {
                PartsManager.EquippedLeg = partData.legs;
                GameUIManager.ShowNotification("Installed " + partData.partName + " in legs.");
            }

        } else if (Input.GetKeyDown(KeyCode.U)) {
            // Uninstalling Equipped Part
            if (partData.partType == "Left") {
                uninstalledPart = GetArmName(PartsManager.EquippedLeftArm);
                PartsManager.EquippedLeftArm = ArmPart.Lucky_Scalpel;
                GameUIManager.ShowNotification("Uninstalled " + uninstalledPart + " from " + partData.partType + " arm.");
            } else if (partData.partType == "Right") {
                uninstalledPart = GetArmName(PartsManager.EquippedRightArm);
                PartsManager.EquippedRightArm = ArmPart.Nail_Gun;
                GameUIManager.ShowNotification("Uninstalled " + uninstalledPart + " from " + partData.partType + " arm.");
            } else if (partData.partType == "Legs") {
                uninstalledPart = GetLegName(PartsManager.EquippedLeg);
                PartsManager.EquippedLeg = LegPart.Plain;
                GameUIManager.ShowNotification("Uninstalled " + uninstalledPart + " from legs.");
            }

        } else if (Input.GetKeyDown(KeyCode.P)) {
            GameUIManager.SwitchToInGame();
        }

    }
}
