using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private Transform shootPoint; 
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private ParticleSystem fireParticle;
    [SerializeField] private ParticleSystem airParticle;

    public float damageMultiplier = 1;
    
    private PlayerInput _playerInput;
    private InputAction _shootAction;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _shootAction = _playerInput.actions["Shoot"];
    }

    private void OnEnable()
    {
        _shootAction.performed += OnShoot;
    }

    private void OnDisable()
    {
        _shootAction.performed -= OnShoot;
    }

    private void OnShoot(InputAction.CallbackContext ctx)
    {
        Shoot();
    }

    private void Shoot()
    {
        GameObject shotBullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        ShootParticleController();
        
        float tempdamage = shotBullet.GetComponent<BulletController>().bulletDamage * damageMultiplier;
        shotBullet.GetComponent<BulletController>().bulletDamage = tempdamage;

        Rigidbody2D rb = shotBullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = shootPoint.up * bulletSpeed;
        }
        else
        {
            Debug.LogError("Bullet prefab is missing a Rigidbody2D component!");
        }
    }

    private void ShootParticleController()
    {
        fireParticle.Play(true);
        // airParticle.Play(true);
    }
}