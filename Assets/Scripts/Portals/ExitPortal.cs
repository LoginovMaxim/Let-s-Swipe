using UnityEngine;

public class ExitPortal : MenuPortal
{
    public override void Explosion()
    {
        ActivateOtherPortals();
        DeactivateOtherPortals();

        Instantiate(ExplosionParticle, transform.position, Quaternion.identity);

        QuitGame();
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
