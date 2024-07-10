﻿using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    public Vector2 moveDir;
    public Vector2 direction;
    public Vector2 movement;
    private float speed = 8f;
    private bool isFacingRight = true;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if(Instance == null)
        {
            Instance = this;
        } 
    }

    private void Update()
    {
        InputManager();
        if (isDashing)
        {
            return;
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
        Flip();
        animator.SetFloat("Speed", Mathf.Abs(movement.x));
        animator.SetFloat("SpeedVertical", Mathf.Abs(movement.y));
    }

    public void InputManager()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        direction = movement.normalized;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }


    private void Flip()
    {
        if (isFacingRight && movement.x < 0f || !isFacingRight && movement.x > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        // Xác định hướng dựa trên input
        Vector2 dashDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        dashDirection.Normalize(); // Đảm bảo hướng là một vector có độ dài bằng 1

        // Nếu không có input, sử dụng hướng hiện tại của nhân vật
        if (dashDirection == Vector2.zero)
        {
            dashDirection = new Vector2(transform.localScale.x, transform.localScale.y);
        }

        // Gán vận tốc dựa trên hướng
        rb.velocity = dashDirection * dashingPower;
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

    }
}