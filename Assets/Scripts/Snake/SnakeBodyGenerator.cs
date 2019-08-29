using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyGenerator : MonoBehaviour
{
    public List<Transform> snakeBody = new List<Transform>();
    [SerializeField] private GameObject _bodyPrefab;

    private float _startFristBodyPoint = 0.8f;
    private Vector3 _disBtwParts = new Vector3(0.7f, 0f, 0f);
    private Vector3 _currentPos;
    private Vector3 _previousPos;


    private GameObject _bodyClone;

    void Start()
    {
        FirstBodyPartGenerator();

        RestBodyPartGenerator();
        RestBodyPartGenerator();
        RestBodyPartGenerator();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FirstBodyPartGenerator()
    {
        _bodyClone = Instantiate(_bodyPrefab, transform.position + new Vector3(_startFristBodyPoint, 0f, 0f), Quaternion.identity);
        _bodyClone.transform.SetParent(transform);
        snakeBody.Add(_bodyClone.transform);
    }

    private void RestBodyPartGenerator()
    {
        _previousPos = snakeBody[snakeBody.Count - 1].position;
        _currentPos = _previousPos + _disBtwParts;

        _bodyClone = Instantiate(_bodyPrefab, _currentPos, snakeBody[snakeBody.Count - 1].rotation);
        _bodyClone.transform.SetParent(transform);
        snakeBody.Add(_bodyClone.transform);
    }
}
