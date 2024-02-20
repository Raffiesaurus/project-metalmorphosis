using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabJumpEnemy : EnemyUnit {

    [SerializeField] private Vector2 jumpBackForce = Vector2.zero;

    [SerializeField] private BoxCollider2D meleeHitBox = null;

    [SerializeField] private float runAwayDurationSeconds = 3.0f;

    private new bool isPlayerInRange = false;

    private float frameHealth = 0;

    private bool hasBeenInjured = false;

    private float runAwayStartTime = 0;

    public override void Start() {
        base.Start();
        frameHealth = currentHealth;
    }

    public override void Update() {
        base.Update();
        isPlayerInRange = false;

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
        Debug.Log("Attacking Player");
        Collider2D[] playerToHit = Physics2D.OverlapBoxAll(meleeHitBox.bounds.center, meleeHitBox.bounds.size, 0, playerLayer);
        foreach (Collider2D collider in playerToHit) { if (collider.CompareTag("player")) { isPlayerInRange = true; } }

        if (isPlayerInRange && cdCounter <= 0) {
            cdCounter = cooldown;
            rb.velocity = Vector2.zero;
            isPlayerInRange = false;
            shouldMoveToPlayer = false;
            rb.AddForce(Vector2.Reflect(jumpBackForce, dirVec));
            GameManager.GetPlayer().UpdateHealth(-meleeDamage);
        }

        if (!isPlayerInRange && cdCounter <= 0 && !hasBeenInjured) {
            shouldMoveToPlayer = true;
        }
    }

    private void RunAway() {
        Debug.Log("Running Away");
        float moveSign = Mathf.Sign(dirVec.x);
        rb.velocity = new(dirVec.x * moveSpeed * moveSpeedMultiplier * moveSign, rb.velocity.y);
    }

}
