using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour {
    public float timer = 10;
    public float quitTimer = 35;

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    void Update ()
    {
        timer -= Time.deltaTime;
        quitTimer -= Time.deltaTime;
        
        if(timer <= 0)
        {
            Debug.Log("aids");
            this.transform.Translate(0, 0.03f, 0);
        }
        if(quitTimer <= 0)
        {
            LoadScene("Marc");
        }
        if (Input.anyKey)
        {
            LoadScene("Marc");
        }

    }
}
