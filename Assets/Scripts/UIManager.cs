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

        if (_gameManager.Level == 1)
            _image.sprite = _sprites[0];
        else if (_gameManager.Level == 2)
            _image.sprite = _sprites[1];
    }

    public void UpdateScore(int appleCount)
    {
        _score.text = appleCount.ToString().PadLeft(2, '0');
    }

    public void EnableGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
    }
   

}
