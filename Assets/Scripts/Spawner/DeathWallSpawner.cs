using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWallSpawner : Spawner
{
    [SerializeField] private Transform _startPosition;

    private void Start()
    {
        if (IsActive)
            Instantiate(EnemyPrefab, _startPosition.position, Quaternion.identity);
    }
}
