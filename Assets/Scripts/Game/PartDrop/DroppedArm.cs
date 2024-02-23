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
            } else if (randomPart == 0) {
                armPart = ArmPart.Lefty;
            } else if (randomPart == 0) {
                armPart = ArmPart.Righty;
            } else {
                armPart = ArmPart.Nail_Gun;
            }

        } else if (partRarity == PartRarity.Rare) {
            // Chainsaw, brrrr, Bat
            int randomPart = Random.Range(0, 3);
            if (randomPart == 0) {
                armPart = ArmPart.Chainsaw;
            } else if (randomPart == 0) {
                armPart = ArmPart.Brrrrr;
            } else {
                armPart = ArmPart.Bat;
            }

        } else {
            // Judy, Punch, Backfire
            int randomPart = Random.Range(0, 3);
            if (randomPart == 0) {
                armPart = ArmPart.Judy;
            } else if (randomPart == 0) {
                armPart = ArmPart.Punch;
            } else {
                armPart = ArmPart.Backfire;
            }

        }

    }

    public override void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "player") {
            Debug.Log("Hello Player");
        }
    }

    public override void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "player") {
            Debug.Log("Bye Player");
        }
    }

}
