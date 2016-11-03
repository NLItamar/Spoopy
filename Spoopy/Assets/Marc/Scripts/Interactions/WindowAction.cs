using UnityEngine;
using System.Collections;

public class WindowAction : MonoBehaviour
{

    // Use this for initialization
    public float Rotation = 90;
    public int RepeatAmount = 12;
    public AudioSource audio;
    public AudioClip window;
    public bool activated = false;
    public IEnumerator timer()
    {
        if (!activated)
        {
            for (int i = 0; i < 11; i++)
            {
                //code for turning window
                
                if (isOdd(i))
                {
                    transform.Rotate(new Vector3(0, 90, 0));
                }
                else
                {
                    transform.Rotate(new Vector3(0, -90, 0));
                }
                audio.PlayOneShot(window);
                yield return new WaitForSeconds(0.2f);
                
            }
            activated = true;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //add code that turns activated to false and rotates -90 on Y-Axis when AI shuts window
    }

    public static bool isOdd(int num)
    {
        return num % 2 == 0;
    }

}
