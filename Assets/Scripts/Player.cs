using System;
using UnityEngine;

public class Player : Character 
{
    private Rigidbody2D _rb;
    private float _acceleration;
    private float _deceleration;
    private float _speedCap;

    public Player(Rigidbody2D rb, float acceleration, float decceleration, float speedCap)
    {
        _rb = rb;
        _acceleration = acceleration;
        _deceleration = decceleration;
        _speedCap = speedCap;
    }
    public override void Attack()
    {
        Debug.Log("First Attack!");
    }
    public override void Jump(){
        Debug.Log("First Jump!");
    }

    public override void Move()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput != 0)
        {
            _rb.velocity += new Vector2(_acceleration * horizontalInput * Time.deltaTime, 0);
            _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x,-_speedCap,_speedCap), _rb.velocity.y);
        }
        else
        {
            Vector2 moveChange = _rb.velocity + new Vector2(-_deceleration * Mathf.Sign(_rb.velocity.x) * Time.deltaTime, 0);
            if (Mathf.Sign(_rb.velocity.x) != Mathf.Sign(moveChange.x)) moveChange.x = 0;
            _rb.velocity = moveChange;
        };
    }
}