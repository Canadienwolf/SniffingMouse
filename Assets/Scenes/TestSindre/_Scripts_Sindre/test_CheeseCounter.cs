using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_CheeseCounter : MonoBehaviour
{
    private GameObject[] cheese;
    public List<GameObject> cheeses;

    private void Start()
    {
        cheese = GameObject.FindGameObjectsWithTag("mediumCheese");
        for (int i = 0; i < cheese.Length; i++)
        {
            cheeses.Add(cheese[i]);
        }
    }

    private void Update()
    {
        for (int i = 0; i < cheeses.Count; i++)
        {
            if (cheeses[i] == null)
            {
                cheeses.RemoveAt(i);
            }
        }

        if (cheeses.Count == 0)
        {
            GameMangerScript.EndGame("You found all the cheese", 0);
        }
    }
}
