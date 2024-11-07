using UnityEngine;

public class PlasmaBallCtrl : Projectile
{
    
    void Start()
    {
        MoveSpeed = 20f;
    }

    public override void Move()
    {
        Vector3 down = new Vector3(0, 0, -1) * MoveSpeed;
        if (thisRb != null)
        {
            thisRb.AddForce(down, ForceMode.Force);
        }
    }
 
}
