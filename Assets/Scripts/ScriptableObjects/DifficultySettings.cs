using UnityEngine;

[CreateAssetMenu(fileName = "DifficultySettings", menuName = "Game/Config/Difficulty")]
public class DifficultySettings : ScriptableObject
{
    [Header("Enemies")]
    public float enemyHealthMultiplier = 1f;
    public float enemyDamageMultiplier = 1f;
    public int enemiesPerWave = 5;

    [Header("Player")]
    public float playerHealthRegen = 0.1f;
}
