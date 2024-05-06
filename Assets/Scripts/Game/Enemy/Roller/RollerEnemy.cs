using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerEnemy : EnemyUnit {

    [SerializeField] private float playerDistanceToRoll = 10;

    public override void Update() {
        base.Update();
        if (dirVec.magnitude <= playerDistanceToRoll) {
            shouldMoveToPlayer = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("player")) {
            GameManager.GetPlayer().UpdateHealth(-meleeDamage);
            UpdateHealth(-99999);
            AudioManager.PlaySFX(AudioClips.GrenadeExplode);
        }
    }

}
