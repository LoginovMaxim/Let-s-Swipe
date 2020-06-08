using System.Collections;
using UnityEngine;

public class BuffActivator : MonoBehaviour
{
    private float _durationBuff = 8f;
    private Player _player;
    private PlayerController _playerController;

    private Coroutine _speedCoroutine;
    private Coroutine _opacityCoroutine;
    private Coroutine _coefficientCoroutine;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _playerController = FindObjectOfType<PlayerController>();
    }

    public void ApplySpeedBuff()
    {
        PreventCoroutine(_speedCoroutine);
        _speedCoroutine = StartCoroutine(WaitSpeedBuff());
    }

    public void ApplyOpacityBuff()
    {
        PreventCoroutine(_opacityCoroutine);
        _opacityCoroutine = StartCoroutine(WaitOpacityBuff());
    }

    public void ApplyCoefficientBuff()
    {
        PreventCoroutine(_coefficientCoroutine);
        _coefficientCoroutine = StartCoroutine(WaitCoefficientBuff());
    }

    public void PreventCoroutine(Coroutine probablyCoroutine)
    {
        if (probablyCoroutine != null)
            StopCoroutine(probablyCoroutine);
    }


    public IEnumerator WaitSpeedBuff()
    {
        _playerController.ChangeForceByBuff(true);

        yield return new WaitForSeconds(_durationBuff);

        _playerController.ChangeForceByBuff(false);
    }

    public IEnumerator WaitOpacityBuff()
    {
        _player.ChangeOpacityByBuff(true);

        yield return new WaitForSeconds(_durationBuff);

        _player.ChangeOpacityByBuff(false);

    }

    public IEnumerator WaitCoefficientBuff()
    {
        _player.ChangeCoefficientByBuff(true);

        yield return new WaitForSeconds(_durationBuff);

        _player.ChangeCoefficientByBuff(false);
    }
}
