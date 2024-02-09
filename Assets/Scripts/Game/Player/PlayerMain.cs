using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour {

    private float health = 100.0f;
    private float fuel = 100.0f;
    private int ammo = 100;

    private PlayerControl playerControl;

    [SerializeField] private PlayerParts leftArm;
    [SerializeField] private PlayerParts rightArm;
    [SerializeField] private PlayerParts legs;
    [SerializeField] private PlayerParts head;
    [SerializeField] private PlayerParts torso;

    [SerializeField] private BoxCollider2D meleeHitBox;

    private void OnEnable() {
        playerControl = GetComponent<PlayerControl>();
        playerControl.enabled = true;
    }

    // Start is called before the first frame update
    void Start() {
        CheckMissingParts();
    }

    // Update is called once per frame
    void Update() {
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

    public void TakeDamage(float damage) {
        health -= damage;

        if (health < 0) {
            OnDeath();
        }
    }
}
