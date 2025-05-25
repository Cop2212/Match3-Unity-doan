using UnityEngine;
using UnityEngine.UI;

public class UIToggleSound : MonoBehaviour
{
    [SerializeField] private Sprite soundOn;
    [SerializeField] private Sprite soundOff;

    private Button m_btnSound;
    private Image m_sprite;

    private void Awake()
    {
        m_btnSound = GetComponent<Button>();
        m_sprite = GetComponent<Image>();
    }

    private void OnEnable()
    {
        m_btnSound.onClick.AddListener(OnClickSound);
        UpdateVisual();
    }

    private void OnDisable()
    {
        if (m_btnSound) m_btnSound.onClick.RemoveAllListeners();
    }

    private void OnClickSound()
    {
        SoundManager.Instance.ToggleSound();
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        if (m_sprite != null)
        {
            m_sprite.sprite = SoundManager.Instance.IsSoundOn ? soundOn : soundOff;
        }
    }
}
