using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_CheeseAndTrapsSpawn : MonoBehaviour
{
    [Header("Cheese spawning:")]
    public List<Transform> cheeseSpawns;
    public List<GameObject> cheeses;
    public int cheeseToBeSpawned = 0;
    [Header("Trap spawning:")]
    public List<Transform> trapSpawns;
    public List<GameObject> traps;
    public int trapsToBeSpawned = 0;

    void Awake()
    {
        for (int i = 0; i < cheeseSpawns.Count; i++)
        {
            Transform temp = cheeseSpawns[i];
            int rand = Random.Range(0, cheeseSpawns.Count);
            cheeseSpawns[i] = cheeseSpawns[rand];
            cheeseSpawns[rand] = temp;
        }

        for (int i = 0; i < trapSpawns.Count; i++)
        {
            Transform temp = trapSpawns[i];
            int rand = Random.Range(0, trapSpawns.Count);
            trapSpawns[i] = trapSpawns[rand];
            trapSpawns[rand] = temp;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cheeseToBeSpawned; i++)
        {
            int rand = Random.Range(0, cheeses.Count);
            Instantiate(cheeses[rand], cheeseSpawns[i].transform.position, cheeseSpawns[i].transform.rotation);
        }

        for (int i = 0; i < trapsToBeSpawned; i++)
        {
            int rand = Random.Range(0, traps.Count);
            Instantiate(traps[rand], trapSpawns[i].transform.position, trapSpawns[i].transform.rotation);
        }
    }
}
