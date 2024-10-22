using UnityEngine;

public class DoubleJump : CharacterDecorator
{
    public DoubleJump(Character character) : base(character)
    {
        
    }

    public override void Jump()
    {
        base.Jump();
        Debug.Log("Double Jump!");
    }
}