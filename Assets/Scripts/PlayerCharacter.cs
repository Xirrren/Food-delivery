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

    private bool canMove;

    [SerializeField]
    private int playerIndex;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject food;

#endregion

#region Unity events

    void Start()
    {
        food.SetActive(false);
        animator.Play("Idle");
        rb          = GetComponent<Rigidbody2D>();
        canDash     = true;
        canMove     = true;
        dashKeyCode = playerIndex == 1 ? KeyCode.Space : KeyCode.RightControl;
    }

    private KeyCode dashKeyCode;

    private void Update()
    {
        PlayAnimationIfNotPlay(rb.velocity == Vector2.zero ? "Idle" : "Move");

        if (canMove == false) return;
        var horizontal = Input.GetAxisRaw($"Horizontal{playerIndex}");
        var vertical   = Input.GetAxisRaw($"Vertical{playerIndex}");
        moveDirection = new Vector2(horizontal , vertical).normalized;
        if (moveDirection != Vector2.zero && isDashing == false) dashDirection = new Vector2(horizontal , vertical).normalized;
        if (Input.GetKeyDown(dashKeyCode) && canDash)
        {
            if (dashDirection == Vector2.zero) dashDirection = Vector2.right;
            isDashing = true;
            Invoke(nameof(ResetDashCooldown) , dashCooldown);
        }
    }

    private void PlayAnimationIfNotPlay(string animationName)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(animationName) == false) animator.Play(animationName);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!isDashing) return;
        if (foodInHand) return;
        if (col.gameObject.TryGetComponent(out food)) GotFood();
        if (col.gameObject.TryGetComponent(out PlayerCharacter player))
        {
            if (player.foodInHand == false) return;
            player.DropFood();
            GotFood();
        }
    }

    private void GotFood()
    {
        food.SetActive(true);
        foodInHand = true;
    }

    private void DropFood()
    {
        foodInHand = false;
    }

#endregion

#region Private Methods

    void FixedUpdate() // Physics updates should be in FixedUpdate
    {
        if (canMove == false) return;
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
        canDash   = true;
    }

#endregion

    public void StopDashing()
    {
        isDashing   = false;
        rb.velocity = Vector2.zero;
    }

    public void DisableCanMove(float playerCanMoveTime)
    {
        canMove = false;
        Invoke(nameof(EnableCanMove) , playerCanMoveTime);
    }

    private void EnableCanMove()
    {
        canMove = true;
    }
}