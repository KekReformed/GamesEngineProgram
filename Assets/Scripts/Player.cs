using System;
using UnityEngine;

public class Player : Character 
{
    public override void Attack()
    {
        Debug.Log("First Attack!");
    }
    public override void Jump(){
        Debug.Log("First Jump!");
    }

    public override void Move(Rigidbody2D rb, float acceleration, float deceleration, float speedCap)
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            rb.velocity += new Vector2(acceleration * Input.GetAxisRaw("Horizontal") * Time.deltaTime, 0);
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x,-speedCap,speedCap), rb.velocity.y);
        }
        else
        {
            Vector2 moveChange = rb.velocity + new Vector2(-deceleration * Mathf.Sign(rb.velocity.x) * Time.deltaTime, 0);
            if (Mathf.Sign(rb.velocity.x) != Mathf.Sign(moveChange.x)) moveChange.x = 0;
            rb.velocity = moveChange;
        };
    }
}