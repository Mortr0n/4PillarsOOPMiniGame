using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected Transform _firePoint;
    protected float _fireRate;
    protected float _fireSpeed;
    protected float _fireWaitTime;

    public Weapon(Transform firePoint)
    { _firePoint = firePoint; }
    public float FireRate
    {
        get { return _fireRate; }
        set { _fireRate = value; }
    }
    public float FireSpeed
    {
        get { return _fireSpeed; }
        set { _fireSpeed = value; }
    }
    public float FireWaitTime
    {
        get { return _fireWaitTime; }
        set { _fireWaitTime = value; }
    }

    public abstract void Fire();

}
