using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text score;
    [SerializeField] private GameObject _gameOverPanel;

    private void Start()
    {
        score.text = 00.ToString().PadLeft(2, '0');
        _gameOverPanel.SetActive(false);
    }

    public void UpdateScore(int appleCount)
    {
        score.text = appleCount.ToString().PadLeft(2, '0');
    }

    public void EnableGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
    }
    public void DisableGameOverPanel()
    {
        _gameOverPanel.SetActive(false);
    }

}
