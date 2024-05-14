using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : EntityController
{
    private Camera _mainCamera;
    protected override void Awake()
    {
        base.Awake();
        _mainCamera = Camera.main;
    }
    public void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        if (direction != null)
        {
            CallMoveEvent(direction);
        }
    }

    public void OnLook(InputValue value)
    {
        Vector2 mousePos = value.Get<Vector2>();
        if (mousePos != null)
        {
            if (!IsAttacking && !_isDirectionLocked)
            {
                Vector2 direction = _mainCamera.ScreenToWorldPoint(mousePos) - transform.position;
                CallLookEvent(direction);
            }
        }
    }

    public void OnAttack(InputValue value)
    {
        IsAttacking = value.isPressed;
        _isDirectionLocked = true;
    }
}
