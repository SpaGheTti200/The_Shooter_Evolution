using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haste : MonoBehaviour, IPowerUp
{
    [SerializeField] private float speedMultiplier = 2f;
    [SerializeField] private float duration = 5f;
    // [SerializeField] private Collider2D _collider2D;
    // [SerializeField] private GameObject fx;
    
    
    [field: SerializeField]public GameObject fxGameobject { get; set; }
    [field: SerializeField]public Collider2D fxCollider { get; set; }
    [field: SerializeField]public GameObject fxClaimGameObject { get; set; }
    
    PlayerMovement _movement;

    public void ClaimedEffect()
    {
        StartCoroutine(clameParticleHandler());
    }

    private IEnumerator clameParticleHandler()
    {
        // Debug.Log("Double Damage");
        GameObject clamedEffect = Instantiate(fxClaimGameObject, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(clamedEffect);
    }

    public void Activate(GameObject player)
    {
        _movement = player.GetComponent<PlayerMovement>();
        if (_movement != null)
        {
            _movement.speed *= speedMultiplier; 
        }

        StartCoroutine(DeactivateAfterTime(player));
        // player.GetComponent<PlayerPowerUpHandler>().StartCoroutine(DeactivateAfterTime(player));
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
        // Debug.Log("ASD");
        // SpriteRenderer _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        // _spriteRenderer.enabled = false;
        // if(fxCollider == null) Debug.Log("No Collider found");
        
        fxCollider.enabled = false;
        fxGameobject.SetActive(false);
    }
}
