using UnityEngine;

[System.Serializable]
public abstract class Character
{
    public abstract void Attack();
    public abstract void Jump(Transform transform);
    public abstract void Move();
}