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

    private Player ply;

    private void Start()
    {
        player = new Player(gameObject.GetComponent<Rigidbody2D>(), acceleration, deceleration, speedCap);
        ply = player as Player;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) player.Jump(transform);
        if (Input.GetKeyDown(KeyCode.F)) player.Attack();
        if (Input.GetKeyDown(KeyCode.U)) player = new DoubleJump(player);
        player.Move();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, Vector2.down * 1);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(transform.position + Vector3.down * 0.1f, transform.localScale);
        }
    }
}
