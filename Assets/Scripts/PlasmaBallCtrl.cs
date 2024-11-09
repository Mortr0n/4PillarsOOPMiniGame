using UnityEngine;
using System.Collections;

public class PlasmaBallCtrl : Projectile
{
    //public GameObject Target;
    private float timeToReTarget = .3f;
    [SerializeField] private Vector3 targetPOS;
    private float timeToDeath = 4f;
    private float xBoundary = 15f;
    private float zBoundary = 15f;
    private Vector3 initialImpulseDirection = Vector3.down;

    void Start()
    {
        //Debug.Log("Start for Plasma ball ctrl");
        thisRb = GetComponent<Rigidbody>();
        if (thisRb == null)
        {
            Debug.Log("thisRb not found!");
        }

        MoveSpeed = 8f;
        targetPOS = GameObject.FindWithTag("Player").transform.position;
        ReAcquireTarget();
        StartCoroutine(SelfDestructTimer());
    }

    public override void Move()
    {
        if (transform.position.x < -xBoundary || transform.position.z < -zBoundary || transform.position.z > zBoundary || transform.position.x > xBoundary)
        {
            Destroy(gameObject);
        }
        
        //Debug.Log($"nowThisRb {thisRb}");  Holy shit here.  This was it all along!
        if (thisRb != null && TargetObject != null)
        {
            Vector3 direction = (TargetObject.transform.position - transform.position).normalized;
            thisRb.AddForce(direction * MoveSpeed, ForceMode.Force);
        } 
    }

   
    public IEnumerator ReAcquireTarget()
    {
        yield return new WaitForSeconds(timeToReTarget);
        targetPOS = TargetObject.transform.position;
    }
 
    public IEnumerator SelfDestructTimer()
    {
        yield return new WaitForSeconds(timeToDeath);
        SelfDestruct();
    }

    private void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
