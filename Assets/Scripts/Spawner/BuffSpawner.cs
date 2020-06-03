using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawner : Spawner
{
    [SerializeField] private GameObject[] _buffs;

    private void OnEnable()
    {
        if (IsActive)
            Player.HitPortal += CreateBuff;
    }

    private void CreateBuff()
    {
        if (Random.Range(0, 10) == 0)
        {
            float enemyPositionX = Player.transform.position.x + Random.Range(EnemyRange * 0.5f, EnemyRange * 1f);
            float enemyPositionY = Random.Range(-EnemyRange, EnemyRange);

            Instantiate(_buffs[Random.Range(0, _buffs.Length)], new Vector2(enemyPositionX, enemyPositionY), Quaternion.identity, transform);
        }
    }

    private void OnDisable()
    {
        Player.HitPortal -= CreateBuff;
    }
}
