using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabJumpEnemy : EnemyUnit {

    [SerializeField] private Vector2 jumpBackForce = Vector2.zero;

    [SerializeField] private BoxCollider2D meleeHitBox = null;

    [SerializeField] private float runAwayDurationSeconds = 3.0f;

    private bool isPlayerInMeleeRange = false;

    private float frameHealth = 0;

    private bool hasBeenInjured = false;

    private float runAwayStartTime = 0;

    public override void Start() {
        base.Start();
        frameHealth = currentHealth;
    }

    public override void Update() {
        base.Update();
        isPlayerInMeleeRange = false;

        if (frameHealth > currentHealth) {
            frameHealth = currentHealth;
            hasBeenInjured = true;
        }

        if (hasBeenInjured) {
            if (runAwayStartTime == 0) {
                runAwayStartTime = Time.time;
            }
            RunAway();
            if (Time.time - runAwayStartTime > runAwayDurationSeconds) {
                hasBeenInjured = false;
                runAwayStartTime = 0;
            }
        } else {
            AttackPlayer();
        }

    }

    private void AttackPlayer() {
        Collider2D[] playerToHit = Physics2D.OverlapBoxAll(meleeHitBox.bounds.center, meleeHitBox.bounds.size, 0, playerLayer);
        foreach (Collider2D collider in playerToHit) { if (collider.CompareTag("player")) { isPlayerInMeleeRange = true; } }

        if (isPlayerInMeleeRange && cdCounter <= 0) {
            cdCounter = cooldown;
            isPlayerInMeleeRange = false;
            shouldMoveToPlayer = false;

            float moveSign = 1;
            if (rb.velocity.x < 0) {
                moveSign = -1;
            }
            rb.velocity = Vector2.zero;

            rb.AddForce(new(jumpBackForce.x * -moveSign, jumpBackForce.y));

            GameManager.GetPlayer().UpdateHealth(-meleeDamage);
            if (GameManager.PlayerReturnDamage) {
                UpdateHealth(-meleeDamage * (GameManager.PlayerReturnDamageAmount / 100));
            }
        }

        if (!isPlayerInMeleeRange && cdCounter <= 0 && !hasBeenInjured) {
            shouldMoveToPlayer = true;
        }
    }

    private void RunAway() {
        if (GameUIManager.IsInMapScreen || GameUIManager.IsInSwapScreen) { rb.velocity = Vector2.zero; return; }

        rb.velocity = new(-dirVecNormalized.x * moveSpeed * moveSpeedMultiplier, rb.velocity.y);
    }

}
