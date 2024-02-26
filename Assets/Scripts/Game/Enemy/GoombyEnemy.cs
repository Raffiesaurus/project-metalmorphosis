using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombyEnemy : EnemyUnit {

    private int moveSign = 1;

    public override void Start() {
        base.Start();
        if (Random.Range(0, 2) > 0) {
            moveSign = -1;
        }
    }

    public override void Update() {

        if (GameManager.IsInEquipMode || GameUIManager.IsInMapScreen) { rb.velocity = Vector2.zero; return; }

        rb.velocity = new(moveSign * moveSpeed * moveSpeedMultiplier, 0);

        if (rb.velocity.x < 0) {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("wall") || collision.gameObject.CompareTag("cover")) {
            moveSign = -moveSign;
        }

        if (collision.gameObject.CompareTag("player")) {
            moveSign = -moveSign;
            GameManager.GetPlayer().UpdateHealth(-meleeDamage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("wall") || collision.gameObject.CompareTag("cover")) {
            moveSign = -moveSign;
        }

        if (collision.gameObject.CompareTag("player")) {
            moveSign = -moveSign;
            GameManager.GetPlayer().UpdateHealth(-meleeDamage);
        }

    }

}
