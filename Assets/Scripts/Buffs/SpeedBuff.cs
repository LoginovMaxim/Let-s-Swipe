using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : Buff
{
    public override void ApplyBuff()
    {
        transform.parent.GetComponent<BuffController>().ApplySpeedBuff();

        Instantiate(Particle, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
