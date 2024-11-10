using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    #region Private Fields
    [SerializeField] private Rigidbody thisRb;
    [SerializeField] protected GameObject _firePoint;
    [SerializeField] protected GameObject _weaponDischarge;
    private float _moveSpeed = 100f;
    private bool _moveEnabled = true;
    private int _scoreValue = 1;

    private bool _attackEnabled;
    private float _attackTime = 1f;
    private Coroutine attackCoroutine;
    protected float ejectForce = 5f;
    protected Vector3 initialImpulseDirection = new Vector3(0, 0, -1);
    #endregion

    #region Public Properties
    // ENCAPSULATION
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

    // Start or stop attack timer based on passed value
    public bool AttackEnabled
    {
        get { return _attackEnabled; }
        set 
        { 
            if (_attackEnabled != value) 
            {
                _attackEnabled = value;
            }
            if (_attackEnabled)
            {
                StartAttackTimer();
            }
            else
            {
                StopAttackTimer();
            }
        } // I'm really toying around with ideas of how to utilize setters and getters.  Seemed interesting to make a toggle instead
    }

    public int ScoreValue
    {
        get { return _scoreValue; }
        set { _scoreValue = value; }
    }
   
    public float AttackTime
    {
        get { return _attackTime; }
        set { _attackTime = value; }
    }
    #endregion

    // control attack coroutine by enabling attack
    private void Start()
    {
        thisRb = GetComponent<Rigidbody>();
        //AttackEnabled = true;
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
    protected virtual void Die() // POLYMORPHISM
    {
        GameManager.Instance.Score += ScoreValue;
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("PlayerWeapon"))
        {
            Destroy(collision.gameObject);
            
            GameManager.Instance.Score++;
            GameManager.Instance.UpdateScoreText(GameManager.Instance.Score);
            
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.DamagePlayer();
            Destroy(gameObject);
        }
    }

    private void StartAttackTimer()
    {
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }
        attackCoroutine = StartCoroutine(AttackTimer());
    }

    private void StopAttackTimer()
    {
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
            attackCoroutine = null;
        }
    }

    // AttackTimer is adjustable using AttackTime to set the wait value as well as overriding this funciton if necessary
    protected virtual IEnumerator AttackTimer()
    {
        while (_attackEnabled)
        {
            Debug.Log("Attacking");
            yield return new WaitForSeconds(_attackTime);
            Attack(); 
        }
    }

}
