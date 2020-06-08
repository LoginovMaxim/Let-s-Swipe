using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Loader _loader;
    [SerializeField] private int _levelNumber;
    [SerializeField] private int _winCountPoints;
    
    private bool _isPassed;

    public int WinCountPoints => _winCountPoints;

    private void OnEnable()
    {
        _player.Won += OnWonLevel;
        _player.Dead += OnLoseLevel;
    }

    private void Start()
    {
        _isPassed = _levelNumber <= Settings.АvailableLevel;
    }

    private void OnWonLevel()
    {
        if (_isPassed == false)
        {
            Settings.АvailableLevel++;
            PlayerPrefs.SetInt("АvailableLevel", Settings.АvailableLevel);
        }

        _loader.LoadScene(0, true);
    }

    private void OnLoseLevel()
    {
        _loader.LoadScene(0, false);
    }

    private void OnDisable()
    {
        _player.Won -= OnWonLevel;
        _player.Dead -= OnLoseLevel;
    }
}
