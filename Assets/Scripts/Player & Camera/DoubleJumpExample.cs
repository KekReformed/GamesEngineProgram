using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class DoubleJumpExample : CharacterDecorator
{ 
    public int extraJumps = 1;
    public int extraJumpMax = 1;
    Player _player;
    
    public DoubleJumpExample(Character character) : base(character)
    {
        _player = PlayerManager.main.player;
    }
    
    public override void Jump()
    {
        if (_player.GroundCheck()) _player.Jump();
        else if (extraJumps > 0)
        {
            _player.Jump();
            extraJumps -= 1;
        }
    }

    public override void Update()
    {
        base.Update();
        if (_player.GroundCheck()) extraJumps = extraJumpMax;
    }
}