using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _image;
    [SerializeField] private Text _score;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Text _level;
    [SerializeField] private GameObject _levelCompletePanel;
    [SerializeField] private GameObject _youWinPanel;
    [SerializeField] private GameObject _countDownPanel;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        Assert.IsNotNull(_gameManager, "Failed to access the GameManager script.");
    }
    private void Start()
    {
        _score.text = 00.ToString().PadLeft(2, '0');
        _gameOverPanel.SetActive(false);
        _level.text = "LEVEL " + _gameManager.Level.ToString();
        _levelCompletePanel.SetActive(false);
        _countDownPanel.SetActive(true);

        if (_gameManager.Level == 4)
            _youWinPanel.SetActive(false);

        SetUIImage();
    }

    public void UpdateScore(int appleCount)
    {
        _score.text = appleCount.ToString().PadLeft(2, '0');
    }

    public void EnableGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
    }

    public void EnableLevelCompletePanel()
    {
        _levelCompletePanel.SetActive(true);
    }

    public void EnableYouWinPanel()
    {
        _youWinPanel.SetActive(true);
    }

    public void DisableCountDownPanel()
    {
        _countDownPanel.SetActive(false);
    }

    private void SetUIImage()
    {
        switch (_gameManager.Level)
        {
            case 1:
                _image.sprite = _sprites[0];
                break;
            case 2:
                _image.sprite = _sprites[1];
                break;
            case 3:
                _image.sprite = _sprites[2];
                break;
            case 4:
                _image.sprite = _sprites[3];
                break;
            default:
                Debug.Log("No image found.");
                break;
        }
    }
}
