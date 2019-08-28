using UnityEngine;
using UnityEngine.Assertions;

public class SnakeBody : MonoBehaviour
{
    private SnakeHead _snakeHead;

    private float _speed = 1.5f;

    private void Awake()
    {
        _snakeHead = GameObject.Find("Snake_Head").GetComponent<SnakeHead>();
        Assert.IsNotNull(_snakeHead, "Failed to access SnakeHead script.");
    }


    private void Update()
    {
        

        if (_snakeHead._isMoving)
        {
            MovementController();
        }
    }

    private void MovementController()
    {
        float moveInput = Input.GetAxis("Horizontal");

        transform.Translate(0f, moveInput * _speed * Time.deltaTime, 0f);
    }
}
