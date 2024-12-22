using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;

    public int maxHealth; 

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int _damage)
    {
        Debug.Log($"Player {gameObject.name} taking damage {_damage}");
        currentHealth -= _damage;
        if (currentHealth <= 0)
        {
            PerformDeath();
        }
    }

    private void PerformDeath()
    {
        Destroy(gameObject);
    }

    public void AddHealth(int _health)
    {
        if (currentHealth + _health > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += _health;
        }
    }
}
