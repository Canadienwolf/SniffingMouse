using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New PlayerST Mov", menuName = "PlayerSt Actions")]
public class PlayerStatesActions : ScriptableObject
{
    //checking if the player is picking up something
    public bool PickupOn;

    //checking if the player is throwing something
    public bool throwingOn;

    //checking if the player is placing down something
    public bool placingOn;

    //checking if the player is placing down something
    public bool holdingOn;


    /******************* Separate Functions *****************/

    //enabling only the picking action
    public void IsPicking()
    {
        PickupOn = true;
        throwingOn = false;
        placingOn = false;
        holdingOn = false;
    }

    //enabling only the throwing action
    public void IsThrowing()
    {
        PickupOn = false;
        throwingOn = true;
        placingOn = false;
        holdingOn = false;
    }

    //enabling only the placing action
    public void IsPlacing()
    {
        PickupOn = false;
        throwingOn = false;
        placingOn = true;
        holdingOn = false;
    }

    //enabling only the holding action
    public void IsHolding()
    {
        PickupOn = false;
        throwingOn = false;
        placingOn = false;
        holdingOn = true;
    }

    /************************* End *******************************/

    // All THOSE ABOVE FUNCTIONS JUST in one for other usage!

    public void OnlyOneAction()
    {
        if (PickupOn == true)
        {
            throwingOn = false;
            placingOn = false;
            holdingOn = false;
        }else if (throwingOn == true)
        {
            placingOn = false;
            holdingOn = false;
        }else if(placingOn == true)
        {
            holdingOn = false;
        }
        else
        {
            holdingOn = true;
        }
        


    }
}
