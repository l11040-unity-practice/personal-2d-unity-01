using UnityEngine;

[CreateAssetMenu(fileName = "DefaultAttackSO", menuName = "Attacks/Default", order = 0)]
public class AttackSO : ScriptableObject
{
    [Header("Attack Info")]
    public float delay;
    public float power;
    public float speed;
    public LayerMask target;
}
