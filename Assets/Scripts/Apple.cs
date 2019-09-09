using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

public class Apple : MonoBehaviour
{
    private float _xPos;
    private float _yPos;

    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] _sprites;
    public bool EatApple;
    public int AppleCount;

    private UIManager _uiManager;
    private Body _body;
    private SpawnManager _spawnManger;
    private GameManager _gameManager;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Assert.IsNotNull(_spriteRenderer, "Failed to find the Sprite Renderer component.");

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        Assert.IsNotNull(_uiManager, "Failed to access the UIManager script");

        _body = GameObject.Find("Snake").GetComponent<Body>();
        Assert.IsNotNull(_body, "Failed to access the Body script.");

        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        Assert.IsNotNull(_gameManager, "Failed to access the GameManager script.");
    }

    private void Start()
    {
        EatApple = false;
        AppleCount = 0;
        if (_gameManager.Level == 1)
            _spriteRenderer.sprite = _sprites[0];
        else if (_gameManager.Level == 2)
            _spriteRenderer.sprite = _sprites[1];

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Head")
        {
            EatApple = true;
            AppleCount++;
            if (AppleCount == 10)
                _gameManager.LoadLevel();
            _uiManager.UpdateScore(AppleCount);
            StartCoroutine(ChangePositionRoutine());
        }
    }

    private IEnumerator ChangePositionRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        _spriteRenderer.enabled = false;

        Vector3 applePos;
        do
        {
            _xPos = Random.Range(-10, 10) * 0.5f;
            _yPos = Random.Range(-5, 5) * 0.5f;
            applePos = new Vector3(_xPos, _yPos, 0f);
        } while (_body.Snake.IsAppleInsideBody(applePos) && IsAppleInsideObstacle(applePos));

        yield return new WaitForSeconds(0.2f);
        transform.position = applePos;
        _spriteRenderer.enabled = true;
        EatApple = false;
    }

    private bool IsAppleInsideObstacle(Vector3 applePos)
    {
        if (_gameManager.Level > 1)
        {
            _spawnManger = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
            if (_spawnManger != null)
            {
                foreach (Transform obstacle in _spawnManger.ObstacleList)
                {
                    if (obstacle.position == applePos)
                        return true;
                }
            }
            return false;
        }
        return false;
    }
}



