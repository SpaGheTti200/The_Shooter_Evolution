using System;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField]private Camera mainCamera;
     private GameObject _aimIcon;

     public GameObject[] aimIcons;
     
    private void Start()
    {
        SetupCruser(aimIcons[0]);
        Cursor.visible = false;
    }
    
    void Update()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 dir = mousePosition - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        
        _aimIcon.transform.position = mousePosition;
    }

    private void SetupCruser(GameObject _cruser)
    {
        _aimIcon = Instantiate(_cruser, Vector3.zero, Quaternion.identity);
    }
}