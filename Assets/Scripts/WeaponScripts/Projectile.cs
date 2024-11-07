using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected Rigidbody thisRb;
    private float _moveSpeed;
    private float _damage;
    private GameObject _targetObject;

    protected float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    protected float Damage { get { return _damage; } set { _damage = value; } }

    public abstract void Move();

    public virtual void SetTarget(GameObject targetObject)
    {
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
