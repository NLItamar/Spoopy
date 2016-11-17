using UnityEngine;
using System.Collections;

public class cleansingRoom : MonoBehaviour {

    //distance player and exorcist
    public Transform player;
    private float distancePlayer;
    public float minDistance = 10f;
    private bool timerOn;
    public float timer = 10f;

	// Use this for initialization
	void Start () {
        timerOn = false;
	}
	
	// Update is called once per frame
	void Update () {
        distancePlayer = Vector3.Distance(transform.position, player.position);
        if(distancePlayer <= minDistance)
        {
            timerOn = true;
            exorcism();
        }
        if (distancePlayer > minDistance)
        {
            timerOn = false;
        }
    }

    public void exorcism()
    {
        timer -= Time.deltaTime;

        //effects on player


        if (timer <= 0)
        {
            Application.LoadLevel("GameOver");
        }
    }
}
