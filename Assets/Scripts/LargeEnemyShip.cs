using UnityEngine;

public class LargeEnemyShip : Enemy
{
    [SerializeField] GameObject plasmaObj;
    public float plasmaBallSpeed = 200f;

    void Start()
    {
        MoveSpeed = 150;
        AttackEnabled = true;
    }

    protected override void Attack()
    {
        Debug.Log("Large ship attacking");
        FirePlasmaBall();
    }

    private void FirePlasmaBall()
    {
        Debug.Log("Firing plasma ball");
        GameObject plasmaBall = Instantiate(plasmaObj, transform.position, transform.rotation);

        Vector3 down = new Vector3(0, 0, -1);

        Rigidbody pRb = plasmaBall.GetComponent<Rigidbody>();
        if (pRb != null) 
        {
            Vector3 downForce = down * plasmaBallSpeed;
            pRb.AddForce(downForce, ForceMode.VelocityChange);
        };
    }
}
