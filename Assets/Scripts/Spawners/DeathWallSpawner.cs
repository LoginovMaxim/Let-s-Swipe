using System.Collections;
using UnityEngine;

public class DeathWallSpawner : Spawner
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private float _spawnDelay;

    private void Start()
    {
        StartCoroutine(Spawn(_spawnDelay));
    }

    private IEnumerator Spawn(float spawnDelay)
    {
        while (true)
        {
            Instantiate(SpawnPrefab, _startPosition.position, Quaternion.identity);

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
