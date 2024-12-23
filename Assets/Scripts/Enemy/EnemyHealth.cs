using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable, IHealth
{
    private EnemyBlueprint enemyBlueprint;
    private EnemyController _enemyController;
    [field: SerializeField]public int CurrentHealth { get; private set; }
    [field: SerializeField]public int MaxHealth { get; private set; }
    
    private HealthbarBehavior _healthbarBehavior;

    private void Awake()
    {
        _enemyController = GetComponent<EnemyController>();
        _healthbarBehavior = GetComponent<HealthbarBehavior>();
        enemyBlueprint = _enemyController.enemyBlueprint;
    }

    private void Start()
    {
        InitializeHealth();
    }

    private void InitializeHealth()
    {
        MaxHealth = enemyBlueprint.maxHealth;
        CurrentHealth = MaxHealth;
        
        _healthbarBehavior.SetHealthbar(CurrentHealth, MaxHealth);
    }
    
    public void TakeDamage(float damage)
    {
        CurrentHealth = (int)Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);
        _healthbarBehavior.SetHealthbar(CurrentHealth, MaxHealth);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }
    
    public void Die()
    {
        Debug.Log("Die1");
        if (PlayerScoreController.Instance != null)
        {
            PlayerScoreController.Instance.AddScore(enemyBlueprint.scoreValue);
        }
        Debug.Log("Die2");
        Destroy(gameObject);
    }

    
}
