using System;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    private EntityController _controller;
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _controller = GetComponent<EntityController>();
        _controller.OnLookEvent += Rotate;
    }

    private void Rotate(Vector2 direction)
    {
        float degree = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _spriteRenderer.flipX = Mathf.Abs(degree) > 90f;
    }
}
