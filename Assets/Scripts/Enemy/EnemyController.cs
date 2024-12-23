using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyBlueprint enemyBlueprint;

    private Transform _playerTransform;
    private float _speed;
    private int _bodydamage;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _speed = enemyBlueprint.speed;
        _bodydamage = enemyBlueprint.bodyDamage;
    }

    private void Start()
    {
        if (enemyBlueprint.sprite != null)
        {
            _spriteRenderer.sprite = enemyBlueprint.sprite;
        }

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            _playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player GameObject with tag 'Player' not found!");
        }
    }

    private void Update()
    {
        if (_playerTransform != null)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, _playerTransform.position, _speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth _playerhealth = other.gameObject.GetComponent<PlayerHealth>();
            _playerhealth.TakeDamage(_bodydamage);
        }
    }
}