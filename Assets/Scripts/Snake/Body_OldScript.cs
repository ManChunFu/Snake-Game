using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

public class Body_OldScript : MonoBehaviour
{
    public List<GameObject> SnakeBodyList = new List<GameObject>();

    [SerializeField] private GameObject _bodyPrefab;

    public Vector3 Direction = new Vector3(0f, 0f, 0f);
    private Vector3 _newHeadPos;
    private float _gameTime;

    [SerializeField] private Sprite[] _snakePartsSprites; // 0 = head, 1 = body, 2 = tail

    private Apple _apple;
    private bool _isGameOver;
    private UIManager _uiManager;

    public bool isTouched;
    public bool hitWall;

    private void Awake()
    {
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

        if (Time.time - _gameTime > 0.4f)
        {
            if (_apple.EatApple)
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
        _newHeadPos += Direction;
        GameObject bodyClone = Instantiate(_bodyPrefab, SnakeBodyList[0].transform.position + _newHeadPos, Quaternion.identity);
        bodyClone.transform.SetParent(transform);
        SnakeBodyList.Add(bodyClone);
        ApplyTag();
    }

    private void TouchItSelf(Vector3 headPos)
    {
        foreach (GameObject body in SnakeBodyList)
        {

            if (body.transform.position == headPos && body != SnakeBodyList.Last())
            {
                SnakeDie();
                isTouched = true;
            }
        }
    }

    private void CheckWall(Vector3 headPos)
    {
        if (headPos.x > 8f || headPos.x < -8f)
        {
            SnakeDie();
            hitWall = true;
        }
        else if (headPos.y > 3.5f || headPos.y < -3.5f)
        {
            SnakeDie();
            hitWall = true;
        }
    }

    private void SnakeDie()
    {
        _isGameOver = true;
        enabled = false;
        _uiManager.EnableGameOverPanel();

    }


}
