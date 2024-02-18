using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : Bullet {

    private string shotBy = "";

    public override void OnCollision() {

    }

    public override void OnTriggerEnter2D(Collider2D collision) {

        if (shotBy == "player") {

            if (collision.gameObject.tag == "enemy") {
                collision.gameObject.GetComponent<EnemyUnit>().UpdateHealth(-damage);
                Destroy(gameObject);
            }

        } else if (shotBy == "enemy") {

            if (collision.gameObject.tag == "player") {
                collision.gameObject.GetComponent<PlayerMain>().UpdateHealth(-damage);
                Destroy(gameObject);
            }

        }
    }

    public override void OnFire(Vector3 startPoint, Vector3 firePoint, string ownerTag) {
        shotBy = ownerTag;
        transform.position = startPoint;

        Vector3 dirVec = (firePoint - startPoint);
        dirVec.Normalize();

        float angle = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        rb.velocity = dirVec * speed;
    }

}
