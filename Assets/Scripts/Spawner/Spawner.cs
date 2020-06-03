using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject EnemyPrefab;
    [SerializeField] protected float EnemyRange;

    [SerializeField] protected Player Player;
    [SerializeField] protected bool IsActive;
}
