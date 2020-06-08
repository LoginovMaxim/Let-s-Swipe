using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    [SerializeField] private WorldPalette _worldPalette;
    [SerializeField] private Level _level;
    [SerializeField] private GameObject _dieParticle;

    private SpriteRenderer _spriteRenderer;
    private int _coefficientOfPoints;
    private bool _isOpacity;
    private bool _canPlayerColorChange = true;

    public PlayerController PlayerController { get; private set; }
    public int СountPoints { get; private set; }

    public event UnityAction ChangedColor;
    public event UnityAction HitPortal;
    public event UnityAction TakeBuff;
    public event UnityAction Won;
    public event UnityAction Dead;


    private void Start()
    {
        PlayerController = GetComponent<PlayerController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = _worldPalette.PlayerColor;
    }

    public void AddPoints()
    {
        СountPoints += 200 + _coefficientOfPoints;
        ChangeColor();

        if (СountPoints >= _level.WinCountPoints)
        {
            _isOpacity = true;
            Won?.Invoke();
        }
    }

    private void ChangeColor()
    {
        ChangedColor?.Invoke();

        if(_canPlayerColorChange)
            _spriteRenderer.color = _worldPalette.PlayerColor;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Portal portal))
        {
            AddPoints();

            HitPortal?.Invoke();
            PlayerController.FreezeTime();

            portal.Explosion();

        }

        if (collision.gameObject.TryGetComponent(out Buff buff))
        {
            buff.ApplyBuff();
            TakeBuff?.Invoke();
        }

        if (_isOpacity == false)
        {
            if (collision.gameObject.TryGetComponent(out Enemy enemy))
            {
                Die();

                var particle = Instantiate(_dieParticle, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
                particle.startColor = _worldPalette.PlayerColor;
                particle.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = _worldPalette.PlayerColor;

                gameObject.SetActive(false);
            }
        }

        if (collision.gameObject.TryGetComponent(out MenuPortal menuPortal))
        {
            HitPortal?.Invoke();
            PlayerController.FreezeTime();
            menuPortal.Explosion();
        }
    }


    public void ChangeCoefficientByBuff(bool isModufy)
    {
        if (isModufy)
            _coefficientOfPoints = 150;
        else
            _coefficientOfPoints = 0;

    }

    public void ChangeOpacityByBuff(bool isModufy)
    {

        if (isModufy)
            SetOpacityParameters(true, false, 0.25f);
        else
            SetOpacityParameters(false, true, 1f);
    }

    private void SetOpacityParameters(bool isOpacity, bool canChangeColor, float alpha)
    {
        Color playerColor = _worldPalette.PlayerColor;

        _isOpacity = isOpacity;

        _canPlayerColorChange = canChangeColor;
        _spriteRenderer.color = new Color(playerColor.r, playerColor.g, playerColor.b, alpha);
    }

    public void Die()
    {
        Dead?.Invoke();
    }

}
