using System;
using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]private BulletBlueprint bulletBlueprint;
    [HideInInspector] public float bulletDamage; 
    [field: SerializeField] private string TargetTag { get; set; } = "Enemy";

    // public float BulletDamage { get; set; } = 1;

    private Coroutine BulletCoroutine { get; set; }

    private void Start()
    {
        bulletDamage = bulletBlueprint.BulletDamage;
        StartSelfTerminateCoroutine(10);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!IsCollidedWithAnEnemy(other.gameObject)) return;

        var enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        GiveEnemySomeDamage(enemyHealth);

        StartSelfTerminateCoroutine(0);
    }

    private bool IsCollidedWithAnEnemy(GameObject go) =>
        go.CompareTag(TargetTag);

    private void GiveEnemySomeDamage(EnemyHealth enemyHealth)
    {
        if (!enemyHealth)
            throw new Exception("no enemyHealth");

        enemyHealth.TakeDamage(bulletDamage);
    }

    private void StartSelfTerminateCoroutine(int seconds)
    {
        if (BulletCoroutine != null)
        {
            StopCoroutine(BulletCoroutine);
            BulletCoroutine = null;
        }

        BulletCoroutine = StartCoroutine(SelfTerminate(seconds));
    }

    private IEnumerator SelfTerminate(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}