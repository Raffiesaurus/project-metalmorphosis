using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedArm : DroppablePart {

    PartDropData uiData;

    public override void FormItem() {
        base.FormItem();
        uiData = new PartDropData();
        uiData.fuel = false;
        uiData.ammo = false;
        uiData.partImage = assignedImage;
        if (partRarity == PartRarity.Unassigned) {
            int partRandom = Random.Range(0, 10);
            if (partRandom <= 4) {
                partRarity = PartRarity.Common;
            } else if (partRandom <= 7) {
                partRarity = PartRarity.Rare;
            } else {
                partRarity = PartRarity.Epic;
            }
        }
        if (partRarity == PartRarity.Common) {
            // Lucky Scalpel, Lefty, Righty, Nail Gun
            int randomPart = Random.Range(0, 4);
            uiData.partRarity = "Rarity: Common";
            if (randomPart == 0) {
                uiData.fuel = true;
                uiData.partName = "Lucky Scalpel";
                uiData.leftArm = ArmPart.Lucky_Scalpel;
                uiData.partType = "Left Arm";
                uiData.partDescription = "Low damage, low speed.";
            } else if (randomPart == 1) {
                uiData.partName = "Lefty";
                uiData.leftArm = ArmPart.Lefty;
                uiData.partType = "Left Arm";
                uiData.partDescription = "Blocks 50% damage.";
            } else if (randomPart == 2) {
                uiData.partName = "Righty";
                uiData.rightArm = ArmPart.Righty;
                uiData.partType = "Right Arm";
                uiData.partDescription = "Blocks 50% damage.";
            } else {
                uiData.ammo = true;
                uiData.partName = "Nail Gun";
                uiData.rightArm = ArmPart.Nail_Gun;
                uiData.partType = "Right Arm";
                uiData.partDescription = "Low fire rate, low damage";
            }

        } else if (partRarity == PartRarity.Rare) {
            // Chainsaw, brrrr, Bat
            uiData.partRarity = "Rarity: Rare";
            int randomPart = Random.Range(0, 3);
            if (randomPart == 0) {
                uiData.fuel = true;
                uiData.partName = "Chainsaw";
                uiData.leftArm = ArmPart.Chainsaw;
                uiData.partType = "Left Arm";
                uiData.partDescription = "High damage, high fuel usage.";
            } else if (randomPart == 1) {
                uiData.ammo = true;
                uiData.partName = "Blitzburst";
                uiData.rightArm = ArmPart.Blitzburst;
                uiData.partType = "Right Arm";
                uiData.partDescription = "High fire rate, low damage.";
            } else {
                uiData.partName = "Bat";
                uiData.leftArm = ArmPart.Bat;
                uiData.partType = "Left Arm";
                uiData.partDescription = "Low speed, low attack.";
            }

        } else {
            // Judy, Punch, Backfire
            uiData.partRarity = "Rarity: Epic";
            int randomPart = Random.Range(0, 3);
            if (randomPart == 0) {
                uiData.partName = "Judy";
                uiData.rightArm = ArmPart.Judy;
                uiData.partType = "Right Arm";
                uiData.partDescription = "Quick melee attacks.";
            } else if (randomPart == 1) {
                uiData.partName = "Punch";
                uiData.leftArm = ArmPart.Punch;
                uiData.partType = "Left Arm";
                uiData.partDescription = "High melee damage, high fuel usage.";
            } else {
                uiData.fuel = true;
                uiData.partName = "Backfire";
                uiData.leftArm = ArmPart.Backfire;
                uiData.partType = "Left Arm";
                uiData.partDescription = "Lobs a grenade, high ammo, fuel usage.";
            }

        }
    }

    public override void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("player") && LevelManager.RemainingEnemies <= 0) {
            rb.bodyType = RigidbodyType2D.Static;
            PrefabManager.ShowPickupUI(uiData, gameObject);
        }
    }

    public override void OnCollisionExit2D(Collision2D collision) {
        base.OnCollisionExit2D(collision);
        if (collision.gameObject.CompareTag("player")) {
            rb.bodyType = RigidbodyType2D.Dynamic;
            PrefabManager.HidePickupUI();
        }
    }

}
