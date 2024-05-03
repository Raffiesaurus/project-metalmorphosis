using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemy : EnemyUnit {

    [SerializeField] private BoxCollider2D meleeHitBox = null;
    [SerializeField] private Animator animator;

    private bool isPlayerInMeleeRange = false;

    public override void Update() {
        base.Update();
        isPlayerInMeleeRange = false;
        AttackPlayer();
    }

    private void AttackPlayer() {
        Collider2D[] playerToHit = Physics2D.OverlapBoxAll(meleeHitBox.bounds.center, meleeHitBox.bounds.size, 0, playerLayer);
        foreach (Collider2D collider in playerToHit) { if (collider.CompareTag("player")) { isPlayerInMeleeRange = true; } }

        if (isPlayerInMeleeRange && cdCounter <= 0) {
            cdCounter = cooldown;
            isPlayerInMeleeRange = false;
            shouldMoveToPlayer = false;

            rb.velocity = Vector2.zero;

            animator.SetTrigger("attack");

            GameManager.GetPlayer().UpdateHealth(-meleeDamage);
            if (GameManager.PlayerReturnDamage) {
                UpdateHealth(-meleeDamage * (GameManager.PlayerReturnDamageAmount / 100));
            }
        }

        if (!isPlayerInMeleeRange) {
            shouldMoveToPlayer = true;
        }
    }

}
