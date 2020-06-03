using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpawner : Spawner
{
    [SerializeField] private int _countSquares;
    [SerializeField] private Transform _container;

    public List<GameObject> SquareEnemies { get; private set; }

    private void OnEnable()
    {
        if (IsActive)
            Player.HitPortal += CreateSquares;
    }

    private void Start()
    {
        Debug.Log("SquareSpawner Start");

        SquareEnemies = new List<GameObject>();

        for (int i = 0; i < _countSquares; i++)
        {
            GameObject enemy = Instantiate(EnemyPrefab, _container);

            SquareEnemies.Add(enemy);
            SquareEnemies[i].SetActive(false);
        }
    }

    private void CreateSquares()
    {
        foreach (var squareEnemy in SquareEnemies)
        {
            if (squareEnemy.activeSelf == false)
            {
                float enemyPositionX = Player.transform.position.x + Random.Range(EnemyRange, 10f * EnemyRange);
                float enemyPositionY = Random.Range(-EnemyRange, EnemyRange);

                squareEnemy.transform.position = new Vector3(enemyPositionX, enemyPositionY, 0f);
                squareEnemy.SetActive(true);
            }
        }
    }

    private void OnDisable()
    {
        Player.HitPortal -= CreateSquares;
    }

    public bool GetActive() => IsActive;
}
