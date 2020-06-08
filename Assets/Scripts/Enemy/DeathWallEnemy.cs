using UnityEngine;

public class DeathWallEnemy : Enemy
{
    [SerializeField] private float _movementSpeed;

    private void Update()
    {
        transform.Translate(Vector2.right * _movementSpeed * Time.deltaTime);
    }
}
