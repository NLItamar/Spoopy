using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    
    public Canvas QuitMenu; /*
    public Button Play;
    public Button Controls;

    public Button Exit; 
    public Button Credits;
    public Button Exit; */


	void Start ()
    {
        QuitMenu.GetComponent<Canvas>(); /*
        Play.GetComponent<Button>();
        Controls.GetComponent<Button>();
        Exit.GetComponent<Button>(); */
        QuitMenu.enabled = false; 

        //Credits.GetComponent<Button>();
        //Exit.GetComponent<Button>();
        QuitMenu.enabled = false;
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ExitPressed()
    {
        QuitMenu.enabled = true; /*
        Play.enabled = false;
        Controls.enabled = false;

        Exit.enabled = false; */

        //Credits.enabled = false;
        //Exit.enabled = false;

    }

    public void NoPressed()
    {
        QuitMenu.enabled = false; /*
        Play.enabled = true;
        Controls.enabled = true;

        Exit.enabled = true; */

        //Credits.enabled = true;
        //Exit.enabled = true;

    }

    public void ExitGame()
    {
        Debug.Log("pressed");
        Application.Quit();
    }

    
}
