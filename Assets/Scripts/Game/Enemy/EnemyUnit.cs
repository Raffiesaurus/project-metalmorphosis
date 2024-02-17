using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyUnit : MonoBehaviour {

    [SerializeField] public float maxHealth = 100.0f;
    [SerializeField] public float maxFuel = 100.0f;
    [SerializeField] public float maxAmmo = 100.0f;
    [SerializeField] public float playerRange = 100.0f;
    [SerializeField] public float cooldown = 2.0f;
    [SerializeField] public float meleeDamage = 10.0f;
    [SerializeField] public float fuelUsage = 0.0f;
    [SerializeField] public float moveSpeed = 5.0f;
    [SerializeField] public float moveSpeedMultiplier = 1.0f;
    [SerializeField] public float healthRegenPerInterval = 1;
    [SerializeField] public float healthRegenIntervalSeconds = 0.5f;

    [SerializeField] public int ammoUsage = 1;

    [SerializeField] public BulletType bulletType = BulletType.BasicBullet;

    [HideInInspector] public float cdCounter = 0.0f;
    [SerializeField] public float currentHealth = 0;
    [HideInInspector] public float currentFuel = 0;
    [HideInInspector] public float currentAmmo = 0;

    [HideInInspector] public Vector3 playerPos = Vector3.zero;

    [HideInInspector] public Rigidbody2D rb = null;

    [HideInInspector] public BoxCollider2D boxCol = null;

    private float dmgReductionPercentage = 0;

    public virtual void Start() {
        currentHealth = maxHealth;
        currentFuel = maxFuel;
        currentAmmo = maxAmmo;
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    public virtual void Update() {

        playerPos = GameManager.GetPlayer().transform.position;

        Vector3 dirVec = playerPos - transform.position;

        if (dirVec.x < 0) {
            transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else {
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        if (dirVec.magnitude <= playerRange) {
            AttackPlayer();
        } else {
            MoveToPlayer(dirVec);
        }

        if (cdCounter > 0) {
            cdCounter -= Time.deltaTime;
        }

        if (healthRegenPerInterval > 0) {
            if (Time.time % healthRegenIntervalSeconds < Time.deltaTime) {
                currentHealth += healthRegenPerInterval;
                currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            }
        }

    }

    public virtual void UpdateHealth(float healthChange) {

        if (healthChange < 0) {
            currentHealth += (healthChange * ((100 - dmgReductionPercentage) / 100));
        } else {
            currentHealth += healthChange;
        }

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0) {
            OnDeath();
        }
    }

    public virtual void OnDeath() {
        Destroy(gameObject);
    }

    public virtual void MoveToPlayer(Vector3 dirVec) { }

    public virtual void AttackPlayer() { }
}
