using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour {
    [SerializeField] private float health = 100.0f;

    public virtual void Update() {
        Vector3 dirVec = transform.position - GameManager.GetPlayer().transform.position;
        if (dirVec.x > 0) {
            transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else {
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

}
