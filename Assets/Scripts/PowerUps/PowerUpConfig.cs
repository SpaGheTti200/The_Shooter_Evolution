using UnityEngine;

[CreateAssetMenu(fileName = "NewPowerUp", menuName = "PowerUps/PowerUpData")]
public class PowerUpData : ScriptableObject
{
    public string powerUpName;       
    public float duration;           
    public Color powerUpColor;   
}
