using UnityEngine;
using System.Collections;

public class InteractionRayCast : MonoBehaviour {

    public Camera camera;
    public int interactionTriggerDistance;
    public bool activated;
    public string item;
    public float interactiontimer, interactionTime = 1;
    private GameObject itemObj;

    public AudioSource audio;
    public AudioClip clipToilet, clipWindow;

	// Use this for initialization
	void Start ()
    {
        activated = false;
        interactionTriggerDistance = 2;
        interactiontimer = interactionTime;

    }
	
	// Update is called once per frame
	void Update ()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 3;
        Ray ray = camera.ScreenPointToRay(forward);
        Debug.DrawRay(transform.position, forward, Color.green);

        if(Physics.Raycast(transform.position, forward, out hit))
        {
            //Debug.Log(hit.collider.gameObject.name);
            if (hit.transform.tag == "Interaction" && hit.distance <= interactionTriggerDistance && Input.GetMouseButtonDown(0) && !activated)
            {
                activated = true;
                item = hit.collider.gameObject.name;
                itemObj = hit.collider.gameObject;
            }
        }

        InteractionTimer();
        HandleInteraction();
        
    }

    void InteractionTimer()
    {
        if (activated)
        {
            interactiontimer -= 1 * Time.deltaTime;
        }
        if(interactiontimer <= 0)
        {
            activated = false;
            interactiontimer = interactionTime;
        }
    }

    private void HandleInteraction()
    {   
        switch(item)
        {
            case "Toilet":
                audio.PlayOneShot(clipToilet);
                break;

            case "Window":
                Debug.Log(itemObj.transform.parent);
                StartCoroutine(itemObj.transform.parent.GetComponent<WindowAction>().timer());
                break;
        }

        item = null;
    }
}
