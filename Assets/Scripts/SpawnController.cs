
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnables;
    [SerializeField] public List<GameObject> spawnedEnemies = new List<GameObject>();
    [SerializeField] private GameObject enemyLarge;
    private float spawnZ = 11.5f;
    private float spawnX = 9.5f;
    public float spawnWait = 1.2f;
    void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    void Update()
    {
        
    }

    public Vector3 GetRandomSpawnLoc() // ABSTRACTION
    {
        float randX = Random.Range(-spawnX, spawnX);
        return new Vector3(randX, 3, spawnZ);
    }

    public GameObject SpawnNewEnemy() // ABSTRACTION
    {
        int enemyIdx = Random.Range(0, spawnables.Length);
        Vector3 spawnPos = GetRandomSpawnLoc();

        Debug.Log("Spawning new Enemy");
        GameObject newEnemy = Instantiate(spawnables[enemyIdx], spawnPos, transform.rotation);
        //GameObject newEnemy = Instantiate(enemyLarge, spawnPos, transform.rotation);
        if (newEnemy != null)
        {
            Debug.Log($"successfully instantiated {newEnemy.name}");
        }
        else
        {
            Debug.Log("something aint right!");
        }
        return newEnemy;
    }

    private IEnumerator SpawnTimer() // ABSTRACTION
    {
        Debug.Log("Spawn Timer Start");
        yield return new WaitForSeconds(spawnWait);
        GameObject newEnemy = SpawnNewEnemy(); // ABSTRACTION
        spawnedEnemies.Add(newEnemy);
        StartCoroutine(SpawnTimer());
    }

}
