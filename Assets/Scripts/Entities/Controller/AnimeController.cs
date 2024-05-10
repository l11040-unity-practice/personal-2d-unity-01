using UnityEngine;

public class AnimeController : MonoBehaviour
{
    private EntityController _controller;
    private Animator _animator;

    private void Awake()
    {
        _controller = GetComponent<EntityController>();
        _animator = GetComponent<Animator>();
        _controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        _animator.SetBool("isWalk", direction.magnitude > 0);
    }
}
