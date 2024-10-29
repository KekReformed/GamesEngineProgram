using UnityEngine;

public class DoubleJump : CharacterDecorator
{
    public DoubleJump(Character character) : base(character)
    {
        
    }

    public override void Jump(Transform transform)
    {
        base.Jump(transform);
        Debug.Log("Double Jump!");
    }
}