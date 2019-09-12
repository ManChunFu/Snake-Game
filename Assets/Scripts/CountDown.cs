using UnityEngine;
using UnityEngine.Assertions;

public class CountDown : MonoBehaviour
{
    private UIManager _uiManager;

    private void Awake()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        Assert.IsNotNull(_uiManager, "Failed to access to UIManager script.");
    }
    public void GameStart()
    {
        _uiManager.DisableCountDownPanel();
        Time.timeScale = 1;
    }
    
}
