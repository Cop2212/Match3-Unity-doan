using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelSetting : MonoBehaviour, IMenu
{
    [SerializeField] private Button btnBack;

    private UIMainManager m_mngr;

    private void Awake()
    {
        if (btnBack != null)
            btnBack.onClick.AddListener(OnClickBack);
    }

    private void OnDestroy()
    {
        if (btnBack != null)
            btnBack.onClick.RemoveAllListeners();
    }

    public void Setup(UIMainManager mngr)
    {
        m_mngr = mngr;
    }

    private void OnClickBack()
    {
        m_mngr.ShowMainMenu(); // Quay lại màn chính
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
