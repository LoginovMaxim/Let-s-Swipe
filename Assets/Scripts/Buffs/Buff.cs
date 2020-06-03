using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : MonoBehaviour
{
    [SerializeField] protected GameObject Particle;

    public abstract void ApplyBuff();
}
