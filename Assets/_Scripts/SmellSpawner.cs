using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SmellSpawner : MonoBehaviour
{

    public GameObject smell;
    [Range(0.1f, 10)]
    public float spawnInterval = 3f;

    public int maxSpawns = 10;

    private float spawnCounter;
    private float spawnTimer;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer = Mathf.MoveTowards(spawnTimer, 0, Time.deltaTime);
        if (spawnTimer == 0 && spawnCounter != maxSpawns)
        {
            spawnTimer = spawnInterval;
            spawnCounter++;
            SmellSpawnTimer();
        }
        
        
    }

    public void SmellSpawnTimer()
    {
        Instantiate(smell, transform.position, Quaternion.identity);
    }
    
}
