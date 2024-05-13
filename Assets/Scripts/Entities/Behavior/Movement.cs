using UnityEngine;

public class Movement : MonoBehaviour
{
    private EntityController _controller;
    private CharacterStatsController _characterStatsController;
    private Rigidbody2D _rigid;
    private Vector2 _direction = Vector2.zero;

    private void Awake()
    {
        _controller = GetComponent<EntityController>();
        _characterStatsController = GetComponent<CharacterStatsController>();
        _rigid = GetComponent<Rigidbody2D>();
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        _rigid.velocity = _direction * _characterStatsController.CurrentStat.Speed;
    }

    private void Move(Vector2 direction)
    {
        _direction = direction.normalized;
    }
}
