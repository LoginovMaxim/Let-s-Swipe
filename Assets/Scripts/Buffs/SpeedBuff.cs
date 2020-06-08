
public class SpeedBuff : Buff
{
    public override void ActivateBuff()
    {
        transform.parent.GetComponent<BuffActivator>().ApplySpeedBuff();
    }
}
