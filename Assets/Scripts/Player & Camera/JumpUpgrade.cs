
using UnityEngine;

public class JumpUpgrade : CharacterDecorator
{
    Player _player;
    
    public JumpUpgrade(Character character) : base(character)
    {
        _player = character as Player;
    }

    public override void Jump()
    {
        if (_player.GroundCheck()) _player.Jump();
    }
}
