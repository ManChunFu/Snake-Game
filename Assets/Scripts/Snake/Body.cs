using Assets.Scripts.Snake;
using UnityEngine;
using UnityEngine.Assertions;

public class Body : MonoBehaviour
{
    public SnakeLinkedList Snake;

    [SerializeField] private GameObject _bodyPrefab;
    private Transform _head;
    private Transform _tail;

    public Vector3 Direction = new Vector3(0f, 0f, 0f);
    public Vector3 Rotation = new Vector3(0f, 0f, 0f);
    private float _gameTime;
    private float _limitToMove;

    private Apple _apple;
    private bool _isGameOver;
    private UIManager _uiManager;
    private SpawnManager _spawnManager;
    private GameManager _gameManager;

    public bool isTouched;
    public bool hitWall;

    private void Awake()
    {
        _head = transform.GetChild(0);
        Transform body = transform.GetChild(1);
        _tail = transform.GetChild(2);

        Snake = new SnakeLinkedList(_head, body, _tail);

        _apple = GameObject.Find("Apple").GetComponent<Apple>();
        Assert.IsNotNull(_apple, "Failed to access the Apple script.");

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        Assert.IsNotNull(_uiManager, "Failed to access the UIManager script.");

        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        Assert.IsNotNull(_gameManager, "Failed to access the GameManager script.");
    }
    private void Start()
    {
        isTouched = false;
        hitWall = false;
        _isGameOver = false;
        
        _gameTime = Time.time;

        if (_gameManager.Level == 1)
            _limitToMove = 0.3f;
        else if (_gameManager.Level == 2)
            _limitToMove = 0.2f;
    }

    private void Update()
    {
        if (Direction == new Vector3(0f, 0f, 0f))
            return;

        if (Time.time - _gameTime > _limitToMove)
        {
            if (_apple.EatApple)
            {
                NewBodyGenerator();
                CheckWall(_head.position + Direction);
                TouchItSelf();
                CheckObstacle(_head.position + Direction);
                _gameTime = Time.time;
            }
            else
            {
                Snake.Move(Direction, Rotation);
                CheckWall(_head.position + Direction);
                TouchItSelf();
                CheckObstacle(_head.position + Direction);
                _gameTime = Time.time;
            }
        }
    }


    private void NewBodyGenerator()
    {
        GameObject bodyClone = Instantiate(_bodyPrefab);
        bodyClone.transform.SetParent(transform);
        Snake.Grow(bodyClone.transform, Direction, Rotation);
    }

    
    private void TouchItSelf()
    {
        if (Snake.IsHeadTouchingBody)
        {
            SnakeDie();
            isTouched = true;
        }
    }

    private void CheckWall(Vector3 headPos)
    {
        if (headPos.x > 8f || headPos.x < -8f)
        {
            SnakeDie();
            hitWall = true;
        }
        else if (headPos.y > 4f || headPos.y < -4f)
        {
            SnakeDie();
            hitWall = true;
        }
    }

    private void CheckObstacle(Vector3 headPos)
    {
        if (_gameManager.Level > 1)
        {
            _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

            if (_spawnManager != null)
            {
                foreach (Transform obstacle in _spawnManager.ObstacleList)
                {
                    if (obstacle.position == headPos)
                        SnakeDie();
                }
            }
        }
    }

    public void SnakeDie()
    {
        _isGameOver = true;
        enabled = false;
        _uiManager.EnableGameOverPanel();
    }

   
}
