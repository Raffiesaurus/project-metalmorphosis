using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour {

    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public BoxCollider2D boxCollider;

    [SerializeField] public float damage;
    [SerializeField] public float speed;

    [HideInInspector] public string shotBy = "";

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
    }

    public virtual void OnFire(Vector3 startPoint, Vector3 firePoint, string ownerTag) {
        shotBy = ownerTag;
        transform.position = startPoint;

        Vector3 dirVec = (firePoint - startPoint);
        dirVec.Normalize();

        float angle = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        rb.velocity = dirVec * speed;
    }

    public virtual void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("wall") || collision.gameObject.CompareTag("floor")) {
            KillBullet();
        }

        if (shotBy == "player") {

            if (collision.gameObject.CompareTag("enemy")) {
                collision.gameObject.GetComponent<EnemyUnit>().UpdateHealth(-damage);
                KillBullet();
            } else if (collision.gameObject.CompareTag("cover")) {
                collision.gameObject.GetComponent<CoverObject>().UpdateHealth(-damage);
                KillBullet();
            }

        } else if (shotBy == "enemy") {

            if (collision.gameObject.CompareTag("player")) {
                collision.gameObject.GetComponent<PlayerMain>().UpdateHealth(-damage);
                KillBullet();
            }

        }

    }

    public virtual void KillBullet(float delay = 0.0f) {
        Destroy(gameObject, delay);
    }
}
