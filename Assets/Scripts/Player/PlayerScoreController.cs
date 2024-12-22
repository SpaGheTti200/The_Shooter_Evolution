

using System;
using UnityEngine;

public class PlayerScoreController : MonoBehaviour
{
    public static PlayerScoreController Instance; 

    public event Action<int> OnScoreChanged; 
    private int _score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        _score += amount;
        OnScoreChanged?.Invoke(_score); 
    }

    public int GetScore()
    {
        return _score;
    }
}