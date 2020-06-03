using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPortal : MenuPortal
{
    [SerializeField] private int _sceneIndex;

    private Loader _loader;

    private void OnEnable()
    {
        if (_sceneIndex > Settings.АvailableLevel + 1)
            gameObject.SetActive(false);
    }

    private void Start()
    {
        _loader = transform.parent.gameObject.GetComponent<Loader>();
    }

    public override void Explosion()
    {
        ActivateOtherPortals();
        DeactivateOtherPortals();

        Instantiate(ExplosionParticle, transform.position, Quaternion.identity);

        _loader.LoadScene(_sceneIndex, false);
        gameObject.SetActive(false);
    }
}
