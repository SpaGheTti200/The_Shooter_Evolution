using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable, IHealth
{
    [field: SerializeField]public int CurrentHealth { get; private set; }
    [field: SerializeField]public int MaxHealth { get; private set; }
    
    [SerializeField] private int scoreValue = 10;
    private HealthbarBehavior _healthbarBehavior;

    private void Awake()
    {
        _healthbarBehavior = GetComponent<HealthbarBehavior>();
    }

    private void Start()
    {
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
            PlayerScoreController.Instance.AddScore(scoreValue);
        }
        Debug.Log("Die2");
        Destroy(gameObject);
    }

    
}
