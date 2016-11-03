using UnityEngine;
using System.Collections;

public class HeaderScript : MonoBehaviour {

    public float timer = 10f;

    public void scaling(float scaleValue, float scalingDuration)
    {
        Vector3 newScale = new Vector3(scaleValue, scaleValue, scaleValue);
        float scaleStep = Time.deltaTime / scalingDuration;
        transform.localScale = Vector3.Lerp(transform.localScale, newScale, scaleStep);
    }

    void Update ()
    {
        if (Input.anyKey)
        {
            Application.Quit();
        }

        timer -= Time.deltaTime;
        scaling(0.1f, 5);
        if(timer >= 0)
        {
            transform.Translate(0, 0, 0.02f);
        }
        else if (timer <= -5)
        {
            Destroy(this.gameObject);
        }
        else
        {
            transform.Translate(0, 0, 5);
        }
	}
}
