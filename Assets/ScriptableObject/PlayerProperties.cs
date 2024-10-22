using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Player Preferences", fileName = "Player Preferences")]
public class PlayerProperties : ScriptableObject
{
    [SerializeField] private int maxHealth;

    [SerializeField] private float maxSpeed;
}
