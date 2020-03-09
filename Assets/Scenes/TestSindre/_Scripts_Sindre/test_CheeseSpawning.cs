using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test_CheeseSpawning : MonoBehaviour
{
    public GameObject[] cheeses;
    public GameObject spawnPointsParent;
    public int spawnAmount = 5;

    [SerializeField]private List<Transform> spawnPoints = new List<Transform>();

    private void Awake()
    {
        foreach (Transform child in spawnPointsParent.transform)
        {
            spawnPoints.Add(child);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnPoints.Count - spawnAmount; i++)
        {
            Transform temp = spawnPoints[i];
            int idx = Random.Range(i, spawnPoints.Count);
            spawnPoints[i] = spawnPoints[idx];
            spawnPoints[idx] = temp;
        }

        for (int i = 0; i < spawnPoints.Count - spawnAmount; i++)
        {
            Destroy(spawnPoints[i].gameObject);
        }

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (spawnPoints[i] != null)
            {
                GameObject go = Instantiate(cheeses[Random.Range(0, cheeses.Length)], spawnPoints[i].position, spawnPoints[i].rotation);
                go.transform.parent = spawnPoints[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            /*
            if (spawnPoints[i].childCount == 0)
            {
                Destroy(spawnPoints[i].gameObject);
                spawnPoints.RemoveAt(i);
            }
            */
            if (spawnPoints[i] == null)
            {
                spawnPoints.RemoveAt(i);
            }
        }

        if (spawnPoints.Count == 0)
        {
            //SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }
}
