using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(LineRenderer))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _force = 100;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody;
    private LineRenderer _line;
    private bool _isPlaying = true;

    public float NormalForce { get; private set; }


    private void OnEnable() => _player.Won += OnWon;

    private void OnDisable() => _player.Won -= OnWon;

    private void Start()
    {
        NormalForce = _force;

        _rigidbody = GetComponent<Rigidbody2D>();
        _line = GetComponent<LineRenderer>();

        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (_isPlaying)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FreezeTime();

                _line.enabled = true;
                _startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(0))
            {
                ShowTrails(transform.position, GetForce() * 0.01f);
            }

            if (Input.GetMouseButtonUp(0))
            {
                _line.enabled = false;
                Time.timeScale = 1f;

                _rigidbody.gravityScale = 1;
                _rigidbody.AddForce(GetForce());
            }
        }
    }

    public void ChangeForceByBuff(bool isModify)
    {
        if (isModify)
            _force = NormalForce * 1.5f;
        else
            _force = NormalForce;

    }

    public void FreezeTime()
    {
        Time.timeScale = 0.1f;
        _rigidbody.gravityScale = 0;
        _rigidbody.velocity = _rigidbody.velocity.normalized * 0.1f;
    }

    private Vector3 GetForce()
    {
        Vector3 direction = _startPosition - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction.z = 0;

        return direction * _force;
    }

    private void OnWon() => _isPlaying = false;

    private void ShowTrails(Vector3 origin, Vector3 speed)
    {
        Vector3[] points = new Vector3[50];
        _line.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.05f;

            points[i] = origin + speed * time + Physics.gravity * time * time / 2f;
            points[i].z = 0f;
        }

        _line.SetPositions(points);
    }
}
