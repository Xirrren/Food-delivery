using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
#region Private Variables

    private Rigidbody2D rb;

    private bool canDash;

    [SerializeField]
    private float dashCooldown = 1f;

    [SerializeField]
    private float dashSpeed = 5f;

    private Vector2 moveDirection;
    private Vector2 dashDirection;

    [SerializeField]
    private float moveSpeed = 5f;

    private bool isDashing;

    [SerializeField]
    private bool foodInHand;

    public bool FoodInHand => foodInHand;

#endregion

#region Unity events

    void Start()
    {
        rb      = GetComponent<Rigidbody2D>();
        canDash = true;
    }

    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical   = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(horizontal , vertical).normalized;
        if (moveDirection != Vector2.zero && isDashing == false) dashDirection = new Vector2(horizontal , vertical).normalized;
        if (Input.GetKeyDown(KeyCode.Space) && isDashing == false)
        {
            if (dashDirection == Vector2.zero) dashDirection = Vector2.right;
            isDashing = true;
            Invoke(nameof(ResetDashCooldown) , dashCooldown);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!isDashing) return;
        if (foodInHand) return;
        if (col.gameObject.TryGetComponent(out PlayerCharacter player))
        {
            if (player.foodInHand == false) return;
            Debug.Log($"{col.gameObject.name}");
            foodInHand = true;
            player.DropFood();
        }
    }

    private void DropFood()
    {
        foodInHand = false;
    }

#endregion

#region Private Methods

    void FixedUpdate() // Physics updates should be in FixedUpdate
    {
        if (isDashing)
        {
            rb.velocity = dashDirection * dashSpeed;
            return;
        }

        var movement = moveDirection * moveSpeed;
        rb.velocity = movement;
    }

    private void ResetDashCooldown()
    {
        isDashing = false;
    }

#endregion

    public void StopDashing()
    {
        isDashing   = false;
        rb.velocity = Vector2.zero;
    }
}