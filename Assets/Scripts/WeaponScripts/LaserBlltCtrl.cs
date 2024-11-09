using UnityEngine;

public class LaserBlltCtrl : Projectile //INHERITANCE
{
    private void Start()
    {
        thisRb = GetComponent<Rigidbody>();
        MoveSpeed = 1.0f;
    }

    public override void Move() // POLYMORPHISM
    {
        
        Vector3 downForce = Down * MoveSpeed;
        thisRb.AddForce(downForce, ForceMode.Force);
    }
}
