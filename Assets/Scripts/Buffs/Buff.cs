using UnityEngine;

public abstract class Buff : MonoBehaviour
{
    [SerializeField] protected GameObject Particle;

    public void ApplyBuff()
    {
        ActivateBuff();

        Instantiate(Particle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public abstract void ActivateBuff();
}
