using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;
using Object = System.Object;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager main;

    [Header("Base Movement")]
    private LayerMask _playerLayer;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    [SerializeField] private float speedCap;
    [SerializeField] private float jumpHeight;
    [SerializeField][Range(0.01f,0.5f)] private float groundCheckDist;
    
    private Character _player;

    private Player _ply;

    private void Awake()
    {
        if(main == null) main = this;
    }
    
    public bool GroundCheck(Transform transform)
    {
        RaycastHit2D hit;
        hit = Physics2D.BoxCast(transform.position, transform.localScale, transform.rotation.z, Vector2.down,
            groundCheckDist, ~_playerLayer);
        return hit;
    }

    private void Start()
    {
        _playerLayer = LayerMask.GetMask("Player");
        
        _player = new Player(gameObject.GetComponent<Rigidbody2D>(), acceleration, deceleration, speedCap, jumpHeight);
        _ply = _player as Player;
        AddUpgrade<DoubleJumpExample>();
    }

    //Activator lets us create an instance of a class at runtime with dynamic types, allowing us to use type constraints to prevent use of anything thats not a valid decorator
    //This is good for idiot proofing
    public void AddUpgrade<T>() where T : CharacterDecorator
    {
        _player = Activator.CreateInstance(typeof(T), _player) as Character;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) _player.Jump(transform);
        if (Input.GetKeyDown(KeyCode.F)) _player.Attack();
        _player.grounded = GroundCheck(transform);
        if(_player.grounded) _player.OnGround();
        _player.Move();
    }
}
