using System;
using UnityEngine;

[System.Serializable]
public class Player : Character 
{
    private Rigidbody2D _rb;
    private float _acceleration;
    private float _deceleration;
    private float _speedCap;
    private float _jumpHeight;
    private float _groundCheckDist;
    private LayerMask _playerLayer;

    public Player(Rigidbody2D rb, float acceleration, float decceleration, float speedCap, float jumpHeight, float groundCheckDist)
    {
        _rb = rb;
        _acceleration = acceleration;
        _deceleration = decceleration;
        _speedCap = speedCap;
        _playerLayer = LayerMask.GetMask("Player");
        _jumpHeight = jumpHeight;
        _groundCheckDist = groundCheckDist;
        
        var myLayer = (1 << rb.gameObject.layer) & _playerLayer;
        
        if(myLayer == 0) Debug.LogError("You need to add your player character to a layer called Player!");
    }

    public virtual bool GroundCheck(Transform transform)
    {
        RaycastHit2D hit;
        hit = Physics2D.BoxCast(transform.position, transform.localScale, transform.rotation.z, Vector2.down,
            _groundCheckDist, ~_playerLayer);
        return hit;
    }
    
    public override void Attack()
    {
        Debug.Log("First Attack!");
    }
    public override void Jump(Transform transform){
        if (GroundCheck(transform))
        {
            _rb.velocity += new Vector2(_rb.velocity.x, _jumpHeight);
        }
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