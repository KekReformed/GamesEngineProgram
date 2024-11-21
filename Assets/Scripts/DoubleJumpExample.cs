using UnityEngine;

public class DoubleJumpExample : CharacterDecorator
{
    public int ExtraJumps = 1;
    public int ExtraJumpMax = 1;
    public DoubleJumpExample(Character character) : base(character)
    {
        
    }
    
    public override void Jump(Transform transform)
    {
        if (grounded) base.Jump(transform);
        else if (ExtraJumps > 0)
        {
            base.Jump(transform);
            ExtraJumps -= 1;
            Debug.Log(ExtraJumps);
        }
    }

    public override void OnGround()
    {
        base.OnGround();
        ExtraJumps = ExtraJumpMax;
    }
}