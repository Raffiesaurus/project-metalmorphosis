using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShooterEnemy : EnemyUnit {

    public override void Update() {
        base.Update();
    }

    public void AttackPlayer() {
        rb.velocity = Vector2.zero;
        if (cdCounter <= 0 && currentAmmo >= ammoUsage) {
            currentAmmo -= ammoUsage;
            cdCounter = cooldown;
            PrefabManager.SpawnAndFire(bulletType, transform.position, playerPos, gameObject.tag);
        }
    }

}
