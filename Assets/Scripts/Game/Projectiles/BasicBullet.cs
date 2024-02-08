using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : Bullet {
    public override void OnCollision() {
        throw new NotImplementedException();
    }

    public override void OnFire(Vector3 startPoint, Vector3 firePoint) {
        transform.position = startPoint;
        
        Vector3 dirVec = (firePoint - startPoint);
        dirVec.Normalize();
        
        float angle = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        rb.velocity = dirVec * speed;
    }
}
