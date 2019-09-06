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

    [SerializeField] private Sprite[] _snakePartsSprites; // 0 = head, 1 = body, 2 = tail

    private Apple _apple;
    private bool _isGameOver;
    private UIManager _uiManager;

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
    }
    private void Start()
    {
        isTouched = false;
        hitWall = false;
        _isGameOver = false;
        
        _gameTime = Time.time;
    }

    private void Update()
    {
        if (Direction == new Vector3(0f, 0f, 0f))
            return;

        if (Time.time - _gameTime > 0.4f)
        {
            if (_apple.EatApple)
            {
                NewBodyGenerator();
                CheckWall(_head.position + Direction);
                TouchItSelf();
                _gameTime = Time.time;
            }
            else
            {
                Snake.Move(Direction, Rotation);
                CheckWall(_head.position + Direction);
                TouchItSelf();
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

    public void SnakeDie()
    {
        _isGameOver = true;
        enabled = false;
        _uiManager.EnableGameOverPanel();
    }

   

}
