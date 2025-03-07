﻿using UnityEngine;

[System.Serializable]
public abstract class CharacterDecorator : Character
{
    protected Character character;

    public CharacterDecorator(Character character)
    {
        this.character = character;
    }

    public override void Start()
    {
        character.Start();
    }

    public override void Jump()
    {
        character.Jump();
    }

    public override void Attack()
    {
        character.Attack();
    }

    public override void Update()
    {
        character.Update();
    }
    
    public override void Move()
    {
        character.Move();
    }
}