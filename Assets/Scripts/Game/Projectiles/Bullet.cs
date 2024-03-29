using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour {

    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public BoxCollider2D boxCollider;

    [SerializeField] public float damage = 0.0f;
    [SerializeField] public float speed = 0.0f;
    [SerializeField] public int bounceCount = 0;

    [HideInInspector] public GameObject shotBy = null;

    private Vector2 lastVelocity = Vector2.zero;

    private Vector2 savedSpeed = Vector2.zero;

    public virtual void Awake() {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        KillBullet(5.0f);
    }

    public void Update() {
        if (GameUIManager.IsInMapScreen || GameUIManager.IsInSwapScreen) {
            if (rb.velocity != Vector2.zero)
                savedSpeed = rb.velocity;
            rb.velocity = Vector2.zero;
        }

        if (savedSpeed != Vector2.zero && !GameUIManager.IsInMapScreen && !GameUIManager.IsInSwapScreen && rb.velocity == Vector2.zero) {
            rb.velocity = savedSpeed;
            savedSpeed = Vector2.zero;
        }

        lastVelocity = rb.velocity;
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    public virtual void OnFire(Vector3 startPoint, Vector3 firePoint, GameObject owner) {
        shotBy = owner;
        transform.position = startPoint;

        Vector3 dirVec = (firePoint - startPoint);
        dirVec.Normalize();

        float angle = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        rb.velocity = dirVec * speed;

        if (shotBy.CompareTag("player")) {
            damage *= ((100 + GameManager.GetPlayer().rangeDmgBonus) / 100);
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D collision) {
        ContactPoint2D[] myContact = new ContactPoint2D[1];
        collision.GetContacts(myContact);
        if (collision.gameObject.CompareTag("wall") || collision.gameObject.CompareTag("floor")) {
            if (GameManager.BulletBounce && bounceCount <= 0) {
                bounceCount++;
                float speed = lastVelocity.magnitude;
                Vector3 reflectedDir = Vector2.Reflect(lastVelocity.normalized, myContact[0].normal.normalized);
                rb.velocity = reflectedDir * speed;
                Debug.Log("BOUNCE! " + reflectedDir);

            } else {
                KillBullet();
            }
        }

        if (shotBy.CompareTag("player")) {

            if (collision.gameObject.CompareTag("enemy")) {
                collision.gameObject.GetComponent<EnemyUnit>().UpdateHealth(-damage);
                KillBullet();
            } else if (collision.gameObject.CompareTag("cover")) {
                collision.gameObject.GetComponent<CoverObject>().UpdateHealth(-damage);
                KillBullet();
            }

        } else if (shotBy.CompareTag("enemy")) {

            if (collision.gameObject.CompareTag("player")) {
                collision.gameObject.GetComponent<PlayerMain>().UpdateHealth(-damage);
                if (GameManager.PlayerReturnDamage) {
                    shotBy.GetComponent<EnemyUnit>().UpdateHealth(-damage * (GameManager.PlayerReturnDamageAmount / 100));
                }
                KillBullet();
            }

        }

    }

    public virtual void KillBullet(float delay = 0.0f) {
        Destroy(gameObject, delay);
    }
}
