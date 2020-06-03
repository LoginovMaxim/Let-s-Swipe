using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffController : MonoBehaviour
{
    private float _durationBuff = 8f;
    private Player _player;
    private PlayerController _playerController;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void ApplyOpacityBuff()
    {
        StartCoroutine(WaitOpacityBuff());
    }

    public void ApplySpeedBuff()
    {
        StartCoroutine(WaitSpeedBuff());
    }

    public void ApplyCoefficientBuff()
    {
        StartCoroutine(WaitCoefficientBuff());
    }

    public IEnumerator WaitCoefficientBuff()
    {
        _player.SetCoefficientPoints(150);

        yield return new WaitForSeconds(_durationBuff);

        _player.SetCoefficientPoints(0);
    }

    public IEnumerator WaitOpacityBuff()
    {
        _player.SetOpacity(true);

        _player.CanPlayerColorChange = false;
        Color playerColor = _player.GetComponent<SpriteRenderer>().color;
        _player.GetComponent<SpriteRenderer>().color = new Color(playerColor.r, playerColor.g, playerColor.b, 0.25f);

        yield return new WaitForSeconds(_durationBuff);

        _player.GetComponent<SpriteRenderer>().color = new Color(playerColor.r, playerColor.g, playerColor.b, 1f);
        _player.CanPlayerColorChange = true;

        _player.SetOpacity(false);
    }

    public IEnumerator WaitSpeedBuff()
    {
        _playerController.SetForce(_playerController.NormalForce * 2f);

        yield return new WaitForSeconds(_durationBuff);

        _playerController.SetForce(_playerController.NormalForce);
    }
}
