using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;

    private Animator _animator;

    private bool _isLeftMove;
    private bool _isRightMove;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _isLeftMove = false;
        _isRightMove = true;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetTrigger(AnimatorPlayerController.Parametrs.Run);

            if (_isLeftMove == true)
            {
                _spriteRenderer.flipX = !_spriteRenderer.flipX;
                _isLeftMove = false;
                _isRightMove = true;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _animator.SetTrigger(AnimatorPlayerController.Parametrs.Run);

            if (_isRightMove == true)
            {
                _spriteRenderer.flipX = !_spriteRenderer.flipX;
                _isRightMove = false;
                _isLeftMove = true;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, _speed * Time.deltaTime * 1, 0);
            _animator.SetTrigger(AnimatorPlayerController.Parametrs.Jump);
        }

        if (Input.GetKeyUp(KeyCode.W))
            _animator.ResetTrigger(AnimatorPlayerController.Parametrs.Jump);

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _animator.ResetTrigger(AnimatorPlayerController.Parametrs.Run);
            _animator.SetTrigger(AnimatorPlayerController.Parametrs.Idle);
        }
    }
}

public static class AnimatorPlayerController
{
    public static class Parametrs
    {
        public const string Idle = nameof(Idle);
        public const string Run = nameof(Run);
        public const string Jump = nameof(Jump);
    }
}
