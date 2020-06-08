using UnityEngine;

public class AudioAccompaniment : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private Player _player;


    private void OnEnable()
    {
        _player.HitPortal += OnHitPortal;
        _player.TakeBuff += OnTakeBuff;
    }

    private void OnDisable()
    {
        _player.HitPortal -= OnHitPortal;
        _player.TakeBuff -= OnTakeBuff;
    }

    private void Start()
    {
        _audioManager.Play($"Theme_{Random.Range(1, 4)}");
    }

    private void OnHitPortal()
    {
        _audioManager.SetPitch("PortalExplosion", Random.Range(0.9f, 1.1f));
        _audioManager.Play("PortalExplosion");
    }

    private void OnTakeBuff()
    {
        _audioManager.SetPitch("BuffSound", Random.Range(0.9f, 1.1f));
        _audioManager.Play("BuffSound");
    }
}
