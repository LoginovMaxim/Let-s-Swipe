using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Player Player;
    protected WorldPalette WorldPalette;

    protected void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
        WorldPalette = GameObject.Find("WorldPalette").GetComponent<WorldPalette>();
    }
}
