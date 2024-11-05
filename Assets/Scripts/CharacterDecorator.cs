using UnityEngine;

[System.Serializable]
public abstract class CharacterDecorator : Character
{
    protected Character character;

    public CharacterDecorator(Character character)
    {
        this.character = character;
    }

    public override void Attack()
    {
        character.Attack();
    }

    public override void Jump(Transform transform)
    {
        character.Jump(transform);
    }
    
    public override void Move()
    {
        character.Move();
    }
}