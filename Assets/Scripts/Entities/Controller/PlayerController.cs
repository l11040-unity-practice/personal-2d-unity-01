using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : EntityController
{
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
        Debug.Log("플레이어 마우스 움직임");
    }

    public void OnAttack()
    {
        Debug.Log("플레이어 공격");
    }
}
