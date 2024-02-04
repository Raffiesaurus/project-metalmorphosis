using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    [SerializeField] public float moveSpeed = 5.0f;
    [SerializeField] public float jumpForce = 5.0f;

    [SerializeField] public float groundedGravity = 150.0f;
    [SerializeField] public float jumpGravity = 250.0f;

    [SerializeField] private Texture2D cursorTexture = null;

    [SerializeField] public GameObject playerSprites = null;

    private Rigidbody2D rb = null;
    private PlayerMain playerMain = null;

    public bool canJump = true;
    public bool isGrounded = true;

    private float moveHorizontal = 0.0f;
    private float moveVertical = 0.0f;
    private void OnEnable() {
        canJump = true;
        isGrounded = true;

        rb = GetComponent<Rigidbody2D>();
        playerMain = GetComponent<PlayerMain>();
    }

    void Start() {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    void Update() {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        if (moveHorizontal > 0.1f) {
            playerSprites.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        if (moveHorizontal < -0.1f) {
            playerSprites.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        if (Input.GetMouseButtonDown(0)) {
            playerMain.OnLeftClick(Input.mousePosition);
        }

        if (Input.GetMouseButtonDown(1)) {
            playerMain.OnRightClick(Input.mousePosition);
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

        if (Input.GetKeyDown(KeyCode.Space)) {
            PlayerJump();
        }

    }
    private void FixedUpdate() {

        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f) {
            rb.AddForce(new Vector2(moveHorizontal * moveSpeed, 0.0f), ForceMode2D.Impulse);
        }

        if (moveVertical > 0.1f) {
            PlayerJump();
        }

    }

    private void PlayerJump() {
        if (canJump) {
            isGrounded = false;
            canJump = false;
            rb.gravityScale = jumpGravity;
            rb.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Floor") {
            canJump = true;
            isGrounded = true;
            rb.gravityScale = groundedGravity;
        }
    }
}
