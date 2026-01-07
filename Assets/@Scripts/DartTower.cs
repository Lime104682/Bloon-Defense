using UnityEngine;

public class DartTower : TowersBase
{
    public GameObject DartProjectilePrefab;

    protected override void Attack(Transform target)
    {
        if (target == null) 
            return;

        var projectile = Instantiate(
            DartProjectilePrefab,
            FireSocket.position,
            Quaternion.AngleAxis(base.angle-180, Vector3.forward)
        );

        projectile.GetComponent<TowerAtkBase>().Init(target);
    }
}
