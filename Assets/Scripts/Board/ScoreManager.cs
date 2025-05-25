using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    public int CurrentScore { get; private set; }
    public int HighScore { get; private set; }

    public event Action<int> OnScoreChanged;
    public event Action<int> OnHighScoreChanged;

    private const string HIGH_SCORE_KEY = "HIGH_SCORE";

    public ScoreManager()
    {
        LoadHighScore();
    }

    public void AddScore(int amount)
    {
        CurrentScore += amount;
        OnScoreChanged?.Invoke(CurrentScore);

        if (CurrentScore > HighScore)
        {
            Debug.Log($"🎯 New HighScore! CurrentScore: {CurrentScore}, Previous HighScore: {HighScore}");
            HighScore = CurrentScore;
            SaveHighScore();
            OnHighScoreChanged?.Invoke(HighScore);
        }
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        OnScoreChanged?.Invoke(CurrentScore);
    }

    private void LoadHighScore()
    {
        HighScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt(HIGH_SCORE_KEY, HighScore);
        PlayerPrefs.Save();
    }
}

