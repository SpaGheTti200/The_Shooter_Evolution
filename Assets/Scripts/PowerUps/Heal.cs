


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
