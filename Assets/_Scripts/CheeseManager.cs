using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CheeseManager : MonoBehaviour
{
    public static CheeseManager current;

    [SerializeField] GameObject cheeseHud;
    [SerializeField] Sprite goldenCheese;
    [SerializeField] int cheeseNumToFinish = 3;

    int cheeseFound;

    GameObject[] cheeses;
    GameObject[] cheeseHuds;
    MouseDoor[] mouseDoors;
    Transform player;

    public event Action onFoundAllCheese;
    public void FoundAllCheese()
    {
        if (onFoundAllCheese != null)
        {
            onFoundAllCheese();
        }
    }

    public event Action onCheeseDestruction;
    public void CheeseDestruction()
    {
        cheeseFound++;
        if (cheeseFound == cheeseNumToFinish)
        {
            onFoundAllCheese();
            Invoke("ActivateVirtualCam", 0.5f);
            Invoke("DeactivateVirtualCam", 3);
        }
    }

    private void Awake()
    {
        current = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        mouseDoors = GameObject.FindObjectsOfType<MouseDoor>();
        StartCoroutine(LateStart());
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.1f);
        cheeses = GameObject.FindGameObjectsWithTag("Cheese");
        cheeseHuds = new GameObject[cheeses.Length];

        for (int i = 0; i < cheeseHuds.Length; i++)
        {
            GameObject child = Instantiate(cheeseHud);
            child.transform.parent = transform;
            child.transform.localScale = new Vector3(1, 1, 1);
            cheeseHuds[i] = child;
            cheeseHuds[i].GetComponent<Image>().color = new Color32(255, 255, 255, 50);
            if(i >= cheeseNumToFinish)
            {
                cheeseHuds[i].GetComponent<Image>().sprite = goldenCheese;
            }
        }
        for (int i = 0; i < cheeses.Length; i++)
        {
            cheeseHuds[i].SetActive(false);
        }

        for (int i = 0; i < cheeses.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            cheeseHuds[i].SetActive(true);
        }

        yield return new WaitForSeconds(2);

        for (int i = 0; i < cheeses.Length; i++)
        {
            cheeseHuds[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKey("f"))
        {
            int found = 0;
            for (int i = 0; i < cheeses.Length; i++)
            {
                cheeseHuds[i].SetActive(true);
                if (cheeses[i] == null)
                {
                    found++;
                }
            }

            for (int i = 0; i < found; i++)
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

    float shortestDist;
    int shortestCam;

    void ActivateVirtualCam()
    {
        for (int i = 0; i < mouseDoors.Length; i++)
        {
            if (i == 0)
            {
                shortestDist = Vector3.Distance(player.position, mouseDoors[i].virtualCam.transform.position);
                shortestCam = i;
            }
            else
            {
                if (Vector3.Distance(player.position, mouseDoors[i].virtualCam.transform.position) < shortestDist)
                {
                    print("Shorter");
                    shortestDist = Vector3.Distance(player.position, mouseDoors[i].virtualCam.transform.position);
                    shortestCam = i;
                }
            }
        }

        mouseDoors[shortestCam].virtualCam.SetActive(true);
    }

    void DeactivateVirtualCam()
    {
        for (int i = 0; i < mouseDoors.Length; i++)
        {
            mouseDoors[i].virtualCam.SetActive(false);
        }
    }
}
