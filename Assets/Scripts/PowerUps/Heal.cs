


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour, IPowerUp
{
    [SerializeField] int healAmount;
    PlayerHealth playerHealth;

    public void Activate(GameObject gameObject)
    {
        playerHealth = gameObject.GetComponent<PlayerHealth>();
        playerHealth.AddHealth(healAmount);

        DestoyThePowerUp();
    }

    public void Deactivate(GameObject gameObject)
    {
        return;
    }
    
    private void DestoyThePowerUp()
    {
        Destroy(gameObject);
    }
}
