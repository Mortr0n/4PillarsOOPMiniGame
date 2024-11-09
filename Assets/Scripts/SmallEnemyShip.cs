using UnityEngine;

public class SmallEnemyShip : Enemy
{
    protected override void Attack()
    {
        GameObject laserObject = Instantiate(_weaponDischarge, _firePoint.transform.position, _firePoint.transform.rotation);
        Rigidbody laserRb = laserObject.GetComponent<Rigidbody>();
        Vector3 impulseForce = initialImpulseDirection * ejectForce;
        laserRb.AddForce(impulseForce, ForceMode.Impulse);
    }

    private void Start()
    {
        AttackEnabled = true;
        ejectForce = 1f;
    }
}
