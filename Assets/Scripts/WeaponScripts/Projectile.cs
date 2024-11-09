using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected Rigidbody thisRb;
    private float _moveSpeed;
    private float _damage;
    [SerializeField] private GameObject _targetObject;
    public int count;

    protected float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    protected float Damage { get { return _damage; } set { _damage = value; } }
    protected GameObject TargetObject { get { return _targetObject; } }

    public abstract void Move();


    public virtual void SetTarget(GameObject targetObject)
    {
        Debug.Log($"Set target called with {targetObject.name}");
        _targetObject = targetObject;
    }


    void Start()
    {
        thisRb = GetComponent<Rigidbody>();
        if (thisRb == null)
        {
            Debug.LogError("Rigidbody not found on Projectile");
        }
    }

    void FixedUpdate()
    {
        //if (count < 1)
        //{
        //    Debug.Log("Fixed update before move called");
        //} 
        //count++;
        
        Move();
    }

    
}
