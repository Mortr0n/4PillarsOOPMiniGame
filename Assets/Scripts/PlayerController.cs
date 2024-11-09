using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject playerObj;
    [SerializeField] Rigidbody playerRb;
    [SerializeField] private GameObject _firePoint;
    [SerializeField] private GameObject playerLaser;

    protected Vector3 initialImpulseDirection = new Vector3(0, 0, 1);
    private bool canFire = true;
    private float weaponFirePause = .1f;
    private float ejectForce = 2f;

    private float xBoundary = 10.2f;
    private float zBoundary = 7f;
    private float moveSpeed = 1.5f;

    

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        ejectForce = 5f;
    }

    private void FixedUpdate()
    {
        Vector3 playerPos = transform.position;
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        if (transform.position.x < -xBoundary)
        {
            transform.position = new Vector3(-xBoundary, 0, transform.position.z);
        }
        if (transform.position.z < -zBoundary)
        {
            transform.position = new Vector3(transform.position.x, 0, -zBoundary);
        }
        if (transform.position.z > zBoundary)
        {
            transform.position = new Vector3(transform.position.x, 0, zBoundary);
        }
        if (transform.position.x > xBoundary)
        {
            transform.position = new Vector3(xBoundary, 0, transform.position.z);
        }
        else
        {
            Vector3 move = new Vector3(xInput, 0, zInput) * moveSpeed;
            transform.Translate(move);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canFire)
        {
            canFire = false;
            StartCoroutine(FireWeapon(playerLaser));
        }
    }

    private IEnumerator FireWeapon(GameObject weapon)
    {
        Vector3 rotation = new Vector3(0, 90, 90);
        Quaternion rotationQuat = Quaternion.Euler(rotation);
        GameObject firedWeapon = Instantiate(weapon, _firePoint.transform.position, rotationQuat);
        Rigidbody weaponRb = firedWeapon.GetComponent<Rigidbody>();

        // Apply an initial impulse to shoot away from the ship
        Vector3 impulseForce = initialImpulseDirection * ejectForce;
        weaponRb.AddForce(impulseForce, ForceMode.Impulse);
        yield return new WaitForSeconds(weaponFirePause);
        canFire = true;
    }
}
