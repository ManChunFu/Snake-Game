using System.Collections.Generic;
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
            if (_body.Direction != new Vector3(0f, -0.7f, 0f))
                _body.Direction = new Vector3(0f, 0.7f, 0f);

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            if (_body.Direction != new Vector3(0f, 0.7f, 0f))
                _body.Direction = new Vector3(0f, -0.7f, 0f);

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            if(_body.Direction != new Vector3(0.7f, 0f, 0f))
               _body.Direction = new Vector3(-0.7f, 0f, 0f);

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            if (_body.Direction != new Vector3(-0.7f, 0f, 0f))
                _body.Direction = new Vector3(0.7f, 0f, 0f);

    }
   
}









