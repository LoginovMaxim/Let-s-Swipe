using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] private WorldPalette _worldPalette;
    [SerializeField] private Level _level;
    [SerializeField] private GameObject _dieParticle;

    private SpriteRenderer _spriteRenderer;
    private int _coefficientOfPoints;
    private bool _isOpacity;

    public PlayerController PlayerController { get; private set; }
    public int СountPoints { get; private set; }

    public event UnityAction ChangedColor;
    public event UnityAction HitPortal;
    public event UnityAction Won;
    public event UnityAction Dead;

    public bool CanPlayerColorChange;

    private void Start()
    {
        CanPlayerColorChange = true;

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
            PlayerController.SetPlayingState(false);

            Won?.Invoke();
        }
    }

    public void SetCoefficientPoints(int value) => _coefficientOfPoints = value; 

    private void ChangeColor()
    {
        ChangedColor?.Invoke();

        if(CanPlayerColorChange)
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

            AudioManager.Instance.SetPitch("PortalExplosion", Random.Range(0.9f, 1.1f));
            AudioManager.Instance.Play("PortalExplosion");
        }

        if (collision.gameObject.TryGetComponent(out Buff buff))
        {
            buff.ApplyBuff();
            AudioManager.Instance.SetPitch("BuffSound", Random.Range(0.9f, 1.1f));
            AudioManager.Instance.Play("BuffSound");
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
            PlayerController.FreezeTime();
            menuPortal.Explosion();

            AudioManager.Instance.SetPitch("PortalExplosion", Random.Range(0.9f, 1.1f));
            AudioManager.Instance.Play("PortalExplosion");
        }
    }

    public void Die()
    {
        Dead?.Invoke();
    }

    public void SetOpacity(bool value) => _isOpacity = value;
}
