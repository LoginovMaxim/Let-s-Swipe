using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TriangleEnemy : Enemy
{
    [SerializeField] private float _force;
    [SerializeField] private float _smoothRotation;

    private Rigidbody2D _rigidbody2D;
    private Vector3 _offsetPositionToTarget;

    private void Start()
    {
        base.Start();

        transform.localScale = Vector3.one * Random.Range(0.8f, 1.6f);

        _offsetPositionToTarget = Vector3.one * Random.Range(-0.8f, 0.8f);

        _force *= Random.Range(0.8f, 1.6f);
        _smoothRotation *= Random.Range(0.8f, 1.6f);

        _rigidbody2D = GetComponent<Rigidbody2D>();

        GetComponent<SpriteRenderer>().color = WorldPalette.EnemyColor;
    }

    private void FixedUpdate()
    {
        LookAtPlayer();

        _rigidbody2D.velocity = _rigidbody2D.velocity * .1f;
        _rigidbody2D.AddForce(((Player.transform.position + _offsetPositionToTarget) - transform.position) * _force);
    }

    private void LookAtPlayer()
    {
        Vector3 direction = Player.transform.position - transform.position;
        direction.Normalize();

        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        if (transform.rotation != targetRotation)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _smoothRotation * Time.fixedDeltaTime);
        }
    }
}
