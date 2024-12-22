using System;
using UnityEngine;

public static class EventManager
{
    public static Action<int> OnScoreChanged;
    public static Action<int, int> OnHealthChanged;
    public static Action OnEnemyDied;

    public static void RaiseScoreChanged(int score) => OnScoreChanged?.Invoke(score);
    public static void RaiseHealthChanged(int currentHealth, int maxHealth) => OnHealthChanged?.Invoke(currentHealth, maxHealth);
    public static void RaiseEnemyDied() => OnEnemyDied?.Invoke();
}