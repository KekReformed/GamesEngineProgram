using System;
using UnityEngine;

public class UpgradePickup : MonoBehaviour
{

    public string typeName;
    Type _type;

    public void OnTriggerEnter2D(Collider2D col)
    {
        PlayerManager.main.AddUpgradeAtRun(Type.GetType(typeName));
        Destroy(gameObject);
    }
}
