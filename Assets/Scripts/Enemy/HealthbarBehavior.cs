using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarBehavior : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private Slider slider;
    [SerializeField] private Image fillArea;
    [SerializeField] private Color lowHealthColor;
    [SerializeField] private Color highHealthColor;
    [SerializeField] private Vector3 offset;
    
    private void Start()
    {
        slider.gameObject.SetActive(true);
        
        if (cam == null)
            cam = Camera.main;
    }

    private void Update()
    {
        slider.transform.position = cam.WorldToScreenPoint(transform.position + offset);
    }
    
    public void SetHealthbar(float health, float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = health;

        slider.gameObject.SetActive(health < maxHealth);

        if (slider.fillRect == null) return;
        
        Image fillImage = slider.fillRect.GetComponent<Image>();
        
        if (fillImage == null) return;
        float healthPercentage = Mathf.Clamp01(health / maxHealth);
        Color _color = fillImage.color = Color.Lerp(lowHealthColor, highHealthColor, healthPercentage);
        _color.a = 1;
        fillArea.color = _color;
    }


}
