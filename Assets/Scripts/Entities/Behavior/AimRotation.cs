using System;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    private EntityController _controller;
    private SpriteRenderer _characterRenderer;
    [SerializeField] private Transform _arm;

    private void Awake()
    {
        // _characterRenderer = GetComponentsInChildren<SpriteRenderer>();
        _controller = GetComponent<EntityController>();
        _controller.OnLookEvent += Rotate;
    }

    private void Rotate(Vector2 direction)
    {
        float degree = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // _characterRenderer.flipX = Mathf.Abs(degree) > 90f;
        Vector3 theScale = transform.localScale;
        theScale.x = Mathf.Abs(theScale.x) * (Mathf.Abs(degree) > 90f ? -1 : 1);
        transform.localScale = theScale;
        _arm.rotation = Quaternion.Euler(0, 0, degree);
    }
}
