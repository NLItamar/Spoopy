using UnityEngine;
using System.Collections;

public class spiegelActive : MonoBehaviour {

    public void Break()
    {
        transform.FindChild("SpiegelShards").gameObject.SetActive(true);
        transform.FindChild("SpiegelHeel").gameObject.SetActive(false);
    }

}
