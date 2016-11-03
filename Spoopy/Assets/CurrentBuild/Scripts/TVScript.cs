using UnityEngine;
using System.Collections;

public class TVScript : MonoBehaviour {

    /* 
    Should be places on the TV prefab/model group.
    Turns the meshrenderer on and off.
    staticScreen is the "StaticScreen" Part of the sink model/prefab.
    StaticScreen should have the animatedTiledTexture on it.
    */
    public bool isTurnedOn;

    public GameObject staticScreen;
    private Renderer myRenderer;

    private AudioSource staticSound;

    void Start()
    {
        isTurnedOn = false;
        myRenderer = staticScreen.GetComponent<Renderer>();
        staticSound = GetComponent<AudioSource>();
    }



    void Update()
    {
        TurnOnTv(isTurnedOn);
    }



    public void TurnOnTv(bool state)
    {
        if (state == false)
        {
            myRenderer.enabled = false;
            staticSound.Pause();
        }
        if (state == true)
        {
            myRenderer.enabled = true;
            if (!staticSound.isPlaying)
            {
                staticSound.Play();
            }
        }

    }
}

