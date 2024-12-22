

using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action<int> OnPlayerHealthChanged; 

    public int currentHealth;
    public int maxHealth;

    public event Action<int, int> OnHealthChanged; 

    private void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth, maxHealth); 
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"Player {gameObject.name} taking damage {damage}");
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth); 

        if (currentHealth <= 0)
        {
            PerformDeath();
        }
        
        OnPlayerHealthChanged?.Invoke(currentHealth);
    }

    public void AddHealth(int health)
    {
        currentHealth = Mathf.Clamp(currentHealth + health, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    private void PerformDeath()
    {
        Destroy(gameObject); 
    }
}