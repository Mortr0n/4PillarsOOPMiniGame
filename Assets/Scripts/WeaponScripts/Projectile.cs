using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected Rigidbody thisRb;
    private float _moveSpeed;
    private float _damage;
    [SerializeField] private GameObject _targetObject;
    public int count;
    //private Vector3 Down => new Vector3(0, 0, -1);
    protected static readonly Vector3 Down = new Vector3(0, 0, -1);
    protected static readonly Vector3 Up = new Vector3(0, 0, 1);

    // ENCAPSULATION
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
        Move();
    }

    
}
