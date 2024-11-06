using UnityEngine;

public class MedEnemyShip : Enemy
{
    protected override void Attack()
    {
        Debug.Log("Medium ship attacking");
    }
    
    void Start()
    {
        MoveSpeed = 200f;
    }
}
