﻿using Assets.Scripts.Snake;
using UnityEngine;
using UnityEngine.Assertions;

public class Body : MonoBehaviour
{
    public SnakeLinkedList Snake;

    [SerializeField] private GameObject _bodyPrefab;
    private Transform _head;
    private Transform _tail;

    public Vector3 Direction, Rotation;
    private float _gameTime;
    private float _limitToMove;

    private Apple _apple;
    private UIManager _uiManager;
    private SpawnManager _spawnManager;
    private GameManager _gameManager;

    private Animator _animatorHitWall;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip _hitWallSoundClip;


    private void Awake()
    {
        _head = transform.GetChild(0);
        Transform body = transform.GetChild(1);
        _tail = transform.GetChild(2);

        Snake = new SnakeLinkedList(_head, body, _tail);
        Snake.PreSetDirectionAndRotation(Direction, Rotation);

        _apple = GameObject.Find("Apple").GetComponent<Apple>();
        Assert.IsNotNull(_apple, "Failed to access the Apple script.");

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        Assert.IsNotNull(_uiManager, "Failed to access the UIManager script.");

        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        Assert.IsNotNull(_gameManager, "Failed to access the GameManager script.");

        _animatorHitWall = GetComponent<Animator>();
        Assert.IsNotNull(_animatorHitWall, "Failed to find the Animator component.");

        _audioSource = GetComponent<AudioSource>();
        Assert.IsNotNull(_audioSource, "Failed to find Audio Source componment.");

    }
    private void Start()
    {
        _gameTime = Time.time;

        SetSpeed();
    }

    private void Update()
    {
        if (Direction == new Vector3(0f, 0f, 0f))
            return;

        if (Time.time - _gameTime > _limitToMove)
        {
            if (_apple.EatApple)
            {
                _audioSource.Play();

                NewBodyGenerator();
                CheckWall(_head.position + Snake.Direction);
                TouchItSelf();
                CheckObstacle(_head.position);
                _gameTime = Time.time;
            }
            else
            {
                Snake.Move();
                CheckWall(_head.position + Snake.Direction);
                TouchItSelf();
                CheckObstacle(_head.position);
                _gameTime = Time.time;
            }
        }
    }

    private void SetSpeed()
    {
        switch (_gameManager.Level)
        {
            case 1:
                _limitToMove = 0.2f;
                break;
            case 2:
                _limitToMove = 0.15f;
                break;
            case 3:
                _limitToMove = 0.125f;
                break;
            case 4:
                _limitToMove = 0.1f;
                break;
            default:
                Debug.Log("Limit setting is not avilable.");
                break;
        }
    }


    private void NewBodyGenerator()
    {
        GameObject bodyClone = Instantiate(_bodyPrefab);
        bodyClone.transform.SetParent(transform);
        Snake.Grow(bodyClone.transform);
    }


    private void TouchItSelf()
    {
        if (Snake.IsHeadTouchingBody)
        {
            SnakeDie();
        }
    }

    private void CheckWall(Vector3 headPos)
    {
        if (headPos.x > 8f || headPos.x < -8f)
        {
            _animatorHitWall.SetTrigger("HitWall");
            SnakeDie();
        }
        else if (headPos.y > 4f || headPos.y < -4f)
        {
            _animatorHitWall.SetTrigger("HitWall");
            SnakeDie();
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
                    {
                        _animatorHitWall.SetTrigger("HitWall");
                        SnakeDie();
                    }
                }
            }
        }
    }

    public void SnakeDie()
    {
        AudioSource.PlayClipAtPoint(_hitWallSoundClip, Camera.main.transform.position, 1f);
        enabled = false;
        _uiManager.EnableGameOverPanel();
    }



}
