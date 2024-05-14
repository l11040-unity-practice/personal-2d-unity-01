using System;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;
    public bool IsAttacking { get; set; }
    protected bool _isDirectionLocked = false;
    private float _directionLockDuration = 0.5f;
    private float _directionLockTimer = float.MaxValue;
    private float _lastAttackTimer = float.MaxValue;
    private WeaponEquipSystem _weaponEquipSystem;

    protected virtual void Awake()
    {
        _weaponEquipSystem = GetComponent<WeaponEquipSystem>();
    }

    protected virtual void Update()
    {
        HandleDirectionLock();
        HandleAtteckDelay();
    }


    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }


    private void HandleDirectionLock()
    {
        if (_isDirectionLocked)
        {
            _directionLockTimer += Time.deltaTime;
            if (_directionLockTimer >= _directionLockDuration)
            {
                _isDirectionLocked = false;
                _directionLockTimer = 0f;
            }
        }
    }
    private void HandleAtteckDelay()
    {
        if (_weaponEquipSystem.EquipWeaponController == null) return;

        if (_lastAttackTimer < _weaponEquipSystem.EquipWeaponController.AttackData.delay)
        {
            _lastAttackTimer += Time.deltaTime;
        }
        else if (IsAttacking)
        {
            _lastAttackTimer = 0f;
            CallAttackEvent();
        }
    }
}
