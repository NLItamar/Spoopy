using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class cleansingRoom : MonoBehaviour {

    ExorcistMovement eMove;
    public GameObject player;

    //timer for exorcism
    public float eTimer = 0f;
    public float eMaxTimer = 5f;

    // Use this for initialization
    void Start () {
        eMove = eMove.GetComponent<ExorcistMovement>();
    }

    // Update is called once per frame
    void Update () {
        //if exorcist arrives in a room the exorcism starts AKA the timer
        /*if(eMove.changeRoom)
        {
            Exorcism();
        }*/
    }

    void Exorcism()
    {
        eTimer += Time.deltaTime;
        if (eTimer >= eMaxTimer)
        {
            eTimer = 0f;
            GameOver();
        }
    }
    void GameOver()
    {
        //SceneManager.LoadScene("GameOver");
        Application.LoadLevel("GameOver");
    }
}
