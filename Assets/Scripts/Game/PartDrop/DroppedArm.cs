using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedArm : DroppablePart {

    PartDropData uiData;

    public override void FormItem() {
        base.FormItem();
        uiData = new PartDropData();
        uiData.partImage = assignedImage;
        if (partRarity == PartRarity.Common) {
            // Lucky Scalpel, Lefty, Righty, Nail Gun
            int randomPart = Random.Range(0, 4);
            uiData.partRarity = "Common";
            if (randomPart == 0) {
                uiData.partName = "Lucky Scalpel";
                uiData.leftArm = ArmPart.Lucky_Scalpel;
                uiData.partType = "Left";
                uiData.partDescription = "Description";
            } else if (randomPart == 1) {
                uiData.partName = "Lefty";
                uiData.leftArm = ArmPart.Lefty;
                uiData.partType = "Left";
                uiData.partDescription = "Description";
            } else if (randomPart == 2) {
                uiData.partName = "Righty";
                uiData.rightArm = ArmPart.Righty;
                uiData.partType = "Right";
                uiData.partDescription = "Description";
            } else {
                uiData.partName = "Nail Gun";
                uiData.rightArm = ArmPart.Nail_Gun;
                uiData.partType = "Right";
                uiData.partDescription = "Description";
            }

        } else if (partRarity == PartRarity.Rare) {
            // Chainsaw, brrrr, Bat
            uiData.partRarity = "Rare";
            int randomPart = Random.Range(0, 3);
            if (randomPart == 0) {
                uiData.partName = "Chainsaw";
                uiData.leftArm = ArmPart.Chainsaw;
                uiData.partType = "Left";
                uiData.partDescription = "Description";
            } else if (randomPart == 1) {
                uiData.partName = "Blitzburst";
                uiData.rightArm = ArmPart.Blitzburst;
                uiData.partType = "Right";
                uiData.partDescription = "Description";
            } else {
                uiData.partName = "Bat";
                uiData.leftArm = ArmPart.Bat;
                uiData.partType = "Left";
                uiData.partDescription = "Description";
            }

        } else {
            // Judy, Punch, Backfire
            uiData.partRarity = "Epic";
            int randomPart = Random.Range(0, 3);
            if (randomPart == 0) {
                uiData.partName = "Judy";
                uiData.rightArm = ArmPart.Judy;
                uiData.partType = "Right";
                uiData.partDescription = "Description";
            } else if (randomPart == 1) {
                uiData.partName = "Punch";
                uiData.leftArm = ArmPart.Punch;
                uiData.partType = "Left";
                uiData.partDescription = "Description";
            } else {
                uiData.partName = "Backfire";
                uiData.leftArm = ArmPart.Backfire;
                uiData.partType = "Left";
                uiData.partDescription = "Description";
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
