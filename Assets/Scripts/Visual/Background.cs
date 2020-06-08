using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private WorldPalette _worldPalette;
    [SerializeField] private SpriteRenderer _upBackground;
    [SerializeField] private SpriteRenderer _downBackground;
    [SerializeField] private float _smoothMove;


    private void OnEnable() => _player.ChangedColor += OnChangeColor;

    private void OnDisable() => _player.ChangedColor -= OnChangeColor;

    private void Start() => OnChangeColor();

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _player.transform.position, _smoothMove * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, 0f, 0f);
    }

    private void OnChangeColor()
    {
        _upBackground.color = _worldPalette.BackgroundUpColor;
        _downBackground.color = _worldPalette.BackgroundDownColor;
    }

}
