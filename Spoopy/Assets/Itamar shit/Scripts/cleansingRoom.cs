using UnityEngine;
using System.Collections;

public class cleansingRoom : MonoBehaviour {

    //distance player and exorcist
    public Transform player;
    private float distancePlayer;
    public float minDistance = 10f;

    //timers until exorcism
    private bool timerOn;
    public float timer = 10f;

    //motion blur for each stage
    public bool normal = true;
    public bool first;
    public bool second;
    public bool third;
    public bool fourth;
    public bool fifth;
    public GameObject motionblur;

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

        //effects on player connecting to the motion blur
        if(timer == 10)
        {
            normal = true;
        }
        if(timer == 9 || timer == 8)
        {
            first = true;
            normal = false;

        }
        if(timer == 7 || timer == 6)
        {
            second = true;
            first = false;
        }
        if(timer == 5 || timer == 4)
        {
            third = true;
            second = false;
        }
        if(timer == 3 || timer == 2)
        {
            fourth = true;
            third = false;
        }
        if(timer <= 0)
        {
            fifth = true;
            fourth = false;
        }

        /*if (timer <= 0)
        {
            Application.LoadLevel("GameOver");
        }*/
    }
}
