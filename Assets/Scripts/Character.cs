using UnityEngine;

[System.Serializable]
public abstract class Character
{
    public bool grounded;
    public abstract void OnGround();
    public abstract void Attack();
    public abstract void Jump(Transform transform);
    public abstract void Move();
}