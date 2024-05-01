using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private readonly int MaxJumpCount = 1;

    private bool isGrounded = false;
    private Rigidbody2D rb = null;
    private BoxCollider2D boxCol = null;
    private PlayerMain playerMain = null;
    private float moveHorizontal = 0.0f;
    private float moveVertical = 0.0f;

    [SerializeField] private BoxCollider2D[] boxCols;

    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Texture2D cursorTexture = null;
    [SerializeField] private GameObject playerSprites = null;

    [HideInInspector] private int jumpCount = 0;
    [HideInInspector] private float moveSpeedMultiplier = 1.0f;

    private bool isLeftClickPressed = false;
    private bool isRightClickPressed = false;

    void OnEnable() {
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
        playerMain = GetComponent<PlayerMain>();
    }

    void Start() {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    void Update() {

        if (GameUIManager.IsInMapScreen || GameUIManager.IsInSwapScreen) { rb.velocity = Vector2.zero; return; }

        moveHorizontal = Input.GetAxisRaw("Horizontal");
        //moveVertical = Input.GetAxisRaw("Vertical");

        CheckGround();

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.z;

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 mousePoint = new(worldMousePosition.x, worldMousePosition.y, transform.position.z);

        CheckSideFacing(mousePoint);

        if (Input.GetMouseButtonDown(0)) {
            isLeftClickPressed = true;
        }

        if (Input.GetMouseButtonUp(0)) {
            isLeftClickPressed = false;
        }

        if (Input.GetMouseButtonDown(1)) {
            isRightClickPressed = true;
        }

        if (Input.GetMouseButtonUp(1)) {
            isRightClickPressed = false;
        }

        if (isLeftClickPressed) {
            playerMain.OnLeftClick(mousePoint);
        }

        if (isRightClickPressed) {
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
            rb.velocity = new(moveHorizontal * moveSpeed * moveSpeedMultiplier * playerMain.legSpeedMulti, rb.velocity.y);
        } else {
            rb.velocity = new(0, rb.velocity.y);
        }
        playerMain.playerAnimator.SetFloat("Speed", rb.velocity.x);

        /*if (moveVertical > 0.1f) {
            moveVertical = 0.0f;
            Debug.Log("Calling Jump " + moveVertical);
            PlayerJump();
        }*/

    }

    void PlayerJump() {
        if (isGrounded || jumpCount < MaxJumpCount) {
            jumpCount++;
            playerMain.playerAnimator.SetTrigger("Jump");
            rb.velocity = new(rb.velocity.x, jumpForce);
        }
    }

    void CheckGround() {
        bool checkGroundNow = Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.down, 0.01f, groundLayer);
        //bool checkGroundNows = Physics2D.BoxCast(boxCols[0].bounds.center, boxCols[0].bounds.size, 0f, Vector2.down, 0.01f, groundLayer)
        //    || Physics2D.BoxCast(boxCols[1].bounds.center, boxCols[1].bounds.size, 0f, Vector2.down, 0.01f, groundLayer);
        if (checkGroundNow != isGrounded) {
            isGrounded = checkGroundNow;
            if (isGrounded) {
                jumpCount = 0;
            }
        }
    }

    void CheckSideFacing(Vector3 mousePoint) {


        if ((mousePoint.x - transform.position.x) > 0) {
            playerSprites.transform.localScale = new(Math.Abs(playerSprites.transform.localScale.x), playerSprites.transform.localScale.y, playerSprites.transform.localScale.z);
        }

        if ((mousePoint.x - transform.position.x) < 0) {
            playerSprites.transform.localScale = new(-Math.Abs(playerSprites.transform.localScale.x), playerSprites.transform.localScale.y, playerSprites.transform.localScale.z);
        }

        if (moveHorizontal > 0.1f) {
            playerSprites.transform.localScale = new(Math.Abs(playerSprites.transform.localScale.x), playerSprites.transform.localScale.y, playerSprites.transform.localScale.z);
        }

        if (moveHorizontal < -0.1f) {
            playerSprites.transform.localScale = new(-Math.Abs(playerSprites.transform.localScale.x), playerSprites.transform.localScale.y, playerSprites.transform.localScale.z);
        }

    }

    void CheckFallGravity() {

    }

    void UpdateMoveSpeed(float newSpeed) {
        moveSpeed = newSpeed;
    }

    void Crouch() {

    }

    void Slide() {

    }
}
