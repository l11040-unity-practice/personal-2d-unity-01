using UnityEngine;

public class WeaponEquipSystem : MonoBehaviour
{
    [SerializeField] private GameObject Arm;
    [SerializeField] private GameObject WeaponPrefab;

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
            weaponInstance.GetComponent<WeaponController>().InitWeapon(_controller);

        }
    }
}
