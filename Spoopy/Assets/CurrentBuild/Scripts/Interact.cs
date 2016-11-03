using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

    public float range;
    int interactionLayer;
    Ray ray;
    RaycastHit hit;
    public GameObject target;
    
	void Start()
    {
        range = 10;
        interactionLayer = 8;
    }
	// Update is called once per frame
	void FixedUpdate ()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out hit, range);

        target = hit.transform.gameObject;
        
    }
}
