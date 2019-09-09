using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private UIManager _uiManager;
    private Body _body;
    private Apple _apple;
    public int Level;

    private void Awake()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        Assert.IsNotNull(_uiManager, "Failied to access the UIManager script.");

        _body = GameObject.Find("Snake").GetComponent<Body>();
        Assert.IsNotNull(_body, "Failed to access the Body script.");

        _apple = GameObject.Find("Apple").GetComponent<Apple>();
        Assert.IsNotNull(_apple, "Failed to access the Apple script.");
    }

    public void LoadLevel()
    {
        if (_apple.AppleCount == 10)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartGame()
    {
        if (Level == 1)
            SceneManager.LoadScene(1);
        else if (Level == 2)
            SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
