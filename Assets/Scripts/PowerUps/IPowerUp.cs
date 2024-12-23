using UnityEngine;

public interface IPowerUp
{
    void ClaimedEffect();
    void Activate(GameObject gameObject);
    void Deactivate(GameObject gameObject);

     public GameObject fxGameobject { get; set; }
     public GameObject fxClaimGameObject { get; set; }
     public Collider2D fxCollider { get; set; }
     
}