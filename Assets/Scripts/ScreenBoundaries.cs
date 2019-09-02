using UnityEngine;

public class ScreenBoundaries : MonoBehaviour
{
    private Vector3 _screenBound;
    private Vector3 _viewPosition;
    private float _snakeWidth;
    private float _snakeLength;
    void Start()
    {
        _screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        _snakeWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        _snakeLength = GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _viewPosition = transform.position;
        _viewPosition.x = Mathf.Clamp(_viewPosition.x, _screenBound.x + _snakeWidth, _screenBound.x * -1);
        _viewPosition.y = Mathf.Clamp(_viewPosition.y, _screenBound.y + _snakeLength, _screenBound.y * -1);
        transform.position = _viewPosition;
    }
}
