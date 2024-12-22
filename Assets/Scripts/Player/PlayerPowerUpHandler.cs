using UnityEngine;

public class PlayerPowerUpHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPowerUp powerUp = collision.GetComponent<IPowerUp>();
        if (powerUp != null)
        {
            powerUp.Activate(gameObject);
        }
    }
}