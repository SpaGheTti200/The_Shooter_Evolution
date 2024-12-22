using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyBlueprint enemyBlueprint;

    public int CurrentHealth { get; private set; }
    public int MaxHealth { get; private set; }

    private HealthbarBehavior _healthbarBehavior;

    private GameObject hitParticle;

    private void Awake()
    {
        _healthbarBehavior = GetComponent<HealthbarBehavior>();
    }

    private void Start()
    {
        // if (enemyBlueprint == null)
        // {
        //     Debug.LogError($"{gameObject.name}: EnemyBlueprint is null at runtime!");
        //     return;
        // }

        // Debug.Log($"{gameObject.name}: EnemyBlueprint assigned: {enemyBlueprint.name}");

        if (!enemyBlueprint.hitParticlePrefab)
        {
            // Debug.Log("Hit particle is not null");
            hitParticle = enemyBlueprint.hitParticlePrefab;
        }
        // else
        // {
        //     Debug.Log("Hit particle prefab is null");
        // }

        if (enemyBlueprint == null)
        {
            Debug.LogError("EnemyBlueprint not assigned!");
            return;
        }

        MaxHealth = enemyBlueprint.maxHealth;
        CurrentHealth = MaxHealth;


        GetComponentInChildren<SpriteRenderer>().color = enemyBlueprint.enemyColor;


        _healthbarBehavior.SetHealthbar(CurrentHealth, MaxHealth);
    }

    public void TakeDamage(float damage, Vector2 hitTransform)
    {
        CurrentHealth = (int)Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);
        _healthbarBehavior.SetHealthbar(CurrentHealth, MaxHealth);


        StartCoroutine(DamagedParticleController(hitTransform));

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    private IEnumerator DamagedParticleController(Vector2 hitTransform)
    {
        if (hitParticle == null)
        {
            Debug.LogError("Hit particle prefab is null! Cannot instantiate.");
            yield break;
        }

        // Convert Vector2 to Vector3
        Vector3 hitPosition = new Vector3(hitTransform.x, hitTransform.y, 0); 

        GameObject tempGo = Instantiate(hitParticle, hitPosition, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        Destroy(tempGo);
    }


    // private void DeathParticleController()
    // {
    // }

    public void Die()
    {
        if (enemyBlueprint.deathParticlePrefab != null)
        {
            Instantiate(enemyBlueprint.deathParticlePrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    // public void TakeDamage(float damage)
    // {
    //     throw new System.NotImplementedException();
    // }
}