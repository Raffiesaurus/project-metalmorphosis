using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : Bullet {

    [SerializeField] public LayerMask enemyLayer;

    [SerializeField] private float explosionDelay;

    private ParticleSystem explosionParticles;

    private SpriteRenderer grenadeImage;

    private CircleCollider2D explosionCollider;

    public override void Start() {
        grenadeImage = GetComponent<SpriteRenderer>();
        explosionCollider = GetComponentInChildren<CircleCollider2D>();
        explosionParticles = GetComponentInChildren<ParticleSystem>();
        grenadeImage.enabled = true;
        base.Start();
    }

    public override void OnTriggerEnter2D(Collider2D collision) {

    }

    public void Explode() {
        grenadeImage.enabled = false;
        explosionParticles.Play();
        Collider2D[] enemiesToHit = Physics2D.OverlapBoxAll(explosionCollider.bounds.center, explosionCollider.bounds.size, 0, enemyLayer);
        for (int i = 0; i < enemiesToHit.Length; i++) {
            if (enemiesToHit[i].TryGetComponent(out EnemyUnit enemy)) {
                enemy.UpdateHealth(-damage);
            }
            if (enemiesToHit[i].TryGetComponent(out PlayerMain player)) {
                player.UpdateHealth(-damage);
            }
        }
        Destroy(gameObject, 0.2f);
    }

    public override void KillBullet(float delay = 0.0f) {
        Invoke(nameof(Explode), explosionDelay);
    }
}
