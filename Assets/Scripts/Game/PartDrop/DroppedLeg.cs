using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedLeg : DroppablePart {

    PartDropData uiData;

    public override void FormItem() {
        base.FormItem();
        uiData = new PartDropData();
        uiData.partType = "Legs";
        uiData.partImage = assignedImage;
        if (partRarity == PartRarity.Unassigned) {
            int partRandom = Random.Range(0, 10);
            if (partRandom <= 6) {
                partRarity = PartRarity.Common;
            } else {
                partRarity = PartRarity.Rare;
            }
        }
        if (partRarity == PartRarity.Common) {
            uiData.partRarity = "Common";
            int randomPart = Random.Range(0, 3);
            if (randomPart == 0) {
                uiData.partName = "Gassy";
                uiData.legs = LegPart.Gassy;
                uiData.partDescription = "Description";
            } else if (randomPart == 1) {
                uiData.partName = "Heavy Artillery";
                uiData.legs = LegPart.Heavy_Artillery;
                uiData.partDescription = "Description";
            } else {
                uiData.partName = "Overclocked";
                uiData.legs = LegPart.Overclocked;
                uiData.partDescription = "Description";
            }

        } else {
            uiData.partRarity = "Rare";
            uiData.partName = "Dumptruck";
            uiData.legs = LegPart.Dumptruck;
            uiData.partDescription = "Description";
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
