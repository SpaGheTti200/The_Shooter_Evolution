using System.Collections;
using UnityEngine;

public class DoubleDamage : MonoBehaviour, IPowerUp
{
    [SerializeField] private float damageMultiplier = 2f; 
    [SerializeField] private float duration = 5f; 

    [field: SerializeField]public GameObject fxGameobject { get; set; }
    [field: SerializeField]public Collider2D fxCollider { get; set; }
    [field: SerializeField]public GameObject fxClaimGameObject { get; set; }
    
    
    private PlayerShooting _playerShooting;

    public void ClaimedEffect()
    {
        StartCoroutine(clameParticleHandler());
    }

    private IEnumerator clameParticleHandler()
    {
        Debug.Log("Double Damage");
        GameObject clamedEffect = Instantiate(fxClaimGameObject, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(clamedEffect);
    }

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
        ClaimedEffect();
        DisablePowerUpVisuals();
        yield return new WaitForSeconds(duration);
        Deactivate(player);
        Destroy(gameObject); 
    }

    private void DisablePowerUpVisuals()
    {
        fxCollider.enabled = false;
        fxGameobject.SetActive(false);
    }
    
    
}