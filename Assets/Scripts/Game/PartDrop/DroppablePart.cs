using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppablePart : MonoBehaviour {

    [HideInInspector] public PartType partType;
    [HideInInspector] public PartRarity partRarity;

    [HideInInspector] public Rigidbody2D rb;

    [HideInInspector] public BoxCollider2D boxCol;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    public virtual void SetData(PartType type, Vector2 spawnPoint, PartRarity rarity) {
        transform.position = spawnPoint;
        partType = type;
        partRarity = rarity;

        rb.AddForce(new(0, 200));

        FormItem();
    }

    public virtual void FormItem() { }

    public virtual void OnCollisionEnter2D(Collision2D collision) { }

    public virtual void OnCollisionExit2D(Collision2D collision) { }

}
