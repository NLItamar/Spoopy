using UnityEngine;
using System.Collections;

public class playerRoom : MonoBehaviour {

    public GameObject lobby;

    Collider lobbyTag;

    public bool lobbyActive;

	// Use this for initialization
	void Start () {
        lobbyTag = lobby.GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void Update () {
        if(lobbyTag)
        {
            lobbyActive = true;
        }
	}

    void OnCollisionEnter(Collision collision)
    {

    }
}
