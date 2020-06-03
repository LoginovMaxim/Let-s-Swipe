using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private bool _isUpOffset;

    private void Start()
    {
        if (Random.Range(0, 2) == 0)
            _isUpOffset = true;
        else
            _isUpOffset = false;

        Collider2D[] otherColliders;


        do
        {
            otherColliders = Physics2D.OverlapCircleAll(transform.position, 1f, _layerMask);

            foreach (var other in otherColliders)
            {
                Debug.Log(other.name);
            }

            if (otherColliders.Length > 0)
            {
                if (_isUpOffset)
                    transform.position += Vector3.up;
                else
                    transform.position += Vector3.down;
            }
        }
        while (otherColliders.Length > 0);
    }
}
