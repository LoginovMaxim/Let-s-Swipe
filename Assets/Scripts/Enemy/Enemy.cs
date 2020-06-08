using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    protected Player Player;
    protected WorldPalette WorldPalette;

    protected void Start()
    {
        Player = FindObjectOfType<Player>();
        WorldPalette = FindObjectOfType<WorldPalette>();
    }
}
