using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private string targetTag = "Enemy"; 
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Bang!!!");
        if( other.CompareTag(targetTag)) Destroy(gameObject); 
    }
    

}
