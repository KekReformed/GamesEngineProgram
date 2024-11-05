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

    private void Start()
    {
        _player = new Player(gameObject.GetComponent<Rigidbody2D>(), acceleration, deceleration, speedCap, jumpHeight,groundCheckDist);
        _ply = _player as Player;
        AddUpgrade<DoubleJump>();
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
        if (Input.GetKeyDown(KeyCode.U)) _player = new DoubleJump(_player);
        _player.Move();
    }
}
