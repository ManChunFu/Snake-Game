using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField] private List<GameObject> _snakeBody = new List<GameObject>();
    [SerializeField] private GameObject _bodyPrefab;
    [SerializeField] private GameObject _headPrefab;
    [SerializeField] private GameObject _tailPrefab;

    public Vector3 Direction = new Vector3(-0.6f,0f, 0f);
    private Vector3 _firstBodyPos;
    private float _gameTime;

    [SerializeField] private Sprite[] _snakePartsSprites; // 0 = head, 1 = body, 2 = tail

    private void Start()
    {
        _firstBodyPos = new Vector3(0f, 0f, 0f);
        for (int i = 0; i < 3; i++)
        {
            NewBody();
        }
        _gameTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - _gameTime > 0.3f)
        {
            NewBody();
            Destroy(_snakeBody.First());
            _snakeBody.RemoveAt(0);
            _gameTime = Time.time;

            float totalCount = _snakeBody.Count;
            for (int i = 0; i < _snakeBody.Count - 1; i++)
            {
                _snakeBody[i].gameObject.tag = "Body";
            }
            _snakeBody[_snakeBody.Count - 1].gameObject.tag = "Head";
        }
    }

    private void NewBody()
    {
        _firstBodyPos += Direction;
        GameObject bodyClone = Instantiate(_bodyPrefab, _firstBodyPos, Quaternion.identity);
        bodyClone.transform.SetParent(transform);
        _snakeBody.Add(bodyClone);
    }

    private void ReplaceHeadNTail()
    {
        Destroy(_snakeBody.Last()); 
        _snakeBody[_snakeBody.Count - 1] = Instantiate(_headPrefab, _snakeBody[_snakeBody.Count - 1].transform.position + new Vector3(-0.2f, 0f, 0f), Quaternion.Euler(0f, 0f, -90f));
        _snakeBody[_snakeBody.Count - 1].transform.SetParent(transform);
        Destroy(_snakeBody.First());
        _snakeBody[0] = Instantiate(_tailPrefab, _snakeBody[0].transform.position + new Vector3(0.6f, 0f, 0f), Quaternion.identity);
        _snakeBody[0].transform.SetParent(transform);


    }
}
