using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingPlatform : MonoBehaviour
{
    [SerializeField] float speedMultiplier;
    [SerializeField] float jumpMultiplier;
    

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerManager.main.player.acceleration *= speedMultiplier;
        PlayerManager.main.player.speedCap *= speedMultiplier;
        PlayerManager.main.player.jumpHeight *= jumpMultiplier;
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        PlayerManager.main.player.acceleration /= speedMultiplier;
        PlayerManager.main.player.speedCap /= speedMultiplier;
        PlayerManager.main.player.jumpHeight /= jumpMultiplier;
    }
}
