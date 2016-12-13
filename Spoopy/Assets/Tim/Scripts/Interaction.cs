using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Interaction : MonoBehaviour {

    public GameObject fires;

    bool originalForm; // bool to keep track of the current state of the object so you can toggle easily
    
   public void SingleDoorInteraction()
    {
        if (gameObject.GetComponent<SingleDoor>().locked == false)
        {
            if (originalForm)
            {
                gameObject.transform.Rotate(0, -90, 0);

                originalForm = !originalForm;

            }
            else {
                gameObject.transform.Rotate(0, 90, 0);

                originalForm = !originalForm;
            }
        }
    }

    public void SingleDoorLock()
    {
        this.GetComponent<SingleDoor>().activated = true;
    }

    public void SinkInteraction()
    {
        this.GetComponent<waterTapScript>().isTurnedOn = !this.GetComponent<waterTapScript>().isTurnedOn;
    }

    public void TVInteraction()
    {
        this.GetComponent<TVScript>().isTurnedOn = !this.GetComponent<TVScript>().isTurnedOn;
    }

    public void FirePlaceInteraction()
    {
        fires.SetActive(!fires.active);
    }

    public void BookCaseInteraction()
    {
        this.GetComponent<BookCaseScript>().activated = true;
    }

    public void WindowInteraction()
    {
        this.GetComponentInParent<WindowAction>().activated = true;
        //Taunt();
    }

    public void Taunt()
    {
        List<TauntAI> AI = GameObject.FindObjectsOfType<TauntAI>().ToList<TauntAI>();
        foreach (TauntAI TAI in AI)
        {
            if (Vector3.Distance(this.transform.position, TAI.transform.position) <= 40.0f)
            {
                TAI.TriggerInvestigate(this.transform.position);
            }
        }
    }
}
