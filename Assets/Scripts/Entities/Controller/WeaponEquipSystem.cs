using UnityEngine;

public class WeaponEquipSystem : MonoBehaviour
{
    [SerializeField] private GameObject Arm;
    [SerializeField] private GameObject WeaponPrefab;
    [HideInInspector] public WeaponController EquipWeaponController;

    private EntityController _controller;
    private void Awake()
    {
        _controller = GetComponent<EntityController>();
        Equip();
    }

    public void Equip()
    {
        if (WeaponPrefab != null && Arm != null)
        {
            GameObject weaponInstance = Instantiate(WeaponPrefab, WeaponPrefab.transform.position, Quaternion.identity, Arm.transform);
            EquipWeaponController = weaponInstance.GetComponent<WeaponController>();
            EquipWeaponController.Init(_controller);
        }
    }
}
