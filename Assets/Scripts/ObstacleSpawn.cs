using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject spawnPoint;

    public float spawnDelay = 2;
    public float spawnTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", spawnDelay, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObstacle()
    {
        Instantiate(obstacle, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
