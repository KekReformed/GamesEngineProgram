using UnityEngine;

[System.Serializable]
public abstract class Character 
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Transform transform;
    public float acceleration;
    public float deceleration;
    public float speedCap;
    
    public abstract void Move();
    public abstract void Update();
    public abstract void Start();
}