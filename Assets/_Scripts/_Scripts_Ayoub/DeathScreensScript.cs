using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreensScript : MonoBehaviour
{
    public Sprite cage, net, roomba, firework, grenade, springLoaded, toyCar, bucket, staples,electricalTrap;
    public GameObject imageScreen;
    public static int sprite = 0;
    // Start is called before the first frame update
    void Start()
    {
        RightSprite();
    }

    //for choosing theright sprite based on which trap has detected the mouse !
    public void RightSprite()
    {
        switch (sprite){
            case 1:
                imageScreen.gameObject.GetComponent<Image>().sprite =toyCar;
                break;
            case 2:
                imageScreen.gameObject.GetComponent<Image>().sprite = electricalTrap;
                break;
            case 3:
                imageScreen.gameObject.GetComponent<Image>().sprite = grenade;
                break;
            case 4:
                imageScreen.gameObject.GetComponent<Image>().sprite = staples;
                break;
            case 5:
                imageScreen.gameObject.GetComponent<Image>().sprite = net;
                break;
            case 6:
                imageScreen.gameObject.GetComponent<Image>().sprite = bucket;
                break;
            case 7:
                imageScreen.gameObject.GetComponent<Image>().sprite = firework;
                break;
            case 8:
                imageScreen.gameObject.GetComponent<Image>().sprite = roomba;
                break;
            case 9:
                imageScreen.gameObject.GetComponent<Image>().sprite = cage;
                break;
            case 10:
                imageScreen.gameObject.GetComponent<Image>().sprite = springLoaded;
                break;
            default:
                imageScreen.gameObject.GetComponent<Image>().sprite = null;
                break;


        }
    }
}
