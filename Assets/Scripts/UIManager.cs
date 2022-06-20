using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UIManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Button _MenuButton;

    [SerializeField]
    private Menu _MenuPrefab;

    [SerializeField]
    private Canvas UIParent;

    [SerializeField]
    private GameObject _Blocker;

    [SerializeField]
    private Button _RestartButton;

    [SerializeField]
    private TextMeshProUGUI _ScoreText;

    [SerializeField]
    private TextMeshProUGUI _BestScoreText;

    private GameObject _CurrentWindow;


    internal void SetCurrentScoreText(int score)
    {
        _ScoreText.text = score.ToString();
    }
    internal void SetBestScoreText(int score)
    {
        _BestScoreText.text = score.ToString();
    }
    public void OnMenuButtonClick()
    {
        _Blocker.SetActive(true);
        GameManager.Instance.PauseGame();
        _CurrentWindow = Instantiate(_MenuPrefab.gameObject, UIParent.transform);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == _Blocker)
        {
            Destroy(_CurrentWindow);
            _Blocker.SetActive(false);
            GameManager.Instance.ResumeGame();
        }
    }

    public void OnRestartClick()
    {
        GameManager.Instance.Restart();
    }
}
