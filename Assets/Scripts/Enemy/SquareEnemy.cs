using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareEnemy : Enemy
{
    [SerializeField] private float _deactivatedDistance;
    [SerializeField] private float _smoothRotation;

    private void Start()
    {
        base.Start();

        Player.HitPortal += OnCheckOldSuqare;

        transform.localScale = Vector2.one * Random.Range(1f, 2f);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, Random.Range(0f, 360f)));
        _smoothRotation *= Random.Range(0.8f, 1.6f);

        GetComponent<SpriteRenderer>().color = WorldPalette.EnemyColor;
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * _smoothRotation * Time.deltaTime);
    }

    private void OnCheckOldSuqare()
    {
        if (Player.transform.position.x - transform.position.x > _deactivatedDistance)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        if (Player != null)
            Player.HitPortal -= OnCheckOldSuqare;
    }
}
