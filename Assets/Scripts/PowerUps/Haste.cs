using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haste : MonoBehaviour, IPowerUp
{
    [SerializeField] private float speedMultiplier = 2f;
    [SerializeField] private float duration = 5f;
    
    PlayerMovement _movement;

    public void Activate(GameObject player)
    {
        _movement = player.GetComponent<PlayerMovement>();
        if (_movement != null)
        {
            _movement.speed *= speedMultiplier; 
        }

        player.GetComponent<PlayerPowerUpHandler>().StartCoroutine(DeactivateAfterTime(player));
    }

    public void Deactivate(GameObject player)
    {
        _movement = player.GetComponent<PlayerMovement>();
        if (_movement != null)
        {
            _movement.speed /= speedMultiplier; 
        }
    }
    
    private IEnumerator DeactivateAfterTime(GameObject player)
    {
        DestoyThePowerUp();
        yield return new WaitForSeconds(duration);
        Deactivate(player);
        Destroy(gameObject); 
    }

    private void DestoyThePowerUp()
    {
        SpriteRenderer _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _spriteRenderer.enabled = false;

        PolygonCollider2D _collider2D = GetComponent<PolygonCollider2D>();
        _collider2D.enabled = false;
    }
}
