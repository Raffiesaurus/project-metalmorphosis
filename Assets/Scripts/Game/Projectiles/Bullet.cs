using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour {

    public Rigidbody2D rb;
    public BoxCollider2D boxCollider;

    [SerializeField] public int damage;
    [SerializeField] public int speed;

    public void Start() {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    public void Update() { 
        
    }
    public abstract void OnFire(Vector3 startPoint, Vector3 firePoint);

    public abstract void OnCollision();
}