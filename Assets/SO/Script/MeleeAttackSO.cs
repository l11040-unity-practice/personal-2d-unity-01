using UnityEngine;

public enum RangeType
{
    Sector,
    Square,
    Circle,
}
[CreateAssetMenu(fileName = "MeleeAttackSO", menuName = "Attacks/Melee", order = 0)]
public class MeleeAttackSO : AttackSO
{
    [Header("Melee")]
    public RangeType rangeType;
    public float range;

    [Header("Sector")]
    public float angle;
    [Header("Square")]
    public float width;
}
