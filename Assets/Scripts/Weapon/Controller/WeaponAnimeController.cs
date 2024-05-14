using UnityEngine;

public class WeaponAnimeController : MonoBehaviour
{
    private readonly int attack = Animator.StringToHash("attack");
    private WeaponController _weaponController;
    private Animator _animator;
    private void Awake()
    {
        _weaponController = GetComponent<WeaponController>();
        _animator = GetComponent<Animator>();
        _weaponController.InitEvent += Init;
    }
    private void Init()
    {
        _weaponController.EntityController.OnAttackEvent += Attack;
    }
    private void Attack()
    {
        _animator.SetTrigger(attack);
    }
}