using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelPause : MonoBehaviour, IMenu
{
    private GameManager m_gameManager;
    [SerializeField] private Button btnHome;
    [SerializeField] private Button btnClose;
    [SerializeField] private Button btnShuffle;

    private UIMainManager m_mngr;

    private void Awake()
    {
        btnHome.onClick.AddListener(OnClickHome);
        btnClose.onClick.AddListener(OnClickClose);
        btnShuffle.onClick.AddListener(OnClickShuffle);
    }

    private void OnDestroy()
    {
        if (btnHome) btnHome.onClick.RemoveAllListeners();
        if (btnClose) btnClose.onClick.RemoveAllListeners();
        if (btnShuffle) btnClose.onClick.RemoveAllListeners();
    }

    public void Setup(UIMainManager mngr)
    {
        m_mngr = mngr;
        m_gameManager = GameManager.Instance;
    }

    private void OnClickHome()
    {
        // Chuyển về Main Menu
        m_mngr.ShowMainMenu();
    }

    private void OnClickShuffle()
    {
        m_gameManager.ClearLevel();

        m_gameManager.LoadLevel(GameManager.eLevelMode.MOVES);
    }


    private void OnClickClose()
    {
        m_mngr.ShowGameMenu();
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
