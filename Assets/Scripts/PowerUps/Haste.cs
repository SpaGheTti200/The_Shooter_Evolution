using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haste : MonoBehaviour, IPowerUp
{
    [SerializeField] private float speedMultiplier = 2f;
    [SerializeField] private float duration = 5f;

    // private GameObject playerJetGameObject;
    [field: SerializeField]public GameObject effectsOnPlayer { get; set; }
    
    
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

        ActivatePlayerJetEffects(player);
        ClaimedEffect();
        StartCoroutine(DeactivateAfterTime(player));
    }

    private void ActivatePlayerJetEffects(GameObject player)
    {
        // playerJetGameObject = player.transform.Find("Heal_EffectsQWE").gameObject;
        effectsOnPlayer.SetActive(true);
    }

    private void DeactivatePlayerJetEffects(GameObject player)
    {
        effectsOnPlayer.SetActive(false);
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
        DeactivatePlayerJetEffects(player);
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
