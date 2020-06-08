
public class OpacityBuff : Buff
{
    public override void ActivateBuff()
    {
        transform.parent.GetComponent<BuffActivator>().ApplyOpacityBuff();
    }
}
