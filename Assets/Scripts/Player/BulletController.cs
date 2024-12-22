using System;
using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [field: SerializeField] private string TargetTag { get; set; } = "Enemy";

    public float BulletDamage { get; set; } = 1;

    private Coroutine BulletCoroutine { get; set; }

    private void Start()
    {
        StartSelfTerminateCoroutine(10);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!IsCollidedWithAnEnemy(other.gameObject)) return;

        var enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        
        Vector2 collisionPoint = other.ClosestPoint(transform.position);
        
        GiveEnemySomeDamage(enemyHealth, collisionPoint);

        StartSelfTerminateCoroutine(0);
    }

    private bool IsCollidedWithAnEnemy(GameObject go) =>
        go.CompareTag(TargetTag);

    private void GiveEnemySomeDamage(EnemyHealth enemyHealth, Vector2 hitTransform)
    {
        if (!enemyHealth)
            throw new Exception("no enemyHealth");

        enemyHealth.TakeDamage(BulletDamage, hitTransform);
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