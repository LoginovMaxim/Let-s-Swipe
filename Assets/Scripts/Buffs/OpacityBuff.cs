using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityBuff : Buff
{
    public override void ApplyBuff()
    {
        transform.parent.GetComponent<BuffController>().ApplyOpacityBuff();

        Instantiate(Particle, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
