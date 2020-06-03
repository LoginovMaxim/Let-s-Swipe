using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.HasKey("АvailableLevel"))
        {
            Settings.АvailableLevel = PlayerPrefs.GetInt("АvailableLevel");
        }
        else
        {
            Settings.АvailableLevel = 0;
            PlayerPrefs.SetInt("АvailableLevel", Settings.АvailableLevel);
        }

        Debug.Log(Settings.АvailableLevel);
    }
}
