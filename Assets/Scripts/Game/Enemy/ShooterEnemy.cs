using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class ShooterEnemy : EnemyUnit {

    public override void Update() {
        base.Update();
    }

    public override void AttackPlayer() {
        rb.velocity = Vector2.zero;
        if (cdCounter <= 0 && currentAmmo >= ammoUsage) {
            currentAmmo -= ammoUsage;
            cdCounter = cooldown;
            PrefabManager.SpawnAndFire(bulletType, transform.position, playerPos, gameObject.tag);
        }
    }

    public override void MoveToPlayer(Vector3 dirVec) {
        rb.velocity = new(dirVec.x * moveSpeed * moveSpeedMultiplier, rb.velocity.y);
    }

}
