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

    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public LayerMask playerLayer;

    [SerializeField] public BulletType bulletType = BulletType.BasicBullet;

    [SerializeField] public EnemyDropProperties armDropProps;
    [SerializeField] public EnemyDropProperties legDropProps;
    [SerializeField] public EnemyDropProperties headDropProps;

    [HideInInspector] public float cdCounter = 0.0f;
    [HideInInspector] public float currentHealth = 0;
    [HideInInspector] public float currentFuel = 0;
    [HideInInspector] public float currentAmmo = 0;

    [HideInInspector] public bool shouldMoveToPlayer = false;
    [HideInInspector] public bool isGrounded = false;
    [HideInInspector] public bool isPlayerInRange = false;

    [HideInInspector] public Vector3 playerPos = Vector3.zero;
    [HideInInspector] public Vector3 dirVec = Vector3.zero;
    [HideInInspector] public Vector3 dirVecNormalized = Vector3.zero;

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
        if (GameUIManager.IsInMapScreen || GameUIManager.IsInSwapScreen) { rb.velocity = Vector2.zero; return; }

        //if (transform.position.y < 0) { OnDeath(); }

        CheckGround();

        playerPos = GameManager.GetPlayer().transform.position;
        if (playerPos == null) {
            return;
        }
        dirVec = playerPos - transform.position;
        dirVecNormalized = dirVec.normalized;

        if (dirVec.magnitude <= playerRange) {
            isPlayerInRange = true;
        } else {
            isPlayerInRange = false;
        }


        if (rb.velocity.x < 0.5) {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else if (rb.velocity.x > 0.5) {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        if (shouldMoveToPlayer) {
            MoveToPlayer();
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
        if (GameManager.OneHitMode && healthChange < 0) {
            healthChange = -999999999;
        }

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
        float dropChance = Random.Range(0, 100);
        float partChance = Random.Range(0, 100);


        if (dropChance <= armDropProps.partDropChance) {

            if (partChance <= armDropProps.epicDropChance) {
                DropsManager.DropArm(PartRarity.Epic, transform.position);
            } else if (partChance <= armDropProps.rareDropChance) {
                DropsManager.DropArm(PartRarity.Rare, transform.position);
            } else {
                DropsManager.DropArm(PartRarity.Common, transform.position);
            }
            Destroy(gameObject);
        } else {

            // Failed arm check, now check leg

            dropChance = Random.Range(0, 100);

            if (dropChance <= legDropProps.partDropChance) {
                if (partChance <= legDropProps.epicDropChance) {
                    DropsManager.DropLeg(PartRarity.Epic, transform.position);
                } else if (partChance <= legDropProps.rareDropChance) {
                    DropsManager.DropLeg(PartRarity.Rare, transform.position);
                } else {
                    DropsManager.DropLeg(PartRarity.Common, transform.position);
                }
                Destroy(gameObject);
            } else {

                // Failed leg check, now check head

                dropChance = Random.Range(0, 100);

                if (dropChance <= headDropProps.partDropChance) {
                    if (partChance <= headDropProps.epicDropChance) {
                        DropsManager.DropHead(PartRarity.Epic, transform.position);
                    } else if (partChance <= headDropProps.rareDropChance) {
                        DropsManager.DropHead(PartRarity.Rare, transform.position);
                    } else {
                        DropsManager.DropHead(PartRarity.Common, transform.position);
                    }
                } else {
                    // Failed head check, unlucky no drops for you
                    Destroy(gameObject);
                }
            }
        }
    }

    public virtual void MoveToPlayer() {
        rb.velocity = new(dirVecNormalized.x * moveSpeed * moveSpeedMultiplier, rb.velocity.y);
    }
}
