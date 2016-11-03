using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlsScript : MonoBehaviour {

	// Update is called once per frame
	void Update () {
	
	}

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
