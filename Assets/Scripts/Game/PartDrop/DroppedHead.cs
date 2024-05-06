using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedHead : DroppablePart {

    PartDropData uiData;

    public override void FormItem() {
        base.FormItem();
        uiData = new PartDropData();
        uiData.fuel = false;
        uiData.ammo = false;
        uiData.partType = "Head";
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
            int randomPart = Random.Range(0, 3);
            uiData.partRarity = "Rarity: Common";
            if (randomPart == 0) {
                uiData.partName = "Thinker";
                uiData.head = HeadPart.Thinker;
                uiData.partType = "Head";
                uiData.partDescription = "Increased speed, reduced HP.";
            } else if (randomPart == 1) {
                uiData.partName = "Magnifeye";
                uiData.head = HeadPart.Magnifeye;
                uiData.partType = "Head";
                uiData.partDescription = "Increased ranged damage, reduced melee damage.";
            } else {
                uiData.partName = "Minimifeye";
                uiData.head = HeadPart.Minimifeye;
                uiData.partType = "Head";
                uiData.partDescription = "Increased melee damage, reduced ranged damage.";
            }

        } else if (partRarity == PartRarity.Rare) {
            uiData.partRarity = "Rarity: Rare";
            int randomPart = Random.Range(0, 5);
            if (randomPart == 0) {
                uiData.partName = "Meathead";
                uiData.head = HeadPart.Meathead;
                uiData.partType = "Head";
                uiData.partDescription = "Greatly increases all damage dealt, reduces max HP.";
            } else if (randomPart == 1) {
                uiData.partName = "Pinhead";
                uiData.head = HeadPart.Pinhead;
                uiData.partType = "Head";
                uiData.partDescription = "Deals return damage on hit.";
            } else if (randomPart == 2) {
                uiData.partName = "Farsighted";
                uiData.head = HeadPart.Farsighted;
                uiData.partType = "Head";
                uiData.partDescription = "Greatly increases ranged damage, reduced melee damage.";
            } else if (randomPart == 3) {
                uiData.partName = "Nearsighted";
                uiData.head = HeadPart.Nearsighted;
                uiData.partType = "Head";
                uiData.partDescription = "Greatly increases melee damage, reduced ranged damage.";
            } else if (randomPart == 4) {
                uiData.partName = "Neurons";
                uiData.head = HeadPart.Neurons;
                uiData.partType = "Head";
                uiData.partDescription = "Greatly increased speed.";
            }

        } else {
            uiData.partRarity = "Rarity: Epic";
            int randomPart = Random.Range(0, 3);
            if (randomPart == 0) {
                uiData.partName = "Fishbowl";
                uiData.head = HeadPart.Fishbowl;
                uiData.partType = "Head";
                uiData.partDescription = "Player and enemies are set to 1 HP.";
            } else if (randomPart == 1) {
                uiData.partName = "Surgeon";
                uiData.head = HeadPart.Surgeon;
                uiData.partType = "Head";
                uiData.partDescription = "Converts 15 ammo and fuel to 15 HP.";
            } else {
                uiData.partName = "Boundman";
                uiData.head = HeadPart.Boundman;
                uiData.partType = "Head";
                uiData.partDescription = "Bullets shot by the player ricochet once.";
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
