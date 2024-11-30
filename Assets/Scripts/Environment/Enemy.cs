using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.transform.CompareTag("Player")) return;
        if(PlayerManager.main.player.attacking) Destroy(gameObject);
        else PlayerManager.main.player.Respawn();
    }
}
