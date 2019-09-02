using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

public class Apple : MonoBehaviour
{
    private float _xPos;
    private float _yPos;

    private SpriteRenderer _spriteRenderer;
    public bool AteApple;
    public int AppleCount;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Assert.IsNotNull(_spriteRenderer, "Failed to find the Sprite Renderer component.");
    }

    private void Start()
    {
        AteApple = false;
        AppleCount = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Head")
        {
            AteApple = true;
            AppleCount++;
            StartCoroutine(ChangePositionRoutine());
        }
    }

    private IEnumerator ChangePositionRoutine()
    {
        
        yield return new WaitForSeconds(0.2f);
        _spriteRenderer.enabled = false;
       

        _xPos = Random.Range(-10 , 10) * 0.7f;
        _yPos = Random.Range(-5, 5) * 0.7f;
        
        yield return new WaitForSeconds(0.3f);
        transform.position = new Vector3(_xPos, _yPos, 0f);
        _spriteRenderer.enabled = true;
        AteApple = false;
    }

}

