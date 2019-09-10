using UnityEngine;
using UnityEngine.Assertions;

public class PlayerInput : MonoBehaviour
{
    private Body _body;
   
    private void Awake()
    {
        _body = GetComponent<Body>();
        Assert.IsNotNull(_body, "Failed to access Body script.");
    }

    private void Update()
    {
        MovementController();
    }

    private void MovementController()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            if (_body.Snake.Direction != new Vector3(0f, -0.5f, 0f))
            {
                _body.Snake.PreSetDirectionAndRotation(new Vector3(0f, 0.5f, 0f),new Vector3(0f, 0f, -90f));
                return;
            }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            if (_body.Snake.Direction != new Vector3(0f, 0.5f, 0f))
            {
                _body.Snake.PreSetDirectionAndRotation(new Vector3(0f, -0.5f, 0f), new Vector3(0f, 0f, 90f));
                return;
            }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            if (_body.Snake.Direction != new Vector3(0.5f, 0f, 0f))
            {
                _body.Snake.PreSetDirectionAndRotation(new Vector3(-0.5f, 0f, 0f), new Vector3(0f, 0f, 0f));
                return;
            }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            if (_body.Snake.Direction != new Vector3(-0.5f, 0f, 0f))
            {
                _body.Snake.PreSetDirectionAndRotation(new Vector3(0.5f, 0f, 0f), new Vector3(0f, 0f, -180f));
                return;
            }
    }
   
}









