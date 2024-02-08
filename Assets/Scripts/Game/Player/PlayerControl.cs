using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private bool isGrounded = false;
    private Rigidbody2D rb = null;
    private BoxCollider2D boxCol = null;
    private PlayerMain playerMain = null;
    private float moveHorizontal = 0.0f;
    private float moveVertical = 0.0f;

    [SerializeField] private int maxJumpCount = 1;
    [SerializeField] private int jumpCount = 0;
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Texture2D cursorTexture = null;
    [SerializeField] private GameObject playerSprites = null;

    void OnEnable() {
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
        playerMain = GetComponent<PlayerMain>();
    }

    void Start() {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    void Update() {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        //moveVertical = Input.GetAxisRaw("Vertical");

        CheckGround();

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.z;

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 mousePoint = new Vector3(worldMousePosition.x, worldMousePosition.y, transform.position.z);

        CheckSideFacing(mousePoint);

        if (Input.GetMouseButtonDown(0)) {
            playerMain.OnLeftClick(mousePoint);
        }

        if (Input.GetMouseButtonDown(1)) {
            playerMain.OnRightClick(mousePoint);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            playerMain.OnShiftClick();
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            playerMain.OnUtilityOne();
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            playerMain.OnUtilityTwo();
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) {
            PlayerJump();
        }

    }
    void FixedUpdate() {

        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f) {
            rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);
        } else {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        /*if (moveVertical > 0.1f) {
            moveVertical = 0.0f;
            Debug.Log("Calling Jump " + moveVertical);
            PlayerJump();
        }*/

    }

    void PlayerJump() {
        if (isGrounded || jumpCount < maxJumpCount) {
            jumpCount++;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "floor") {

        }
    }

    void CheckGround() {
        bool checkGroundNow = Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.down, 0.01f, groundLayer);
        if (checkGroundNow != isGrounded) {
            isGrounded = checkGroundNow;
            if (isGrounded) {
                jumpCount = 0;
            }
        }
    }

    void CheckSideFacing(Vector3 mousePoint) {

        if (moveHorizontal > 0.1f) {
            playerSprites.transform.localScale = new Vector3(Math.Abs(playerSprites.transform.localScale.x), playerSprites.transform.localScale.y, playerSprites.transform.localScale.z);
        }

        if (moveHorizontal < -0.1f) {
            playerSprites.transform.localScale = new Vector3(-Math.Abs(playerSprites.transform.localScale.x), playerSprites.transform.localScale.y, playerSprites.transform.localScale.z);
        }

        if ((mousePoint.x - transform.position.x) > 0) {
            playerSprites.transform.localScale = new Vector3(Math.Abs(playerSprites.transform.localScale.x), playerSprites.transform.localScale.y, playerSprites.transform.localScale.z);
        }

        if ((mousePoint.x - transform.position.x) < 0) {
            playerSprites.transform.localScale = new Vector3(-Math.Abs(playerSprites.transform.localScale.x), playerSprites.transform.localScale.y, playerSprites.transform.localScale.z);
        }

    }

    void CheckFallGravity() {

    }
}
