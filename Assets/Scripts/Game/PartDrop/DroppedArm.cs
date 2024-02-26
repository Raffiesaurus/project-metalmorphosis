using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedArm : DroppablePart {

    private ArmPart armPart;

    public override void FormItem() {
        base.FormItem();

        if (partRarity == PartRarity.Common) {
            // Lucky Scalpel, Lefty, Righty, Nail Gun
            int randomPart = Random.Range(0, 4);
            if (randomPart == 0) {
                armPart = ArmPart.Lucky_Scalpel;
                partName = "Lucky Scalpel";
            } else if (randomPart == 1) {
                armPart = ArmPart.Lefty;
                partName = "Lefty";
            } else if (randomPart == 2) {
                armPart = ArmPart.Righty;
                partName = "Righty";
            } else {
                armPart = ArmPart.Nail_Gun;
                partName = "Nail Gun";
            }

        } else if (partRarity == PartRarity.Rare) {
            // Chainsaw, brrrr, Bat
            int randomPart = Random.Range(0, 3);
            if (randomPart == 0) {
                armPart = ArmPart.Chainsaw;
                partName = "Chainsaw";
            } else if (randomPart == 1) {
                armPart = ArmPart.Brrrrr;
                partName = "Brrrrrrrr";
            } else {
                armPart = ArmPart.Bat;
                partName = "Bat";
            }

        } else {
            // Judy, Punch, Backfire
            int randomPart = Random.Range(0, 3);
            if (randomPart == 0) {
                armPart = ArmPart.Judy;
                partName = "Judy";
            } else if (randomPart == 1) {
                armPart = ArmPart.Punch;
                partName = "Punch";
            } else {
                armPart = ArmPart.Backfire;
                partName = "Backfire";
            }

        }

    }

    public override void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("player")) {
            rb.bodyType = RigidbodyType2D.Static;
            PartDropData uiData = new PartDropData();
            uiData.partName = partName;
            uiData.partDescription = "description";
            uiData.partRarity = "Common";
            uiData.partType = "Left";
            uiData.partImage = assignedImage;
            PrefabManager.ShowPickupUI(uiData, gameObject);
        }
    }

    public override void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("player")) {
            rb.bodyType = RigidbodyType2D.Dynamic;
            PrefabManager.HidePickupUI();
        }
    }

}
