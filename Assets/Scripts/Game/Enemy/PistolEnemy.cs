using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolEnemy : EnemyUnit {

    private CoverObject[] coverObjects = null;
    private CoverObject coverObjectChosen = null;

    private Vector3 moveVel = Vector3.zero;

    private bool isMovingToCover = false;
    private bool isAtCover = false;

    public override void Start() {
        base.Start();
        coverObjects = transform.parent.GetComponentsInChildren<CoverObject>();
    }

    public override void Update() {
        base.Update();

        if (isMovingToCover) {

            rb.velocity = moveVel;

            if (coverObjectChosen != null) {
                float distanceToCover = Vector3.Distance(transform.position, coverObjectChosen.transform.position);
                if (distanceToCover <= 0.05) {
                    isMovingToCover = false;
                    isAtCover = true;
                    rb.velocity = Vector2.zero;
                }
            } else {
                isMovingToCover = false;
            }

        } else {

            if (cdCounter > 0 && !isAtCover) {
                MoveToCover();
            }

            if (isPlayerInRange && cdCounter <= 0) {
                ShootPlayer();
            } else if (!isPlayerInRange && cdCounter <= 0) {
                MoveToPlayer();
            }

        }

    }

    private void ShootPlayer() {
        isAtCover = false;
        currentAmmo -= ammoUsage;
        cdCounter = cooldown;
        PrefabManager.SpawnAndFire(bulletType, transform.position, playerPos, gameObject.tag);
    }

    private void MoveToCover() {
        if (coverObjects != null && coverObjects.Length > 0) {
            int randomCover = Random.Range(0, coverObjects.Length);
            coverObjectChosen = coverObjects[randomCover];

            if (coverObjectChosen != null) {

                Vector3 moveVec = coverObjectChosen.transform.position - transform.position;
                moveVec.Normalize();

                moveVel = new(moveVec.x * moveSpeed * moveSpeedMultiplier, rb.velocity.y);
                isMovingToCover = true;

            }
        }
    }

    public override void MoveToPlayer() {
        base.MoveToPlayer();
        isAtCover = false;
    }
}
