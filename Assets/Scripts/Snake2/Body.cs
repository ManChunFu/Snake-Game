using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

public class Body : MonoBehaviour
{
    public List<GameObject> SnakeBodyList = new List<GameObject>();
    [SerializeField] private GameObject _bodyPrefab;
    [SerializeField] private GameObject _headPrefab;
    [SerializeField] private GameObject _tailPrefab;

    public Vector3 Direction = new Vector3(0f, 0f, 0f);
    private Vector3 _newHeadPos;
    private float _gameTime;

    [SerializeField] private Sprite[] _snakePartsSprites; // 0 = head, 1 = body, 2 = tail

    private Apple _apple;
    private bool _isGameOver;

    private void Awake()
    {
        _apple = GameObject.Find("Apple").GetComponent<Apple>();
        Assert.IsNotNull(_apple, "Failed to access the Apple script.");
    }
    private void Start()
    {
        _isGameOver = false;
        _newHeadPos = new Vector3(0f, 0f, 0f);
        for (int i = 0; i < 3; i++)
        {
            NewBodyGenerator();
        }
        _gameTime = Time.time;
    }

    private void Update()
    {
        if (Direction == new Vector3(0f, 0f, 0f))
            return;

        if (Time.time - _gameTime > 0.3f)
        {
            if (_apple.AteApple)
            {
                EatAppleMove();
                _gameTime = Time.time;
            }
            else
            {
                MoveSnake();
                _gameTime = Time.time;
            }
        }
    }

    private void NewBodyGenerator()
    {
        _newHeadPos += Direction;
        GameObject bodyClone = Instantiate(_bodyPrefab, _newHeadPos, Quaternion.identity);
        bodyClone.transform.SetParent(transform);
        SnakeBodyList.Add(bodyClone);
    }

    private void ApplyTag()
    {
        float totalCount = SnakeBodyList.Count;
        for (int i = 0; i < SnakeBodyList.Count - 1; i++)
        {
            SnakeBodyList[i].gameObject.tag = "Body";
        }
        SnakeBodyList[SnakeBodyList.Count - 1].gameObject.tag = "Head";
    }


    private void MoveSnake()
    {
        _newHeadPos += Direction;
        GameObject lastBody = SnakeBodyList.First();
        lastBody.transform.SetPositionAndRotation(_newHeadPos, Quaternion.identity);
        SnakeBodyList.RemoveAt(0);
        SnakeBodyList.Add(lastBody);

        CheckWall(_newHeadPos);

        TouchItSelf(_newHeadPos);

        ApplyTag();
    }

     private void EatAppleMove()
    {
        NewBodyGenerator();
        ApplyTag();
    }

    private void TouchItSelf(Vector3 headPos)
    {
        foreach (GameObject body in SnakeBodyList)
        {

            if (body.transform.position == headPos && body != SnakeBodyList.Last())
            {
                _isGameOver = true;
                enabled = false;
            }
        }
    }

    private void CheckWall(Vector3 headPos)
    {
        if (headPos.x > 7f || headPos.x < -7f)
        {
            _isGameOver = true;
            enabled = false;
        }
        else if (headPos.y > 3.5f || headPos.y < -3.5f)
        {
            _isGameOver = true;
            enabled = false;
        }
    }
   
}
