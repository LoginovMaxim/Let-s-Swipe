using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointCounter : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Level _level;
    [SerializeField] private TMP_Text _textCountPoints;
    [SerializeField] private Animator _textAnimation;

    private void Start()
    {
        _player.HitPortal += OnChangePoints;
        OnChangePoints();
    }

    private void OnChangePoints()
    {
        _textCountPoints.text = _player.СountPoints + "<size=64>/" + _level.WinCountPoints + "</size>";
        _textAnimation.SetTrigger("AddPoints");
    }

    private void OnDisable()
    {
        _player.HitPortal -= OnChangePoints;
    }
}
