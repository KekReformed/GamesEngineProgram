using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private Character player = new Player();

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) player.Jump();
        if(Input.GetKeyDown(KeyCode.F)) player.Attack();
        if (Input.GetKeyDown(KeyCode.U)) player = new DoubleJump(player);
    }
}
