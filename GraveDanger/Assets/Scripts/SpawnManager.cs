using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    // Serializable Fields
    [Tooltip("Time between each zombie spawn.")]
    [SerializeField] private float timeForZombieSpawn = 6f;

    [Tooltip("Time between each item spawn.")]
    [SerializeField] private float timeForItemSpawn = 10f;

    // Logic Variables
    private float timeLeftForZombieSpawn = 0;
    private float timeLeftForItemSpawn = 0;
    private bool stopped;

    // Components and Game objects
    [SerializeField] GameObject[] spawnPoints;

    void Start()
    {
        stopped = false;
    }

    void Update()
    {

        if (!stopped)
        {
            timeLeftForZombieSpawn -= Time.deltaTime;
            timeLeftForItemSpawn -= Time.deltaTime;


            if (timeLeftForZombieSpawn <= 0)
            {
                timeLeftForZombieSpawn = timeForZombieSpawn;
                ObjectPooler.instance.spawnFromPool(1, findPositionOnNavmesh(), this.gameObject.transform.rotation);
            }
            if (timeLeftForItemSpawn <= 0)
            {
                timeLeftForItemSpawn = timeForItemSpawn;
                int randItem = Random.Range(5, 8);
                ObjectPooler.instance.spawnFromPool(randItem, randomSpawnPoint(), this.gameObject.transform.rotation);
            }
        }
    }

    void OnEnable()
    {
        Player.dieEvent +=stopSpawning;
    }

    void OnDisable()
    {
        Player.dieEvent -=stopSpawning;
    }

    private void stopSpawning()
    {
        stopped = true;
    }


    private Vector3 findPositionOnNavmesh()
    {
        Vector3 randomDirection = (Random.insideUnitSphere * 20f) + transform.position;
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, 30f, UnityEngine.AI.NavMesh.AllAreas);
        Vector3 finalPosition = hit.position;

        return finalPosition ;
    }

    private Vector3 randomSpawnPoint()
    {
        int randItem = Random.Range(0, spawnPoints.Length);

        return spawnPoints[randItem].transform.position;
    }
}
