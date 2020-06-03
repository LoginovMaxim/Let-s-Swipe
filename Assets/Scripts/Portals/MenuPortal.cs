using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPortal : MonoBehaviour
{
    [SerializeField] private List<GameObject> _activatePortals;
    [SerializeField] private List<GameObject> _deactivatePortals;
    [SerializeField] private LookAtPortals _lookAtPortal;
    
    [SerializeField] protected GameObject ExplosionParticle;

    public virtual void Explosion()
    {
        ActivateOtherPortals();
        DeactivateOtherPortals();

        Instantiate(ExplosionParticle, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    protected void ActivateOtherPortals()
    {
        foreach (var activatePortal in _activatePortals)
        {
            activatePortal.SetActive(true);
        }

        if (_lookAtPortal == null)
            return;

        _lookAtPortal.ClearTargetObjects();
        _lookAtPortal.SetTargetObjects(_activatePortals);
        _lookAtPortal.AddToGroup();
    }

    protected void DeactivateOtherPortals()
    {
        foreach (var deactivatePortal in _deactivatePortals)
        {
            deactivatePortal.SetActive(false);
        }
    }
}
