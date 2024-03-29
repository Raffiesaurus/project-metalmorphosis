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

    [SerializeField] public float currentHealth = 0.0f;
    [SerializeField] public float currentFuel = 0.0f;
    [SerializeField] public float legSpeedMulti = 1.0f;
    [SerializeField] public float meleeDmgBonus = 0.0f;
    [SerializeField] public float rangeDmgBonus = 0.0f;

    [SerializeField] public int currentAmmo = 0;

    [SerializeField] public BoxCollider2D meleeHitBox;

    [SerializeField] public Animator playerAnimator;

    [SerializeField] private PlayerArm leftArm;
    [SerializeField] private PlayerArm rightArm;
    [SerializeField] private PlayerLeg legs;
    [SerializeField] private PlayerHead head;

    [SerializeField] private GameObject firingSpawnPoint;

    private float healthBoost = 0.0f;
    private float fuelBoost = 0.0f;
    private int ammoBoost = 0;

    private float dmgReductionPercentage = 0.0f;

    private void OnEnable() {
        playerControl = GetComponent<PlayerControl>();
        playerControl.enabled = true;
    }

    void Awake() {
        currentHealth = maxHealth;
        currentFuel = maxFuel;
        currentAmmo = maxAmmo;
        GameUIManager.UpdateHealthBar(currentHealth / maxHealth);
        GameUIManager.UpdateFuelBar(currentFuel / maxFuel);
        GameUIManager.UpdateAmmoCount(currentAmmo, maxAmmo);
    }

    public void UpdateEquippedItems() {

        meleeHitBox.enabled = false;

        leftArm.armPart = PartsManager.EquippedLeftArm;
        leftArm = leftArm.AssignScript();

        rightArm.armPart = PartsManager.EquippedRightArm;
        rightArm = rightArm.AssignScript();

        legs.legPart = PartsManager.EquippedLeg;
        legs = legs.AssignScript();

        healthBoost = legs.healthBoost;
        ammoBoost = legs.ammoBoost;
        fuelBoost = legs.fuelBoost;
        legSpeedMulti = legs.speedBoost;

        head.headPart = PartsManager.EquippedHead;
        head = head.AssignScript();

        healthBoost += head.healthBoost;
        ammoBoost += head.ammoBoost;
        fuelBoost += head.fuelBoost;
        legSpeedMulti += head.speedBoost;
        meleeDmgBonus = head.meleeDmgBoost;
        rangeDmgBonus = head.rangeDmgBoost;

        Debug.Log(healthBoost + " " + ammoBoost + " " + fuelBoost + " " + legSpeedMulti);
        UpdateHealth(0);
        UpdateFuel(0);
        UpdateAmmo(0);
        GameManager.BulletBounce = head.bulletBounce;
        GameManager.OneHitMode = head.oneHitMode;
        GameManager.PlayerReturnDamage = head.returnDmg;
        GameManager.PlayerReturnDamageAmount = head.returnDmgAmount;
    }

    public void OnLeftClick(Vector3 mousePos) {
        playerAnimator.SetTrigger("LeftArmFire");
        leftArm.PartFire(mousePos, firingSpawnPoint.transform.position);
    }

    private void Update() {

    }

    public void OnRightClick(Vector3 mousePos) {
        playerAnimator.SetTrigger("RightArmFire");
        rightArm.PartFire(mousePos, firingSpawnPoint.transform.position);
    }

    public void OnLeftClickRelease() {

    }

    public void OnRightClickRelease() {

    }

    public void OnShiftClick() {

    }

    public void OnUtilityOne() {
        if (head.swapAmmoHp) {
            if (currentAmmo <= head.ammoLoss && currentFuel <= head.fuelLoss) {
                UpdateHealth(head.hpGain);
                UpdateAmmo(head.ammoLoss);
                UpdateFuel(head.fuelLoss);
            }
        }
    }

    public void OnUtilityTwo() {

    }

    void OnDeath() {
        GameManager.GameOver(false);
        Destroy(gameObject);
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

        if (GameManager.OneHitMode && healthChange < 0) {
            healthChange = -999999999;
        }

        if (healthChange < 0) {
            currentHealth += (healthChange * ((100 - dmgReductionPercentage) / 100));
        } else {
            currentHealth += healthChange;
        }
        float maxHealthPossible = maxHealth + healthBoost;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealthPossible);
        GameUIManager.UpdateHealthBar(currentHealth / maxHealthPossible);

        if (currentHealth <= 0) {
            OnDeath();
        }
    }

    public void UpdateAmmo(int ammoChange) {
        currentAmmo += ammoChange;
        currentAmmo = Mathf.Clamp(currentAmmo, 0, (maxAmmo + ammoBoost));
        GameUIManager.UpdateAmmoCount(currentAmmo, (maxAmmo + ammoBoost));
    }

    public void UpdateFuel(float fuelChange) {
        currentFuel += fuelChange;
        currentFuel = Mathf.Clamp(currentFuel, 0, (maxFuel + fuelBoost));
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
