using System;
using UnityEngine;

public class EnemySimple : MonoBehaviour
{
    private Transform _playerTransform; 
    [SerializeField] private float speed = 5f;

    [SerializeField] private int damage = 1;

    private void Start()
    {
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
            transform.position = Vector3.MoveTowards(transform.position, _playerTransform.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth _playerhealth = other.gameObject.GetComponent<PlayerHealth>();
            _playerhealth.TakeDamage(damage);
            
        }
    }


}