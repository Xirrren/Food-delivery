using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() // Physics updates should be in FixedUpdate
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical   = Input.GetAxisRaw("Vertical");
        var movement   = new Vector2(horizontal , vertical).normalized * moveSpeed;
        rb.velocity = movement;
    }
}