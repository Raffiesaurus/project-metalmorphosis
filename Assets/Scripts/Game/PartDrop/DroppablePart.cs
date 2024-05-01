using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PartDropData {
    [HideInInspector] public ArmPart leftArm;
    [HideInInspector] public ArmPart rightArm;
    [HideInInspector] public HeadPart head;
    [HideInInspector] public LegPart legs;
    [HideInInspector] public ArmPart torso;
    [HideInInspector] public string partName;
    [HideInInspector] public string partRarity;
    [HideInInspector] public string partType;
    [HideInInspector] public string partDescription;
    [HideInInspector] public string partConsumption;
    [SerializeField] public Sprite partImage;
}

public class DroppablePart : MonoBehaviour {

    [HideInInspector] public PartType partType;
    [HideInInspector] public PartRarity partRarity = PartRarity.Unassigned;
    [HideInInspector] public string partName;

    [HideInInspector] public Rigidbody2D rb;

    [HideInInspector] public BoxCollider2D boxCol;

    [HideInInspector] public Sprite assignedImage;

    [SerializeField] private Sprite[] partImages;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
        FormItem();
    }

    public virtual void SetData(PartType type, Vector2 spawnPoint, PartRarity rarity) {
        transform.position = spawnPoint;
        partType = type;
        partRarity = rarity;

        rb.AddForce(new(0, 200));

        FormItem();
    }

    public virtual void FormItem() { }

    public virtual void Update() {
        if (LevelManager.RemainingEnemies == 0) {
            gameObject.layer = LayerMask.NameToLayer("PartDrop");
        } else {
            gameObject.layer = LayerMask.NameToLayer("PartDropInactive");
        }
    }

    public virtual void OnCollisionEnter2D(Collision2D collision) {
    }

    public virtual void OnCollisionExit2D(Collision2D collision) {
    }

}
