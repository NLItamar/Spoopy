using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fearhandler : MonoBehaviour {

    public int fearMax = 500;
    public int fearCurrent;
    public float fearprogres;
    public int decayNumber = 5;
    float timerSec; 
    public int timerSecRound = 0;
    int timerSecRoundOld = 0;
    public Scrollbar scrollie;
    bool winner = false;
    public GameObject levelComplete;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!winner)
        {
            if (fearCurrent >= fearMax)
            {
                winner = true;
                levelComplete.active = true;

            }
            if(fearCurrent >= decayNumber) { SteadyDecay(decayNumber); }
         
        }
       
        fearprogres = 1f * (float)fearCurrent / (float)fearMax;
        scrollie.size = fearprogres;
	}

    public void GetFearedBrother(int fearAmount)
    {
        fearCurrent += fearAmount;
    }

    void SteadyDecay(int decayAmount)
    {
        timerSec -= Time.deltaTime;
        timerSecRound = (int)timerSec;
        if (timerSecRound  != timerSecRoundOld)
        {
            timerSecRoundOld = timerSecRound;
            fearCurrent -= decayAmount;
        }
         
    }

}
