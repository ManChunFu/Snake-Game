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
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            _body.Direction = new Vector3(0f, 0.6f, 0f);
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            _body.Direction = new Vector3(0f, -0.6f, 0f);
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            _body.Direction = new Vector3(-0.6f, 0f, 0f);
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            _body.Direction = new Vector3(0.6f, 0f, 0f);

    }
   
}









