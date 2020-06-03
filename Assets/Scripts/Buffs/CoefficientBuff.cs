using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoefficientBuff : Buff
{
    public override void ApplyBuff()
    {
        transform.parent.GetComponent<BuffController>().ApplyCoefficientBuff();

        Instantiate(Particle, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
