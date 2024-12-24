using System.Collections;
using UnityEngine;

public class DoubleDamage : MonoBehaviour, IPowerUp
{
    [SerializeField] private float damageMultiplier = 2f; 
    [SerializeField] private float duration = 5f;
    // private GameObject playerDoubleDamageEffectGameObject;
    [field: SerializeField]public GameObject effectsOnPlayer { get; set; }

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

    private void ActivatePlayerDoubleDamageEffect(GameObject player)
    {
        // playerDoubleDamageEffectGameObject = player.transform.Find("DoubleDamage_Effects").gameObject;
        effectsOnPlayer.SetActive(true);
    }

    private void DeactivatePlayerDoubleDamageEffect(GameObject player)
    {
        effectsOnPlayer.SetActive(false);
    }
    
    public void Activate(GameObject player)
    {
        _playerShooting = player.GetComponent<PlayerShooting>();
        if (_playerShooting != null)
        {
            _playerShooting.damageMultiplier *= damageMultiplier; 
        }

        ActivatePlayerDoubleDamageEffect(player);
        player.GetComponent<PlayerPowerUpHandler>().StartCoroutine(DeactivateAfterTime(player));
    }

    public void Deactivate(GameObject player)
    {
        _playerShooting = player.GetComponent<PlayerShooting>();
        if (_playerShooting != null)
        {
            _playerShooting.damageMultiplier /= damageMultiplier; 
        }

        DeactivatePlayerDoubleDamageEffect(player);
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