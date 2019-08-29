using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

public class Apple : MonoBehaviour
{
    private float _xPos;
    private float _yPos;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Assert.IsNotNull(_spriteRenderer, "Failed to find the Sprite Renderer component.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Head")
            StartCoroutine(ChangePositionRoutine());
    }
    private IEnumerator ChangePositionRoutine()
    {
        yield return new WaitForSeconds(1f);
        _spriteRenderer.enabled = false;
        _xPos = Random.Range(-10f, 10f);
        _yPos = Random.Range(-6.5f, 6.5f);
        yield return new WaitForSeconds(2f);
        transform.position = new Vector3(_xPos, _yPos, 0f);
        _spriteRenderer.enabled = true;
    }

}

