using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject _explosionParticle;

    private void Start()
    {
        Collider2D[] otherColliders;

        do
        {
            otherColliders = Physics2D.OverlapCircleAll(transform.position, 1f);

            if (otherColliders.Length > 0)
                transform.position += Vector3.right;
        }
        while (otherColliders.Length > 0);
    }

    public void Explosion()
    {
        Instantiate(_explosionParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
