using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleSpawner : Spawner
{
    [SerializeField] private int _enemySpawnPeriod;

    private int _elapsedEnemySpawnPeriod;

    private void OnEnable()
    {
        if (IsActive)
            Player.HitPortal += TryCreateEnemy;
    }

    private void TryCreateEnemy()
    {
        _elapsedEnemySpawnPeriod--;
        if (_elapsedEnemySpawnPeriod < 0)
        {
            CreateEnemy();
            _elapsedEnemySpawnPeriod = _enemySpawnPeriod;
            _enemySpawnPeriod += 2;
        }
    }

    private void CreateEnemy()
    {
        float enemyPositionX = Player.transform.position.x - Random.Range(EnemyRange, 2f * EnemyRange);
        float enemyPositionY = Random.Range(-EnemyRange, EnemyRange);

        Instantiate(EnemyPrefab, new Vector2(enemyPositionX, enemyPositionY), Quaternion.identity);
    }

    private void OnDisable()
    {
        Player.HitPortal -= TryCreateEnemy;
    } 
}
