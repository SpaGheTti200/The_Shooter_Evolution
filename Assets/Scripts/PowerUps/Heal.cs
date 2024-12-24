


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour, IPowerUp
{
    [SerializeField] int healAmount;
    PlayerHealth playerHealth;
    
    [field: SerializeField]public GameObject fxGameobject { get; set; }
    [field: SerializeField]public Collider2D fxCollider { get; set; }
    [field: SerializeField]public GameObject fxClaimGameObject { get; set; }

    // private GameObject playerHealEffect;
    [field: SerializeField]public GameObject effectsOnPlayer { get; set; }
    public void ClaimedEffect()
    {
        StartCoroutine(clameParticleHandler());
    }

    private IEnumerator clameParticleHandler()
    {
        Debug.Log("Double Damage");
        GameObject clamedEffect = Instantiate(fxClaimGameObject, transform.position, Quaternion.identity);
        Debug.Log("Double Damage1");
        yield return new WaitForSeconds(1f);
        Destroy(clamedEffect);
    }

    public void Activate(GameObject player)
    {
        StartCoroutine(ActiceDeactivePlayerHealEffect(player));
        playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.AddHealth(healAmount);
        ClaimedEffect();
        
        DestoyThePowerUp();
    }

    private IEnumerator ActiceDeactivePlayerHealEffect(GameObject player)
    {
        // playerHealEffect = player.transform.Find("Heal_EffectsQWE").gameObject;
        effectsOnPlayer.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        effectsOnPlayer.SetActive(false);
        // Destroy(playerHealEffect);
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
