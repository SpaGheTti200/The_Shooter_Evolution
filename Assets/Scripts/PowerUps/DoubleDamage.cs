using System.Collections;
using UnityEngine;

public class DoubleDamage : MonoBehaviour, IPowerUp
{
    [SerializeField] private float damageMultiplier = 2f; 
    [SerializeField] private float duration = 5f; 

    private PlayerShooting _playerShooting;

    public void Activate(GameObject player)
    {
        _playerShooting = player.GetComponent<PlayerShooting>();
        if (_playerShooting != null)
        {
            _playerShooting.damageMultiplier *= damageMultiplier; 
        }

        player.GetComponent<PlayerPowerUpHandler>().StartCoroutine(DeactivateAfterTime(player));
    }

    public void Deactivate(GameObject player)
    {
        _playerShooting = player.GetComponent<PlayerShooting>();
        if (_playerShooting != null)
        {
            _playerShooting.damageMultiplier /= damageMultiplier; 
        }
    }

    private IEnumerator DeactivateAfterTime(GameObject player)
    {
        DisablePowerUpVisuals();
        yield return new WaitForSeconds(duration);
        Deactivate(player);
        Destroy(gameObject); 
    }

    private void DisablePowerUpVisuals()
    {
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }

        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }
    }
}