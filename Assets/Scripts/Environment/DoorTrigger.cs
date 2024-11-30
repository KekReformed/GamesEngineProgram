using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] MovingPlatform platform;

    void OnTriggerEnter2D(Collider2D other)
    {
        platform.moving = true;
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        platform.moving = false;
    }
}
