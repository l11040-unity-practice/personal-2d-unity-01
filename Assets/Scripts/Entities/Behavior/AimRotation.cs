using System;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    private EntityController _controller;
    private SpriteRenderer _characterRenderer;
    [SerializeField] private Transform _arm;

    private void Awake()
    {
        _characterRenderer = GetComponentInChildren<SpriteRenderer>();
        _controller = GetComponent<EntityController>();
        _controller.OnLookEvent += Rotate;
    }

    private void Rotate(Vector2 direction)
    {
        float degree = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _characterRenderer.flipX = Mathf.Abs(degree) > 90f;
        _arm.rotation = Quaternion.Euler(0, 0, degree);
    }
}
