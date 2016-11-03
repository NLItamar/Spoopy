using UnityEngine;
using System.Collections;

public class waterTapScript : MonoBehaviour {
    /* 
    Put this on the Sink prefab.
    Turns the mesh renderer on and off with boolean.
    slimeStream is the "Stream"Part of the sink model/prefab.
    Stream part should have the animatedTiledTexture on it.
    */
    public bool isTurnedOn;

    public GameObject slimeStream;
    private Renderer myRenderer;

    void Start ()
    {
        isTurnedOn = false;
        myRenderer = slimeStream.GetComponent<Renderer>();
    }
	


	void Update ()
    {
        runTheTap(isTurnedOn);
	}



    public void runTheTap(bool state)
    {
        if(state == false)
        {
            myRenderer.enabled = false;

        }
        if (state == true)
        {
            myRenderer.enabled = true;

        }

    }
}
