
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = "0";
    }

    private void OnEnable()
    {
        if (PlayerScoreController.Instance != null)
        {
            PlayerScoreController.Instance.OnScoreChanged += UpdateScoreText;
        }
    }

    private void OnDisable()
    {
        if (PlayerScoreController.Instance != null)
        {
            PlayerScoreController.Instance.OnScoreChanged -= UpdateScoreText;
        }
    }

    private void UpdateScoreText(int newScore)
    {
        scoreText.text = $"Score: {newScore}";
    }
}