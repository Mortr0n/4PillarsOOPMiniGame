using Unity.VisualScripting;
using UnityEngine;

public class LargeEnemyShip : Enemy
{
    //[SerializeField] GameObject plasmaObj;
    //[SerializeField] GameObject firePoint;
    //[SerializeField] GameObject playerObject;
    public float plasmaBallSpeed = 10f;
    //private Vector3 initialImpulseDirection = new Vector3(0, 0, -1);
    //private float ejectForce = 5f;

    void Start()
    {
        MoveSpeed = 150;
        AttackEnabled = true;
        ejectForce = 5f;
    }

    protected override void Attack()
    {
        //Debug.Log("Large ship attacking");
        FirePlasmaBall();
    }

    private void FirePlasmaBall()
    {
        //Debug.Log("Firing plasma ball");
        GameObject plasmaBall = Instantiate(_weaponDischarge, _firePoint.transform.position, _firePoint.transform.rotation);
        Rigidbody plasmaRb = plasmaBall.GetComponent<Rigidbody>(); 

        // Apply an initial impulse to shoot away from the ship
        Vector3 impulseForce = initialImpulseDirection * ejectForce;
        plasmaRb.AddForce(impulseForce, ForceMode.Impulse);

        Projectile plasmaCtrl = plasmaBall.GetComponent<Projectile>();
        if (plasmaCtrl != null)
        {
            plasmaCtrl.SetTarget(GameObject.FindWithTag("Player"));
        }
        else
        {
            Debug.LogError("unable to set target using plasma ball projectile controller");
        }
        
    }
}
