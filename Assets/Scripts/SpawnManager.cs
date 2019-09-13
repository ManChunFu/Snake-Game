using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _obstaclePrefab;

    public List<Transform> ObstacleList = new List<Transform>();

    private float _spawnX;
    private float _spawnY;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        Assert.IsNotNull(_gameManager, "Failed to access the GameManager script.");
    }

    private void Start()
    {
        if (ObstacleList != null)
            ObstacleList.Clear();

        if (_gameManager.Level == 1)
            return;

        SpawnLeftUpCorner();
        SpawnLeftDownCorner();
        SpawnRightUpCorner();
        SpawnRightDownCorner();
    }
    private void SpawnObstacle(float x, float y, float z)
    {
        GameObject obstacleClone = Instantiate(_obstaclePrefab, new Vector3(x, y, z), Quaternion.identity);
        obstacleClone.transform.SetParent(transform);
        ObstacleList.Add(obstacleClone.transform);
    }

    private void SpawnLeftUpCorner()
    {
        if (_gameManager.Level == 2)
        {
            SpawnObstacle(-5f, 2.5f, 0f);
            SpawnObstacle(-5f, 2f, 0f);
            SpawnObstacle(-5f, 1.5f, 0f);
            SpawnObstacle(-5f, 1f, 0f);
            SpawnObstacle(-5.5f, 2.5f, 0f);
            SpawnObstacle(-5.5f, 2f, 0f);
            SpawnObstacle(-5.5f, 1.5f, 0f);
            SpawnObstacle(-5.5f, 1f, 0f);
            SpawnObstacle(-6f, 1.5f, 0f);
            SpawnObstacle(-6f, 1f, 0f);
            SpawnObstacle(-6.5f, 1.5f, 0f);
            SpawnObstacle(-6.5f, 1f, 0f);
        }

        if (_gameManager.Level == 3)
        {
            SpawnObstacle(-5.5f, 2.5f, 0f);
            SpawnObstacle(-5f, 2.5f, 0f);
            SpawnObstacle(-4.5f, 2.5f, 0f);
            SpawnObstacle(-4f, 2.5f, 0f);
            SpawnObstacle(-4.5f, 2f, 0f);
            SpawnObstacle(-4f, 2f, 0f);
            SpawnObstacle(-3.5f, 2f, 0f);
            SpawnObstacle(-3f, 2f, 0f);
            SpawnObstacle(-3.5f, 1.5f, 0f);
            SpawnObstacle(-3f, 1.5f, 0f);
            SpawnObstacle(-2.5f, 1.5f, 0f);
            SpawnObstacle(-2f, 1.5f, 0f);
        }

        if (_gameManager.Level == 4)
        {
            SpawnObstacle(-5f, 2.5f, 0f);
            SpawnObstacle(-4.5f, 2.5f, 0f);
            SpawnObstacle(-4f, 2.5f, 0f);
            SpawnObstacle(-3.5f, 2.5f, 0f);
            SpawnObstacle(-3f, 2.5f, 0f);
            SpawnObstacle(-2.5f, 2.5f, 0f);
            SpawnObstacle(-2f, 2.5f, 0f);
            SpawnObstacle(-1.5f, 2.5f, 0f);
            SpawnObstacle(-1f, 2.5f, 0f);
            SpawnObstacle(-5f, 1f, 0f);
            SpawnObstacle(-5f, 0.5f, 0f);
            SpawnObstacle(-5f, 0f, 0f);
            SpawnObstacle(-5f, -0.5f, 0f);
            SpawnObstacle(-5f, -1f, 0f);
        }

    }

    private void SpawnLeftDownCorner()
    {
        if (_gameManager.Level == 2)
        {
            SpawnObstacle(-5f, -2.5f, 0f);
            SpawnObstacle(-5f, -2f, 0f);
            SpawnObstacle(-5f, -1.5f, 0f);
            SpawnObstacle(-5f, -1f, 0f);
            SpawnObstacle(-5.5f, -2.5f, 0f);
            SpawnObstacle(-5.5f, -2f, 0f);
            SpawnObstacle(-5.5f, -1.5f, 0f);
            SpawnObstacle(-5.5f, -1f, 0f);
            SpawnObstacle(-6f, -1.5f, 0f);
            SpawnObstacle(-6f, -1f, 0f);
            SpawnObstacle(-6.5f, -1.5f, 0f);
            SpawnObstacle(-6.5f, -1f, 0f);
        }

        if (_gameManager.Level == 3)
        {
            SpawnObstacle(-5.5f, -2.5f, 0f);
            SpawnObstacle(-5f, -2.5f, 0f);
            SpawnObstacle(-4.5f, -2.5f, 0f);
            SpawnObstacle(-4f, -2.5f, 0f);
            SpawnObstacle(-4.5f, -2f, 0f);
            SpawnObstacle(-4f, -2f, 0f);
            SpawnObstacle(-3.5f, -2f, 0f);
            SpawnObstacle(-3f, -2f, 0f);
            SpawnObstacle(-3.5f, -1.5f, 0f);
            SpawnObstacle(-3f, -1.5f, 0f);
            SpawnObstacle(-2.5f, -1.5f, 0f);
            SpawnObstacle(-2f, -1.5f, 0f);
        }

        if (_gameManager.Level == 4)
        {
            SpawnObstacle(-5f, -2.5f, 0f);
            SpawnObstacle(-4.5f, -2.5f, 0f);
            SpawnObstacle(-4f, -2.5f, 0f);
            SpawnObstacle(-3.5f, -2.5f, 0f);
            SpawnObstacle(-3f, -2.5f, 0f);
            SpawnObstacle(-2.5f, -2.5f, 0f);
            SpawnObstacle(-2f, -2.5f, 0f);
            SpawnObstacle(-1.5f, -2.5f, 0f);
            SpawnObstacle(-1f, -2.5f, 0f);
        }
    }

    private void SpawnRightUpCorner()
    {
        if (_gameManager.Level == 2)
        {
            SpawnObstacle(5f, 2.5f, 0f);
            SpawnObstacle(5f, 2f, 0f);
            SpawnObstacle(5f, 1.5f, 0f);
            SpawnObstacle(5f, 1f, 0f);
            SpawnObstacle(5.5f, 2.5f, 0f);
            SpawnObstacle(5.5f, 2f, 0f);
            SpawnObstacle(5.5f, 1.5f, 0f);
            SpawnObstacle(5.5f, 1f, 0f);
            SpawnObstacle(6f, 1.5f, 0f);
            SpawnObstacle(6f, 1f, 0f);
            SpawnObstacle(6.5f, 1.5f, 0f);
            SpawnObstacle(6.5f, 1f, 0f);
        }

        if (_gameManager.Level == 3)
        {
            SpawnObstacle(5.5f, 2.5f, 0f);
            SpawnObstacle(5f, 2.5f, 0f);
            SpawnObstacle(4.5f, 2.5f, 0f);
            SpawnObstacle(4f, 2.5f, 0f);
            SpawnObstacle(4.5f, 2f, 0f);
            SpawnObstacle(4f, 2f, 0f);
            SpawnObstacle(3.5f, 2f, 0f);
            SpawnObstacle(3f, 2f, 0f);
            SpawnObstacle(3.5f, 1.5f, 0f);
            SpawnObstacle(3f, 1.5f, 0f);
            SpawnObstacle(2.5f, 1.5f, 0f);
            SpawnObstacle(2f, 1.5f, 0f);
        }

        if (_gameManager.Level == 4)
        {
            SpawnObstacle(3f, 2f, 0f);
            SpawnObstacle(3f, 1.5f, 0f);
            SpawnObstacle(2.5f, 1.5f, 0f);
            SpawnObstacle(4f, 1f, 0f);
            SpawnObstacle(3.5f, 1f, 0f);
            SpawnObstacle(3f, 1f, 0f);
            SpawnObstacle(2.5f, 1f, 0f);
            SpawnObstacle(2f, 1f, 0f);
            SpawnObstacle(1.5f, 1f, 0f);
            SpawnObstacle(5f, 0f, 0f);
            SpawnObstacle(4.5f, 0f, 0f);
            SpawnObstacle(4f, 0f, 0f);
            SpawnObstacle(3.5f, 0f, 0f);
            SpawnObstacle(3f, 0f, 0f);
            SpawnObstacle(2.5f, 0f, 0f);
        }
    }

    private void SpawnRightDownCorner()
    {
        if (_gameManager.Level == 2)
        {
            SpawnObstacle(5f, -2.5f, 0f);
            SpawnObstacle(5f, -2f, 0f);
            SpawnObstacle(5f, -1.5f, 0f);
            SpawnObstacle(5f, -1f, 0f);
            SpawnObstacle(5.5f, -2.5f, 0f);
            SpawnObstacle(5.5f, -2f, 0f);
            SpawnObstacle(5.5f, -1.5f, 0f);
            SpawnObstacle(5.5f, -1f, 0f);
            SpawnObstacle(6f, -1.5f, 0f);
            SpawnObstacle(6f, -1f, 0f);
            SpawnObstacle(6.5f, -1.5f, 0f);
            SpawnObstacle(6.5f, -1f, 0f);
        }

        if (_gameManager.Level == 3)
        {
            SpawnObstacle(5.5f, -2.5f, 0f);
            SpawnObstacle(5f, -2.5f, 0f);
            SpawnObstacle(4.5f, -2.5f, 0f);
            SpawnObstacle(4f, -2.5f, 0f);
            SpawnObstacle(4.5f, -2f, 0f);
            SpawnObstacle(4f, -2f, 0f);
            SpawnObstacle(3.5f, -2f, 0f);
            SpawnObstacle(3f, -2f, 0f);
            SpawnObstacle(3.5f, -1.5f, 0f);
            SpawnObstacle(3f, -1.5f, 0f);
            SpawnObstacle(2.5f, -1.5f, 0f);
            SpawnObstacle(2f, -1.5f, 0f);
        }

        if (_gameManager.Level == 4)
        {
            SpawnObstacle(4f, -1f, 0f);
            SpawnObstacle(3.5f, -1f, 0f);
            SpawnObstacle(3f, -1f, 0f);
            SpawnObstacle(3f, -1.5f, 0f);
            SpawnObstacle(2.5f, -1f, 0f);
            SpawnObstacle(2f, -1f, 0f);
            SpawnObstacle(3f, -2f, 0f);
        }

    }


}
