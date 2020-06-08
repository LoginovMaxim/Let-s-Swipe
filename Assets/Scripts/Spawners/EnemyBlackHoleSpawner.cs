using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlackHoleSpawner : Spawner
{
    [SerializeField] private int _spawnChance;

    private void OnEnable() => Player.HitPortal += TryCreateBlackHole;

    private void OnDisable() => Player.HitPortal -= TryCreateBlackHole;

    private void TryCreateBlackHole()
    {
        int rand = Random.Range(0, _spawnChance);
        Debug.Log(rand);

        if (rand == 0)
        {
            float enemyPositionX = Player.transform.position.x + Random.Range(SpawnRange * 0.75f, SpawnRange * 1.25f);
            float enemyPositionY = Random.Range(-SpawnRange, SpawnRange);

            Instantiate(SpawnPrefab, new Vector2(enemyPositionX, enemyPositionY), Quaternion.identity);
        }
    }
}
