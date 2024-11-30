using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Windows;
using Input = UnityEngine.Input;
using Object = System.Object;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager main;
    
    Character _playerCharacter;
    [SerializeField] Player player;

    private void Awake()
    {
        if(main == null) main = this;

        _playerCharacter = player;
    }

    //Activator lets us create an instance of a class at runtime with dynamic types, allowing us to use type constraints to prevent use of anything thats not a valid decorator
    //This is good for idiot proofing
    public void AddUpgrade<T>() where T : CharacterDecorator
    {
        _playerCharacter = Activator.CreateInstance(typeof(T), _playerCharacter) as Character;
    }

    public void Start()
    {
        _playerCharacter.transform = transform;
        _playerCharacter.rb = gameObject.GetComponent<Rigidbody2D>();
        
        _playerCharacter.Start();
    }
    
    public void Update()
    {
        _playerCharacter.Update();
    }
}
