using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _moveSpeed = 10f;
    public float MoveSpeed
    {
        get { return _moveSpeed; }
        //TODO: think through the setter and getter here and what could I do to control these!
        set  
        {
            _moveSpeed = value;
        }
    }

    //TODO: make the same movement here as the MoveDown in my personal project maybe.  Make them so that they can be overridden so virtual or I think we can do abstract if we 
    //TODO: want every object to set their own up.  Maybe actually make the weapons be abstract and each sets their own weapons.  so virtual for move so that I can adjust for 
    //TODO: more asteroid like behavior or differing enemies and then abstract for weapons.
}
