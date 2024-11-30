using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MovingPlatform
{
    public override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        _moving = true;
    }
    
    public override void OnCollisionExit2D(Collision2D other)
    {
        base.OnCollisionExit2D(other);
        _moving = false;
    }
}
