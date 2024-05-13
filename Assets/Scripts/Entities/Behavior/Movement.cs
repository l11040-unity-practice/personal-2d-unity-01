using UnityEngine;

public class Movement : MonoBehaviour
{
    private EntityController _controller;
    private Rigidbody2D _rigid;
    private Vector2 _direction = Vector2.zero;
    // TODO : 추후 스텟으로 변경해야함
    private float _speed = 5;
    private void Awake()
    {
        _controller = GetComponent<EntityController>();
        _rigid = GetComponent<Rigidbody2D>();
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        _rigid.velocity = _direction * _speed;
    }

    private void Move(Vector2 direction)
    {
        _direction = direction.normalized;
    }
}
