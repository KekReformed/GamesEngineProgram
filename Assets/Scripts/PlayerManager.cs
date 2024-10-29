using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerManager : MonoBehaviour
{
    
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    [SerializeField] private float speedCap;
    
    private Character player;

    private void Start()
    {
        player = new Player(gameObject.GetComponent<Rigidbody2D>(), acceleration, deceleration, speedCap);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) player.Jump();
        if(Input.GetKeyDown(KeyCode.F)) player.Attack();
        if (Input.GetKeyDown(KeyCode.U)) player = new DoubleJump(player);
        player.Move();
    }
}
