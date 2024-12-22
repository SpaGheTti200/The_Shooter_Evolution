


using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    
    private PlayerHealth playerHealth; 
    [SerializeField] private Slider healthSlider; 
    [SerializeField] private Image fillImage;

    [SerializeField] private Color lowHealthColor = Color.red; 
    [SerializeField] private Color highHealthColor = Color.green; 
    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        
        if (playerHealth != null)
        {
            healthSlider.maxValue = playerHealth.maxHealth;
            healthSlider.value = playerHealth.currentHealth;

            UpdateSliderColor(playerHealth.currentHealth, playerHealth.maxHealth);

            playerHealth.OnHealthChanged += UpdateHealthUI;
        }

        PlayerHealth.OnPlayerHealthChanged += (h) =>
        {
            
        };
    }

    private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= UpdateHealthUI; 
        }
    }

    private void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        UpdateSliderColor(currentHealth, maxHealth);
    }

    private void UpdateSliderColor(int currentHealth, int maxHealth)
    {
        if (fillImage != null)
        {
            float healthPercentage = Mathf.Clamp01((float)currentHealth / maxHealth);

            Color interpolatedColor = Color.Lerp(lowHealthColor, highHealthColor, healthPercentage);
            interpolatedColor.a = 1; 

            fillImage.color = interpolatedColor;
        }
    }

}