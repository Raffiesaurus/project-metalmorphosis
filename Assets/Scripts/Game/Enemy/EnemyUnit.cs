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

    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public LayerMask playerLayer;

    [SerializeField] public int ammoUsage = 1;

    [SerializeField] public BulletType bulletType = BulletType.BasicBullet;

    [HideInInspector] public float cdCounter = 0.0f;
    [SerializeField] public float currentHealth = 0;
    [HideInInspector] public float currentFuel = 0;
    [HideInInspector] public float currentAmmo = 0;

    [HideInInspector] public bool shouldMoveToPlayer = false;
    [HideInInspector] public bool isGrounded = false;

    [HideInInspector] public Vector3 playerPos = Vector3.zero;
    [HideInInspector] public Vector3 dirVec = Vector3.zero;

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

        CheckGround();

        playerPos = GameManager.GetPlayer().transform.position;

        dirVec = playerPos - transform.position;
        dirVec.Normalize();

        if (rb.velocity.x < 1) {
            transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else if (rb.velocity.x > 1) {
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        if (shouldMoveToPlayer) {
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

    void CheckGround() {
        bool checkGroundNow = Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.down, 0.01f, groundLayer);
        if (checkGroundNow != isGrounded) {
            isGrounded = checkGroundNow;
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

    public virtual void MoveToPlayer(Vector3 dirVec) {
        rb.velocity = new(dirVec.x * moveSpeed * moveSpeedMultiplier, rb.velocity.y);
    }
}
