using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    #region Private Fields
    private Rigidbody thisRb;
    private float _moveSpeed = 100f;
    private bool _moveEnabled = true;
    private bool _attackEnabled = true;
    private float _attackTime = 1f;
    private bool attackTimerRunning = true;
    #endregion

    #region Public Properties
    public float MoveSpeed
    {
        get { return _moveSpeed; }
        //TODO: think through the setter and getter here and what could I do to control these!
        set  
        {
            _moveSpeed = value;
        }
    }
    public bool MoveEnabled // in case we find a different method of movement and the move in fixed update becomes problematic
    { 
        get { return _moveEnabled; } 
        set { _moveEnabled = value; }    
    }
    public bool AttackEnabled
    {
        get { return _attackEnabled; }
        private set { _attackEnabled = !_attackEnabled; } // I'm really toying around with ideas of how to utilize setters and getters.  Seemed interesting to make a toggle instead
    }
    // felt like toggle makes sense to be with the props since it controls the setter basically
    public void ToggleAttackEnabled()
    {
        AttackEnabled = !AttackEnabled;
    }
    public float AttackTime
    {
        get { return _attackTime; }
        set { _attackTime = value; }
    }
    #endregion

    private void Start()
    {
        thisRb = GetComponent<Rigidbody>();
        StartCoroutine(AttackTimer());
    }

    public void FixedUpdate()
    {
        if (_moveEnabled)
        {
            MoveDown();
        }
    }

    //MoveDown is virtual and can be overridden if necessary
    protected virtual void MoveDown()
    {
        Vector3 down = new Vector3(0, 0, -1);
        if (thisRb != null)
        {
            Vector3 downForce = down * _moveSpeed;
            thisRb.AddForce(downForce, ForceMode.Force);
        }
    }

    // Attack is abstract and must be overridden an implemented in each inheriting classes own way
    protected abstract void Attack();

    protected virtual IEnumerator AttackTimer()
    {
        while (_attackEnabled)
        {
            yield return new WaitForSeconds(_attackTime);
        }
    }

}
