using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class EnemieMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;

    private bool _isRightMove;

    private int _changeDirectionIndex = -1;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_isRightMove)
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        else
            transform.Translate(_speed * Time.deltaTime * _changeDirectionIndex, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<FlipPoint>(out FlipPoint _flipPoint))
        {
            _isRightMove = !_isRightMove;
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }
    }
}
