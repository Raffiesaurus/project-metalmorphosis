using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldIgnoreBullet : Bullet {

    public override void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("wall") || collision.CompareTag("floor")) {
            KillBullet();
        }

        if (shotBy.CompareTag("player")) {

            if (collision.gameObject.CompareTag("enemy")) {
                collision.gameObject.GetComponent<EnemyUnit>().UpdateHealth(-damage);
                KillBullet();
            } else if (collision.gameObject.CompareTag("cover")) {
                collision.gameObject.GetComponent<CoverObject>().UpdateHealth(-damage);
                KillBullet();
            }

        } else if (shotBy.CompareTag("enemy")) {

            if (collision.gameObject.CompareTag("player")) {
                collision.gameObject.GetComponent<PlayerMain>().UpdateHealth(-damage);
                if (GameManager.PlayerReturnDamage) {
                    shotBy.GetComponent<EnemyUnit>().UpdateHealth(-damage * (GameManager.PlayerReturnDamageAmount / 100));
                }
                KillBullet();
            }

        }

    }
}