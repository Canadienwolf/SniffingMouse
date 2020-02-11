using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Animations;
using UnityEngine;

public class test_BeKilled : MonoBehaviour
{
    public PlayerStatesMovements psm;
    public MenuController mc;
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("Release", true);
        psm.lockController = true;
        Invoke("ToMenu", 2);
    }

    void ToMenu()
    {
        mc.GoToSceneInt(2);
        psm.lockController = false;
        Cursor.visible = true;
    }
}
