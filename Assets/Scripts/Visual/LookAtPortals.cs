using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPortals : MonoBehaviour
{
    [SerializeField] private CinemachineTargetGroup _targetGroup;
    [SerializeField] private List<GameObject> _targetObjects;


    private void Start() => AddToGroup();

    public void AddToGroup()
    {
        for (int i = 0; i < _targetObjects.Count; i++)
        {
            _targetGroup.AddMember(_targetObjects[i].transform, 1, 3);
        }
    }

    public void SetTargetObjects(List<GameObject> targets) => _targetObjects = targets;

    public void ClearTargetObjects()
    {
        for (int i = 0; i < _targetObjects.Count; i++)
        {
            _targetGroup.RemoveMember(_targetObjects[i].transform);
        }
    }
}
