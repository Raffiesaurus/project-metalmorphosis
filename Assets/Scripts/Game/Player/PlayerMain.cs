using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour {

    private PlayerControl playerControl;

    [SerializeField] public float health = 100.0f;
    [SerializeField] public float fuel = 100.0f;
    [SerializeField] public int ammo = 100;
    private float dmgReductionPercentage = 0.0f;

    private PlayerParts leftArm;
    private PlayerParts rightArm;
    private PlayerParts legs;
    private PlayerParts head;
    private PlayerParts torso;

    private BoxCollider2D meleeHitBox;

    private void OnEnable() {
        playerControl = GetComponent<PlayerControl>();
        playerControl.enabled = true;
    }

    void Start() {
        CheckMissingParts();
    }

    public void OnLeftClick(Vector3 mousePos) {
        if (leftArm == null)
            leftArm = transform.Find("Parts").Find("Left Arm").GetComponent<PlayerParts>();

        leftArm.PartFire(mousePos);
    }

    public void OnRightClick(Vector3 mousePos) {
        if (rightArm == null)
            rightArm = transform.Find("Parts").Find("Right Arm").GetComponent<PlayerParts>();

        rightArm.PartFire(mousePos);
    }

    public void OnLeftClickRelease() {

    }

    public void OnRightClickRelease() {

    }

    public void OnShiftClick() {

    }

    public void OnUtilityOne() {

    }

    public void OnUtilityTwo() {

    }

    void OnDeath() {
        playerControl.enabled = false;
    }

    void CheckMissingParts() {

        Transform partParent = transform.Find("Parts");

        if (leftArm == null)
            leftArm = partParent.Find("Left Arm").GetComponent<PlayerParts>();

        if (rightArm == null)
            rightArm = partParent.Find("Right Arm").GetComponent<PlayerParts>();

        if (legs == null)
            legs = partParent.Find("Legs").GetComponent<PlayerLeg>();

        if (torso == null)
            torso = partParent.Find("Torso").GetComponent<PlayerTorso>();

        if (head == null)
            head = partParent.Find("Head").GetComponent<PlayerHead>();

        if (meleeHitBox == null)
            meleeHitBox = partParent.Find("MeleeHitBox").GetComponent<BoxCollider2D>();
    }

    public void DealMeleeDamage(float damage) {
        Debug.Log("Dealing " + damage + " damgage");
        Collider2D[] enemiesToHit = Physics2D.OverlapBoxAll(meleeHitBox.bounds.center, meleeHitBox.bounds.size, 0, 6);
        for (int i = 0; i < enemiesToHit.Length; i++) {
            //enemiesToHit[i].GetComponent<EnemyController>().TakeDamage(damage);
        }
    }

    public void UpdateHealth(float healthChange) {

        if (healthChange < 0) {
            health += (healthChange * ((100 - dmgReductionPercentage) / 100));
        } else {
            health += healthChange;
        }


        if (health < 0) {
            OnDeath();
        }
    }

    public void UpdateAmmo(int ammoChange) {
        ammo += ammoChange;
    }

    public void UpdateFuel(float fuelChange) {
        fuel += fuelChange;
    }

    public void UpdateDamageReductionPercentage(float newDmgReductionPercentage) {
        dmgReductionPercentage = newDmgReductionPercentage;
    }
}
