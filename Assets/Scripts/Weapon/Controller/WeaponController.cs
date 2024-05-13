using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] protected AttackSO AttackData;
    protected EntityController _controller;
    protected SpriteRenderer _weaponRenderer;
    protected Vector2 _direction;

    protected virtual void Awake()
    {
        _weaponRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void InitWeapon(EntityController controller)
    {
        _controller = controller;
        if (_controller)
        {
            _controller.OnAttackEvent += Attack;
            _controller.OnLookEvent += Look;
        }
    }

    protected virtual void Look(Vector2 direction)
    {
        float degree = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _weaponRenderer.flipY = Mathf.Abs(degree) > 90f;
        _direction = direction;
    }

    protected virtual void Attack()
    {
    }

}
