using UnityEngine;

public class PlayerLaser : Projectile
{
    void Start()
    {
        thisRb = GetComponent<Rigidbody>();
        MoveSpeed = 1.0f;
    }

    public override void Move()
    {

        Vector3 upForce = Up * MoveSpeed;
        thisRb.AddForce(upForce, ForceMode.Force);
    }
}
