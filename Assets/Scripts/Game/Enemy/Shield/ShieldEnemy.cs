using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : EnemyUnit {

    private bool isFiring = false;

    private float fireCdCounter = 0.0f;
    public float fireDuration = 5.0f;

    public float postFireCdCounter = 0.0f;
    public float postFireDuration = 5.0f;

    [SerializeField] private Animator animator;

    public override void Start() {
        base.Start();
    }

    public override void Update() {
        base.Update();

        if (postFireCdCounter > 0) {
            postFireCdCounter -= Time.deltaTime;
            rb.velocity = Vector3.zero;
            shouldMoveToPlayer = false;
            if (dirVecNormalized.x < 0.1) {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            } else if (dirVecNormalized.x > 0.1) {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            animator.SetBool("fire_right", false);
            animator.SetBool("idle", true);
            animator.SetBool("fire_left", false);
            return;
        }

        if (!isFiring) {
            if (!isPlayerInRange) {
                shouldMoveToPlayer = true;
                animator.SetBool("idle", false);
            } else {
                shouldMoveToPlayer = false;
                animator.SetBool("idle", true);
            }

            if (!shouldMoveToPlayer && isPlayerInRange) {
                isFiring = true;
                fireCdCounter = fireDuration;
                ShootPlayer();
            }


        } else {
            ShootPlayer();

            if (fireCdCounter > 0) {
                fireCdCounter -= Time.deltaTime;
            }

            if (fireCdCounter <= 0) {
                postFireCdCounter = postFireDuration;
                isFiring = false;
            }
        }

    }

    private void ShootPlayer() {

        if (dirVecNormalized.x > 0) {
            animator.SetBool("fire_left", true);
        } else {
            animator.SetBool("fire_right", true);
        }

        currentAmmo -= ammoUsage;

        if (cdCounter <= 0) {
            PrefabManager.SpawnAndFire(bulletType, transform.position, playerPos, gameObject);
            cdCounter = cooldown;
        }

    }

}
