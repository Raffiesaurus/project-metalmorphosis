using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolEnemy : EnemyUnit {

    private CoverObject[] coverObjects = null;
    private CoverObject coverObjectChosen = null;

    private Vector3 moveVel = Vector3.zero;

    private bool isMovingToCover = false;
    private bool isAtCover = false;

    [SerializeField] private Transform bulletSpawn;

    [SerializeField] private Animator animator;

    public override void Start() {
        base.Start();
        coverObjects = transform.parent.GetComponentsInChildren<CoverObject>();
    }

    public override void Update() {
        base.Update();



        if (isMovingToCover) {

            rb.velocity = moveVel;

            if (coverObjectChosen != null && coverObjects.Length > 0) {
                float distanceToCover = Vector3.Distance(transform.position, coverObjectChosen.transform.position);
                if (distanceToCover <= 1) {
                    isMovingToCover = false;
                    isAtCover = true;
                    rb.velocity = Vector2.zero;
                }
            } else {
                isMovingToCover = false;
            }

        } else {

            if (dirVecNormalized.x < 0.1) {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            } else if (dirVecNormalized.x > 0.1) {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }

            if (coverObjects.Length > 0) {
                if (!isAtCover) {
                    if (cdCounter > 0) {
                        MoveToCover();
                    } else {
                        if (isPlayerInRange) {
                            ShootPlayer();
                        } else if (!isPlayerInRange) {
                            MoveToPlayer();
                        }
                    }
                } else {
                    if (isPlayerInRange) {
                        ShootPlayer();
                    } else if (!isPlayerInRange) {
                        MoveToPlayer();
                    }
                }
            } else {
                if (isPlayerInRange && cdCounter <= 0) {
                    ShootPlayer();
                } else if (!isPlayerInRange && cdCounter <= 0) {
                    MoveToPlayer();
                }
            }
        }

    }

    private void ShootPlayer() {
        if (cdCounter <= 0) {
            animator.SetTrigger("attack");
            AudioManager.PlaySFX(AudioClips.Gunfire);
            currentAmmo -= ammoUsage;
            PrefabManager.SpawnAndFire(bulletType, bulletSpawn.position, playerPos, gameObject);
            cdCounter = cooldown;
        }
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
