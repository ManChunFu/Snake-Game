using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    [SerializeField] private GameObject _bodyPrefab;
    private float _distanceBWParts = 0.6f;
    private Vector3 _currentPos; 
    private float _speed = 1.5f;
    private float _rotationSensetivity = 1f;
    public float _rotation;
   

    private void Start()
    {
        _rotation = 0f;
    }
    private void Update()
    {
        MovementController();
    }

    private void MovementController()
    {
        float walkInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(0f, -walkInput * _speed * Time.deltaTime, 0f));
        _rotation += rotationInput * _rotationSensetivity;
        transform.eulerAngles = new Vector3(0f, 0f, -_rotation);

    }

  

    private void SnakeBodyGenerator()
    {
        GameObject bodyClone = Instantiate(_bodyPrefab, _currentPos, Quaternion.identity);
        bodyClone.transform.SetParent(transform);
    }
}
