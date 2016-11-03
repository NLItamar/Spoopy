using UnityEngine;
using System.Collections;

public class CreditsAudio : MonoBehaviour {

    public AudioClip CreditAudio;
    // Update is called once per frame
    void Start()
    {
        AudioSource.PlayClipAtPoint(CreditAudio, this.transform.position);
    }

    void Update ()
    {
        this.transform.position = Camera.main.transform.position;

        if (Application.loadedLevelName.Contains("Marc"))
        {
            Destroy(this.gameObject);
        }
    }
}
