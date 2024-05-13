using UnityEngine;

public class MeleeWeapon : WeaponController
{
    protected override void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapAreaAll(
            CalculateSectorPoint(_direction, -1),
            CalculateSectorPoint(_direction),
            AttackData.target
        );
    }

    private Vector2 CalculateSectorPoint(Vector2 center, int direction = 1)
    {
        MeleeAttackSO meleeAttackSO = AttackData as MeleeAttackSO;
        float halfAngle = meleeAttackSO.angle / 2f;
        Vector2 direc = Quaternion.Euler(0, 0, direction * halfAngle) * center.normalized;

        return direc * meleeAttackSO.range;
    }

    public void OnDrawGizmosSelected()
    {
        Vector2 playerPosition = _controller.transform.position;
        Vector2 startPoint = CalculateSectorPoint(_direction, -1);
        Vector2 endPoint = CalculateSectorPoint(_direction);

        Gizmos.color = Color.red;

        Gizmos.DrawLine(playerPosition, playerPosition + startPoint);
        Gizmos.DrawLine(playerPosition, playerPosition + endPoint);
    }
}