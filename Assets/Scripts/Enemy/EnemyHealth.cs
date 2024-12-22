using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int scoreValue = 10;



    private void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0) Die();
    }
    
    public void Die()
    {
        if (PlayerScoreController.Instance != null)
        {
            PlayerScoreController.Instance.AddScore(scoreValue);
        }

        Destroy(gameObject);
    }
}
