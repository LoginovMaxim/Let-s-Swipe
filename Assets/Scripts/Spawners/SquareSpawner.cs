using System.Collections.Generic;
using UnityEngine;

public class SquareSpawner : Spawner
{
    [SerializeField] private int _countSquares;
    [SerializeField] private Transform _container;

    public List<GameObject> SquareEnemies { get; private set; }


    private void OnEnable() => Player.HitPortal += OnCreateSquares;

    private void OnDisable() => Player.HitPortal -= OnCreateSquares;

    private void Start()
    {
        SquareEnemies = new List<GameObject>();

        for (int i = 0; i < _countSquares; i++)
        {
            GameObject enemy = Instantiate(SpawnPrefab, _container);

            SquareEnemies.Add(enemy);
            SquareEnemies[i].SetActive(false);
        }
    }

    private void OnCreateSquares()
    {
        foreach (var squareEnemy in SquareEnemies)
        {
            if (squareEnemy.activeSelf == false)
            {
                float enemyPositionX = Player.transform.position.x + Random.Range(SpawnRange, 10f * SpawnRange);
                float enemyPositionY = Random.Range(-SpawnRange, SpawnRange);

                squareEnemy.transform.position = new Vector3(enemyPositionX, enemyPositionY, 0f);
                squareEnemy.SetActive(true);
            }
        }
    }
}
