using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class residentMovement : MonoBehaviour {

    [HideInInspector] public GameObject[] currentRoomWPs;
    [HideInInspector] public string currentRoom;
    [HideInInspector] public string targetRoom;
    
    /* 
    Add the names of all rooms the resident can roam into roomNames string array.
    Omit rooms the character does NOT roam in.
    A room name can be entered multiple times to make the resident more likely to roam there (a favorited room).
    Each room name must have corresponding Waypoints (empty game objects) with "roomName"+"WP" (example "KitchenWP"). CASE SENSITIVE!!
    */
    public string[] roomNames = new string[] { "Kitchen", "Lobby"  };

    //agent determines destination, speed, stopping distance etc.
    [HideInInspector]public NavMeshAgent agent;
    
    // used for the investigation method
    float searchingTurnSpeed = 120f;
    private float searchDuration = 4f; // time spend searching location before returning to roaming state.
    private float searchTimer = 0;

    // for room alocation
    public float newRoomInterval = 10f; // change to move between rooms faster
    private float newRoomCount = 0f;

    public string currentState;
    public string startingRoom = "Lobby";
   
    Vector3 currentInvestigation;



    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();

        targetRoom = startingRoom;
        currentRoom = "frambozenthee"; // random value making sure start is not the same

        // resident will start in roaming state. 
        currentState = "roaming";
    }
	


	void Update () {
        if (currentState == "roaming")
        {
            roaming();
            randomRoom();
        }
        if(currentState == "investigate")
        {
            investigate(currentInvestigation);
        }
        
    }



    public void roaming()
    {
        currentState = "roaming";
        // first check if the room has changed, if so load Waypoints to the array.
        if (targetRoom != currentRoom)
        {
            currentRoomWPs = GameObject.FindGameObjectsWithTag(targetRoom + "WP");
            currentRoom = targetRoom;
        }
        
        
        Vector3 roamTarget;
        Vector3 oldTarget = new Vector3(10000,0,0); // random value to make sure the start is never the same

        // when the resident gets close to target WayPoint, a new random target that is NOT the same as previous will be chosen.
        if (agent.remainingDistance <= agent.stoppingDistance)
        {      
                roamTarget = currentRoomWPs[Random.Range(0, currentRoomWPs.Length)].transform.position;
                if (agent.destination != oldTarget)
                {
                    agent.SetDestination(roamTarget);
                    oldTarget = roamTarget;
                } 
        }
    }



    //Resident moves to designated location, spins round for few seconds, then continues roaming
    public void investigate(Vector3 targetPosition)
    {
        currentInvestigation = targetPosition;
        currentState = "investigate";
        ResetWindowInteraction();

        agent.SetDestination(targetPosition);
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            this.transform.Rotate(0, searchingTurnSpeed * Time.deltaTime ,0);
            searchTimer += Time.deltaTime;

            if (searchTimer >= searchDuration)
            {
               currentState = "roaming";
               roaming();
                searchTimer = 0f;
            }
        }
    }

    private void ResetWindowInteraction()
    {
        List<WindowAction> windows = GameObject.FindObjectsOfType<WindowAction>().ToList<WindowAction>();
        foreach (WindowAction WA in windows)
        {
            Debug.Log(agent.stoppingDistance);
            if (Vector3.Distance(this.transform.position, WA.transform.position) <= 5)
            {
                WA.AI_Hit = true;
            }
        }
    }

    public void goToTarget(Vector3 targetPosition)
    {
        agent.SetDestination(targetPosition);
    }

    // sets a new random room for roaming on a timed interval.
    public void randomRoom()
    {
        newRoomCount += Time.deltaTime;
        if(newRoomCount >= newRoomInterval)
        {
            targetRoom = roomNames[Random.Range(0, roomNames.Length)];
            newRoomCount = 0f;
        }


    }
}
