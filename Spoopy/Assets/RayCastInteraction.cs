using UnityEngine;
using System.Collections;

public class RayCastInteraction : MonoBehaviour {
    public int range;
	// Use this for initialization
	void Start () {
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp("e") ) { Cursor.visible = true; }
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        // Casts the ray and get the first game object hit
        Physics.Raycast(ray, out hit, range);
        if (Physics.Raycast(ray, out hit, range))
        {
            Debug.Log(hit.collider.gameObject.name);
            Debug.DrawLine(ray.origin, hit.point);


            if (Input.GetMouseButtonUp(0))
            {
                if(hit.collider.gameObject.layer == 12)
                {
                    string temp = hit.collider.gameObject.name + "Interaction";
                    hit.collider.gameObject.GetComponent<Interaction>().Invoke(temp,0);
                }
            }
        }
    }
}
