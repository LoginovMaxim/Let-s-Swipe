using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    [SerializeField] private Image _panel;

    public void LoadScene(int index, bool isWon)
    {
        StartCoroutine(FadingScreen(index, isWon));
    }

    private IEnumerator FadingScreen(int index, bool isWon)
    {
        Color opaque = default;

        if (isWon)
        {
            opaque = new Color(1f, 1f, 1f, 1f);
            _panel.color = new Color(1f, 1f, 1f, 0f);
        }
        else
        {
            opaque = new Color(0f, 0f, 0f, 1f);
            _panel.color = new Color(0f, 0f, 0f, 0f);
        }

        for (int i = 1; i < 101; i++)
        {
            _panel.color = Color.Lerp(_panel.color, opaque, i / 100f);
            yield return new WaitForSeconds(0.005f);
        }

        SceneManager.LoadScene(index);
    }
}
