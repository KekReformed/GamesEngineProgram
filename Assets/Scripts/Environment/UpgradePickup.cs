using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class UpgradePickup : MonoBehaviour
{

    public string typeName;
    Type _type;

    public void OnTriggerEnter2D(Collider2D col)
    {
        PlayerManager.main.AddUpgradeAtRun(Type.GetType(typeName));
    }
}
