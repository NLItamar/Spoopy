using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class MotionBlurPlayer : MonoBehaviour {

    //distance player and exorcist
    public Transform exorcist;
    private float distanceExorcist;
    public float minDistance = 5f;

    //timers until exorcism
    private bool timerOn;
    public float timer = 10f;

    //motionblur;
    public GameObject playerCam;
    MotionBlur motionScript;

    // Use this for initialization
    void Start () {
        distanceExorcist = 1000f;
        Debug.Log(distanceExorcist);
        timerOn = false;
        motionScript = playerCam.GetComponent<MotionBlur>();
    }

    // Update is called once per frame
    void Update () {
        distanceExorcist = Vector3.Distance(playerCam.transform.position, exorcist.position);
        Debug.Log(distanceExorcist);
        if (distanceExorcist <= minDistance && timerOn == false)
        {
            timerOn = true;
            blurr();
        }
        if (distanceExorcist > minDistance)
        {
            timerOn = false;
            motionScript.blurAmount = 0.0f;
        }
    }

    public void blurr()
    {
        if(distanceExorcist > minDistance)
        {
            motionScript.blurAmount = 0f;
        }
        else if (distanceExorcist <= minDistance && distanceExorcist > 4f)
        {
            motionScript.blurAmount = 0.5f;
        }
        else if(distanceExorcist <= 4f && distanceExorcist > 3f)
        {
            motionScript.blurAmount = 1.5f;
        }
        else if(distanceExorcist <= 3f && distanceExorcist > 2f)
        {
            motionScript.blurAmount = 4f;
        }
        else if(distanceExorcist <= 2f && distanceExorcist > 1f)
        {
            motionScript.blurAmount = 6.5f;
        }
        else if(distanceExorcist <= 1f && distanceExorcist > 0f)
        {
            motionScript.blurAmount = 10f;
        }
    }

}
