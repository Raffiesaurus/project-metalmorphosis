using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour {

    private PlayerControl playerControl;

    [SerializeField] public float maxHealth = 100.0f;
    [SerializeField] public float maxFuel = 100.0f;

    [SerializeField] public int maxAmmo = 100;

    [SerializeField] public LayerMask enemyLayer;

    [SerializeField] public PlayerCamera playerCam = null;

    [HideInInspector] public float currentHealth = 0.0f;
    [HideInInspector] public float currentFuel = 0.0f;
    [HideInInspector] public float legSpeedMulti = 1.0f;

    [HideInInspector] public int currentAmmo = 0;

    [HideInInspector] public BoxCollider2D meleeHitBox;

    [SerializeField] private PlayerArm leftArm;
    [SerializeField] private PlayerArm rightArm;
    [SerializeField] private PlayerLeg legs;
    [SerializeField] private PlayerParts head;
    [SerializeField] private PlayerParts torso;

    private float healthBoost = 0.0f;
    private float fuelBoost = 0.0f;
    private int ammoBoost = 0;

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

    public void UpdateEquippedItems() {

        meleeHitBox.enabled = false;

        if (leftArm == null)
            leftArm = transform.Find("Parts").Find("Left Arm").GetComponent<PlayerArm>();
        leftArm.armPart = PartsManager.EquippedLeftArm;
        leftArm = leftArm.AssignScript();

        if (rightArm == null)
            rightArm = transform.Find("Parts").Find("Right Arm").GetComponent<PlayerArm>();
        rightArm.armPart = PartsManager.EquippedRightArm;
        rightArm = rightArm.AssignScript();

        if (legs == null)
            legs = transform.Find("Parts").Find("Legs").GetComponent<PlayerLeg>();
        legs.legPart = PartsManager.EquippedLeg;
        legs = legs.AssignScript();

        healthBoost = legs.healthUp;
        ammoBoost = legs.ammoUp;
        fuelBoost = legs.fuelUp;
        legSpeedMulti = legs.speedUp;

        UpdateHealth(0);
        UpdateFuel(0);
        UpdateAmmo(0);

        Debug.Log(healthBoost);
        Debug.Log(ammoBoost);
        Debug.Log(fuelBoost);
        Debug.Log(legSpeedMulti);
    }

    public void OnLeftClick(Vector3 mousePos) {
        if (leftArm == null)
            leftArm = transform.Find("Parts").Find("Left Arm").GetComponent<PlayerArm>();

        leftArm.PartFire(mousePos);
    }

    private void Update() {

    }

    public void OnRightClick(Vector3 mousePos) {
        if (rightArm == null)
            rightArm = transform.Find("Parts").Find("Right Arm").GetComponent<PlayerArm>();

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
        GameManager.GameOver(false);
        Destroy(gameObject);
    }

    void CheckMissingParts() {

        Transform partParent = transform.Find("Parts");

        if (leftArm == null)
            leftArm = partParent.Find("Left Arm").GetComponent<PlayerArm>();

        if (rightArm == null)
            rightArm = partParent.Find("Right Arm").GetComponent<PlayerArm>();

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
        Collider2D[] enemiesToHit = Physics2D.OverlapBoxAll(meleeHitBox.bounds.center, meleeHitBox.bounds.size, 0, enemyLayer);

        for (int i = 0; i < enemiesToHit.Length; i++) {
            if (enemiesToHit[i].TryGetComponent(out EnemyUnit enemy)) {
                enemy.UpdateHealth(-damage);
            }
            if (enemiesToHit[i].TryGetComponent(out CoverObject cover)) {
                cover.UpdateHealth(-damage);
            }
        }
    }

    public void UpdateHealth(float healthChange) {

        if (healthChange < 0) {
            currentHealth += (healthChange * ((100 - dmgReductionPercentage) / 100));
        } else {
            currentHealth += healthChange;
        }

        Mathf.Clamp(currentHealth, 0, (maxHealth + healthBoost));

        GameUIManager.UpdateHealthBar(currentHealth / (maxHealth + healthBoost));

        if (currentHealth <= 0) {
            OnDeath();
        }
    }

    public void UpdateAmmo(int ammoChange) {
        currentAmmo += ammoChange;
        Mathf.Clamp(currentAmmo, 0, (maxAmmo + ammoBoost));
        GameUIManager.UpdateAmmoCount(currentAmmo, (maxAmmo + ammoBoost));
    }

    public void UpdateFuel(float fuelChange) {
        currentFuel += fuelChange;
        Mathf.Clamp(currentFuel, 0, (maxFuel + fuelBoost));
        GameUIManager.UpdateFuelBar(currentFuel / (maxFuel + fuelBoost));
    }

    public void UpdateDamageReductionPercentage(float newDmgReductionPercentage) {
        dmgReductionPercentage = newDmgReductionPercentage;
    }

    public void SpawnAtPoint(Vector3 spawnPoint) {
        playerCam = CameraManager.GetPlayerCamera().GetComponent<PlayerCamera>();
        transform.position = spawnPoint;
        playerCam.transform.position = new(transform.position.x, transform.position.y + 2, transform.position.z - 4);
    }
}
