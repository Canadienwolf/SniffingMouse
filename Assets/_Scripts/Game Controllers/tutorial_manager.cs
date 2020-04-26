using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class tutorial_manager : MonoBehaviour
{
    VideoPlayer vid_player;
    Image img_displayInput;
    Text txt_tutorialBtn;

    [SerializeField] VideoClip clip;
    [SerializeField] Sprite spr_displayInput;

    bool vidActive;
    bool textActive;

    private void Awake()
    {
        vid_player = GameObject.FindObjectOfType<VideoPlayer>();
        img_displayInput = vid_player.transform.GetChild(0).gameObject.GetComponent<Image>();
        txt_tutorialBtn = vid_player.gameObject.transform.parent.GetChild(0).GetComponent<Text>();
    }

    private void Start()
    {
        ActivateText(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown("t") && textActive)
        {
            ActivateVid(!vidActive);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("Entered");
            ActivateText(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            print("Exit");
            ActivateText(false);
        }
    }

    void ActivateVid(bool idx)
    {
        vidActive = idx;
        vid_player.gameObject.SetActive(idx);
        vid_player.clip = clip;
        img_displayInput.sprite = spr_displayInput;
    }

    void ActivateText(bool idx)
    {
        textActive = idx;
        txt_tutorialBtn.gameObject.SetActive(idx);
        if (!idx)
            ActivateVid(idx);
    }
}
