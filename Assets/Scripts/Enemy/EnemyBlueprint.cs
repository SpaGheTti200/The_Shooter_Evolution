using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyBlueprint", menuName = "Enemy/EnemyBlueprint")]
public class EnemyBlueprint : ScriptableObject
{
    [Header("Stats")]
    public int maxHealth;
    public float speed;
    public int scoreValue;
    public int bodyDamage;

    [Header("Particles")]
    public GameObject hitParticlePrefab;
    public GameObject deathParticlePrefab;
    
    [Header("Appearance")]
    public Sprite sprite;
    // public Color enemyColor;
}