using UnityEngine;

public class BuffSpawner : Spawner
{
    [SerializeField] 
    private GameObject[] _buffs;

    [SerializeField] [Range(2, 9)]
    private int _spawnChance;

    private void OnEnable() => Player.HitPortal += OnCreateBuff;

    private void OnDisable() => Player.HitPortal -= OnCreateBuff;

    private void OnCreateBuff()
    {
        if (Random.Range(0, _spawnChance) == 0)
        {
            float enemyPositionX = Player.transform.position.x + Random.Range(SpawnRange * 0.5f, SpawnRange * 1f);
            float enemyPositionY = Random.Range(-SpawnRange, SpawnRange);

            Instantiate(_buffs[Random.Range(0, _buffs.Length)], new Vector2(enemyPositionX, enemyPositionY), Quaternion.identity, transform);
        }
    }
}
