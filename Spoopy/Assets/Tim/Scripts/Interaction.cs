using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {

    public GameObject fires;
    bool originalForm; // bool to keep track of the current state of the object so you can toggle easily
    
   public void SingleDoorInteraction()
    {
        if (originalForm)
        {
            gameObject.transform.Rotate(0, -90, 0);

            originalForm = !originalForm;

        } else {
            gameObject.transform.Rotate(0, 90, 0);
   
            originalForm = !originalForm;
        }
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
}
