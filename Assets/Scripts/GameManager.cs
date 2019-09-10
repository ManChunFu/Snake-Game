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

    public void LevelComplete()
    {
        _uiManager.EnableLevelCompletePanel();
    }

    public void RestartGame()
    {
        switch (Level)
        {
            case 1:
                SceneManager.LoadScene(1);
                break;
            case 2:
                SceneManager.LoadScene(2);
                break;
            case 3:
                SceneManager.LoadScene(3);
                break;
            default:
                Debug.Log("No scene to load");
                break;
        }
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
