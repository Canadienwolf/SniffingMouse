using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesController : MonoBehaviour
{
    public enum emotions { Neutral, Glad, Angry, Dead, Exited, Scared, Confused, Happy, Sad};
    public emotions EyeState;

    public Material mat;

    public Vector2 offset;


    private void Start()
    {
        ChangeEyes();
    }

    public void ChangeEyes()
    {
        switch (EyeState)
        {
            case emotions.Neutral:
                offset = new Vector2(1, .67f);
                break;
            case emotions.Glad:
                offset = new Vector2(.335f, .69f);
                break;
            case emotions.Angry:
                offset = new Vector2(.67f, .67f);
                break;
            case emotions.Dead:
                offset = new Vector2(1, .335f);
                break;
            case emotions.Exited:
                offset = new Vector2(.335f, .335f);
                break;
            case emotions.Scared:
                offset = new Vector2(.67f, .335f);
                break;
            case emotions.Confused:
                offset = new Vector2(1, 1);
                break;
            case emotions.Happy:
                offset = new Vector2(.335f, 1);
                break;
            case emotions.Sad:
                offset = new Vector2(.67f, 1);
                break;
            default:
                break;
        }

        mat.mainTextureOffset = offset;
    }
}
