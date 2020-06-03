﻿using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{
    [SerializeField] private CinemachineTargetGroup _cinemachineTarget;

    [SerializeField] protected Player Player;
    [SerializeField] private Portal _portalPrefab;
    [SerializeField] private SquareSpawner _squareSpawner;
    [SerializeField] private float _portalRange;

    public Portal CurrentPortal { get; private set;}

    private void OnEnable()
    {
        Player.HitPortal += CreatePortal;
    }

    private void Start()
    {
        CreatePortal();
    }

    private void Update()
    {
        if (Vector2.Distance(CurrentPortal.transform.position, Player.transform.position) > 30)
        {
            Player.Die();
        }
    }

    public void CreatePortal()
    {
        float portalPositionX = Player.transform.position.x + Random.Range(_portalRange * 0.75f, _portalRange * 1.25f);
        float portalPositionY = Random.Range(-_portalRange, _portalRange);

        Vector2 portalPosition = new Vector2(portalPositionX, portalPositionY);

        CurrentPortal = Instantiate(_portalPrefab, portalPosition, Quaternion.identity);

        _cinemachineTarget.m_Targets[1].target = CurrentPortal.transform;
    }

    private void OnDisable()
    {
        Player.HitPortal -= CreatePortal;
    }
}