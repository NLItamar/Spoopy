using UnityEngine;
using System.Collections;

public class InteractionToilet : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (player.GetComponent<InteractionRayCast>().item == "Toilet")
        {
            player.GetComponent<InteractionRayCast>();
        }
	}
}
