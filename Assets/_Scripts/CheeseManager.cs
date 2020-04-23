using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheeseManager : MonoBehaviour
{
    [SerializeField] GameObject cheeseHud;

    int cheeseFound;

    GameObject[] cheeses;
    GameObject[] cheeseHuds;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LateStart", 0.1f);
    }

    void LateStart()
    {
        cheeses = GameObject.FindGameObjectsWithTag("Cheese");
        cheeseHuds = new GameObject[cheeses.Length];

        for (int i = 0; i < cheeseHuds.Length; i++)
        {
            GameObject child = Instantiate(cheeseHud);
            child.transform.parent = transform;
            child.transform.localScale = new Vector3(1, 1, 1);
            cheeseHuds[i] = child;
            cheeseHuds[i].GetComponent<Image>().color = new Color32(255, 255, 255, 50);
        }
        for (int i = 0; i < cheeses.Length; i++)
        {
            cheeseHuds[i].SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetKey("f"))
        {
            cheeseFound = 0;
            for (int i = 0; i < cheeses.Length; i++)
            {
                cheeseHuds[i].SetActive(true);
                if (cheeses[i] == null)
                {
                    cheeseFound++;
                    
                }
            }

            for (int i = 0; i < cheeseFound; i++)
            {
                cheeseHuds[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
        }

        if (Input.GetKeyUp("f"))
        {
            for (int i = 0; i < cheeses.Length; i++)
            {
                cheeseHuds[i].SetActive(false);
            }
        }
    }
}
