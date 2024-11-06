using UnityEngine;

public class PlasmaBallCtrl : Enemy
{
    
    // this is absolutely not how to do this, but I thought I would get creative with my inheritance and utiize the enemy's move down function.

    protected override void Attack() //I have to implement, doesn't mean it has to do anything
    {
        // Don't use.
    }

    void Start()
    {
        MoveSpeed = 20f;
        MoveEnabled = true;

    }
 
}
