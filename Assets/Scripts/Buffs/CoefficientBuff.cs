
public class CoefficientBuff : Buff
{
    public override void ActivateBuff()
    {
        transform.parent.GetComponent<BuffActivator>().ApplyCoefficientBuff();

    }
}
