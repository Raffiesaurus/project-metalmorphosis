using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour {

    [SerializeField] public float maxHealth = 100.0f;
    [SerializeField] public float maxFuel = 100.0f;
    [SerializeField] public float maxAmmo = 100.0f;
    [SerializeField] public float playerRange = 100.0f;

    [HideInInspector] public float currentHealth = 0;
    [HideInInspector] public float currentFuel = 0;
    [HideInInspector] public float currentAmmo = 0;

    private float dmgReductionPercentage = 0;

    private Vector3 playerPos = Vector3.zero;

    public virtual void Update() {
        playerPos = GameManager.GetPlayer().transform.position;
        Vector3 dirVec = transform.position - playerPos;
        if (dirVec.x > 0) {
            transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else {
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    public virtual void UpdateHealth(float healthChange) {

        if (healthChange < 0) {
            currentHealth += (healthChange * ((100 - dmgReductionPercentage) / 100));
        } else {
            currentHealth += healthChange;
        }

        Mathf.Clamp(currentHealth, 0, maxHealth);

        GameUIManager.UpdateHealthBar(currentHealth / maxHealth);

        if (currentHealth < 0) {
            OnDeath();
        }
    }

    public virtual void OnDeath() {
        Destroy(gameObject);
    }
}
