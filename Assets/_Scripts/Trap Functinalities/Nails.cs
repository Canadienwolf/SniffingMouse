using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Nails : MonoBehaviour
{
    public ParticleSystem hit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.transform.GetChild(0).gameObject);
            ParticleSystem ps = Instantiate(hit, collision.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            ps.Play();
            Invoke("Kill", 3);
        }
    }

    void Kill()
    {
        SceneManager.LoadScene("menu_ScoreDisplay", LoadSceneMode.Single);
    }
}
