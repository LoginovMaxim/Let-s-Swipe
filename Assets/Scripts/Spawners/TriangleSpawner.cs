using UnityEngine;

public class TriangleSpawner : Spawner
{
    [SerializeField] private int _enemySpawnPeriod;

    private int _elapsedEnemySpawnPeriod;


    private void OnEnable() => Player.HitPortal += TryCreateEnemy;

    private void OnDisable() => Player.HitPortal -= TryCreateEnemy;

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
        float enemyPositionX = Player.transform.position.x - Random.Range(SpawnRange, 2f * SpawnRange);
        float enemyPositionY = Random.Range(-SpawnRange, SpawnRange);

        Instantiate(SpawnPrefab, new Vector2(enemyPositionX, enemyPositionY), Quaternion.identity);
    }

}
