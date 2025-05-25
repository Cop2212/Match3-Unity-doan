using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelGame : MonoBehaviour,IMenu
{
    public Text LevelConditionView;
    [SerializeField] private Text currentScoreText;
    [SerializeField] private Text highScoreText;

    [SerializeField] private Button btnPause;

    private UIMainManager m_mngr;

    private void Start()
    {
        GameManager.Instance.scoreManager.OnScoreChanged += UpdateScore;
        GameManager.Instance.scoreManager.OnHighScoreChanged += UpdateHighScore;

        // Khởi tạo hiển thị điểm và điểm cao
        UpdateScore(GameManager.Instance.scoreManager.CurrentScore);
        UpdateHighScore(GameManager.Instance.scoreManager.HighScore);
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.scoreManager.OnScoreChanged -= UpdateScore;
            GameManager.Instance.scoreManager.OnHighScoreChanged -= UpdateHighScore;
        }
    }

    private void Awake()
    {
        btnPause.onClick.AddListener(OnClickPause);
    }

    private void OnClickPause()
    {
        m_mngr.ShowPauseMenu();
    }

    public void Setup(UIMainManager mngr)
    {
        m_mngr = mngr;
        UpdateScore(GameManager.Instance.scoreManager.CurrentScore);
        UpdateHighScore(GameManager.Instance.scoreManager.HighScore);
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        if (currentScoreText != null)
            currentScoreText.text = $"Score: {score}"; // Format giống LevelConditionView
    }

    public void UpdateHighScore(int highScore)
    {
        Debug.Log($"🟢 UI UpdateHighScore: {highScore}");
        if (highScoreText != null)
            highScoreText.text = $"HIGH: {highScore}";
    }
}
