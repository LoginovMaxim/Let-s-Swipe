using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPortal : MenuPortal
{
    public override void Explosion()
    {
        ActivateOtherPortals();
        DeactivateOtherPortals();

        Instantiate(ExplosionParticle, transform.position, Quaternion.identity);

        QuitGame();
        gameObject.SetActive(false);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
