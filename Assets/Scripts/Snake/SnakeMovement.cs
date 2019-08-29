using UnityEngine;
using UnityEngine.Assertions;

public class SnakeMovement : MonoBehaviour
{
    private SnakeBodyGenerator _snakeBodyG;
    private float _speed = 2f;
    private float _rotationSensetivity = 1f;
    private float _rotation;

    private Vector3 _currentPos;
    private Vector3 _previousPos;
    private Vector3 _currentRot;
    private Vector3 _previousRot;

    private bool _headMoves = false;
    private bool _headRotate = false;

    void Start()
    {
        _snakeBodyG = GameObject.Find("Snake").GetComponent<SnakeBodyGenerator>();
        Assert.IsNotNull(_snakeBodyG, "Failed to access SnakeBodyGenerator script.");
    }

    // Update is called once per frame
    void Update()
    {
        MovementController();
    }

    private void MovementController()
    {
        float walkInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(0f, -walkInput * _speed * Time.deltaTime, 0f), Space.World);
        _currentPos = transform.position;
        _headMoves = true;
        _rotation += rotationInput * _rotationSensetivity;
        transform.eulerAngles = new Vector3(0f, 0f, -_rotation);
        _headRotate = true;




        if (_headMoves)
        {
            for (int index = 0; index < _snakeBodyG.snakeBody.Count; index++)
            {
                _snakeBodyG.snakeBody[index].Translate(_currentPos * _speed * Time.deltaTime);
            }



        }

    }
}
