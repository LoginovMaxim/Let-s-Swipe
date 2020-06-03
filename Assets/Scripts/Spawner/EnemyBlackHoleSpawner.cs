using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlackHoleSpawner : Spawner
{
    [SerializeField] private int _spawnChance;

    private void OnEnable()
    {
        if (IsActive)
            Player.HitPortal += TryCreateBlackHole;
    }

    private void TryCreateBlackHole()
    {
        int rand = Random.Range(0, _spawnChance);
        Debug.Log(rand);

        if (rand == 0)
        {
            float enemyPositionX = Player.transform.position.x + Random.Range(EnemyRange * 0.75f, EnemyRange * 1.25f);
            float enemyPositionY = Random.Range(-EnemyRange, EnemyRange);

            Instantiate(EnemyPrefab, new Vector2(enemyPositionX, enemyPositionY), Quaternion.identity);
        }
    }

    private void OnDisable()
    {
        Player.HitPortal -= TryCreateBlackHole;
    }
}
