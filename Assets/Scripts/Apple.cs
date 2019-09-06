using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

public class Apple : MonoBehaviour
{
    private float _xPos;
    private float _yPos;

    private SpriteRenderer _spriteRenderer;
    public bool EatApple;
    private int _appleCount;

    private UIManager _uiManager;
    private Body _body;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Assert.IsNotNull(_spriteRenderer, "Failed to find the Sprite Renderer component.");

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        Assert.IsNotNull(_uiManager, "Failed to access the UIManager script");

        _body = GameObject.Find("Snake").GetComponent<Body>();
        Assert.IsNotNull(_body, "Failed to access the Body script.");
    }

    private void Start()
    {
        EatApple = false;
        _appleCount = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Head")
        {
            EatApple = true;
            _appleCount++;
            _uiManager.UpdateScore(_appleCount);
            StartCoroutine(ChangePositionRoutine());
        }
    }

    private IEnumerator ChangePositionRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        _spriteRenderer.enabled = false;

        Vector3 applePos;
        do
        {
            _xPos = Random.Range(-10, 10) * 0.5f;
            _yPos = Random.Range(-5, 5) * 0.5f;
            applePos = new Vector3(_xPos, _yPos, 0f);
        } while (_body.Snake.IsAppleInsideBody(applePos));
        
        yield return new WaitForSeconds(0.2f);
        transform.position = applePos;
        _spriteRenderer.enabled = true;
        EatApple = false;
    }

}

