using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    private float _speed = 1.5f;
    private float _rotationSensetivity = 1f;
    public float _rotation;
    public bool _isMoving;

    private void Start()
    {
        _isMoving = false;
        _rotation = 0f;
    }
    private void Update()
    {
        MovementController();
        _isMoving = false;
    }

    private void MovementController()
    {
        float walkInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(0f, -walkInput * _speed * Time.deltaTime, 0f));
        _rotation += rotationInput * _rotationSensetivity;
        transform.eulerAngles = new Vector3(0f, 0f, -_rotation);

        _isMoving = true;
    }
}
