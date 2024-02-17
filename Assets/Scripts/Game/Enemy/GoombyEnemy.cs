using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombyEnemy : EnemyUnit {

    private int moveSign = 1;
    public override void Update() {
        rb.velocity = new(moveSign * moveSpeed * moveSpeedMultiplier, 0);

        if (rb.velocity.x < 0) {
            transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else {
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "wall") {
            moveSign = -moveSign;
        }

        if (collision.gameObject.tag == "player") {
            moveSign = -moveSign;
            GameManager.GetPlayer().UpdateHealth(-meleeDamage);
        }
                                                                                                                                                                                                                                                         
    }

}
