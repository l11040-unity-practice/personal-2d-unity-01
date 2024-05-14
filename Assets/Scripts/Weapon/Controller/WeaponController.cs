using System;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] public AttackSO AttackData;
    [HideInInspector] public event Action InitEvent;
    [HideInInspector] public EntityController EntityController;
    protected SpriteRenderer _weaponRenderer;
    protected Vector2 _direction;

    protected virtual void Awake()
    {
        _weaponRenderer = GetComponentInChildren<SpriteRenderer>();
        InitEvent += SubMethod;
    }

    private void SubMethod()
    {
        if (EntityController)
        {
            EntityController.OnAttackEvent += Attack;
            EntityController.OnLookEvent += Look;
        }
    }

    public void Init(EntityController controller)
    {
        EntityController = controller;
        InitEvent?.Invoke();
    }

    protected virtual void Look(Vector2 direction)
    {
        float degree = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _weaponRenderer.flipY = Mathf.Abs(degree) > 90f;
        _direction = direction;
    }

    protected virtual void Attack()
    {
        _weaponRenderer.flipY = false;
    }
}
