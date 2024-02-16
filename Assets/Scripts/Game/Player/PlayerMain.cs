using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour {

    private PlayerControl playerControl;

    [SerializeField] public float maxHealth = 100.0f;
    [SerializeField] public float maxFuel = 100.0f;
    [SerializeField] public int maxAmmo = 100;


    [HideInInspector] public float currentHealth = 0.0f;
    [HideInInspector] public float currentFuel = 0.0f;
    [HideInInspector] public int currentAmmo = 0;

    private PlayerParts leftArm;
    private PlayerParts rightArm;
    private PlayerParts legs;
    private PlayerParts head;
    private PlayerParts torso;

    private BoxCollider2D meleeHitBox;

    private float dmgReductionPercentage = 0.0f;

    private void OnEnable() {
        playerControl = GetComponent<PlayerControl>();
        playerControl.enabled = true;
    }

    void Start() {
        CheckMissingParts();
        currentHealth = maxHealth;
        currentFuel = maxFuel;
        currentAmmo = maxAmmo;
        GameUIManager.UpdateHealthBar(currentHealth / maxHealth);
        GameUIManager.UpdateFuelBar(currentFuel / maxFuel);
        GameUIManager.UpdateAmmoCount(currentAmmo, maxAmmo);
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
            currentHealth += (healthChange * ((100 - dmgReductionPercentage) / 100));
        } else {
            currentHealth += healthChange;
        }

        Mathf.Clamp(currentHealth, 0, maxHealth);

        GameUIManager.UpdateHealthBar(currentHealth / maxHealth);

        if (currentHealth < 0) {
            OnDeath();
        }
    }

    public void UpdateAmmo(int ammoChange) {
        currentAmmo += ammoChange;
        Mathf.Clamp(currentAmmo, 0, maxAmmo);
        GameUIManager.UpdateAmmoCount(currentAmmo, maxAmmo);
    }

    public void UpdateFuel(float fuelChange) {
        currentFuel += fuelChange;
        Mathf.Clamp(currentFuel, 0, maxFuel);
        GameUIManager.UpdateFuelBar(currentFuel / maxFuel);
    }

    public void UpdateDamageReductionPercentage(float newDmgReductionPercentage) {
        dmgReductionPercentage = newDmgReductionPercentage;
    }
}
