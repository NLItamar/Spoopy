using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    public float timer;
    public AudioClip lightning;
    public Random rand = new Random();

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        timer = 5;
	}
	
	// Update is called once per frame
	void Update () {
        
        this.transform.position = Camera.main.transform.position;

        if(timer <= 0)
        {
            timer = Random.Range(5, 15);
            AudioSource.PlayClipAtPoint(lightning, this.transform.position);
        }
        else
        {
            timer -= Time.deltaTime;
        }

        if (Application.loadedLevelName.Contains("Credits"))
        {
            Destroy(this.gameObject);
        }
	}
}
