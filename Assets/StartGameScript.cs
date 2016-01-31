using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StartGameScript : MonoBehaviour {

    public Text infoText, creditText;
    bool showingHelp, showingCredits;

	// Use this for initialization
	void Start () {
        infoText.enabled = false;
        creditText.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        Application.LoadLevel("Level");
    }

    public void Help()
    {
        showingHelp = !showingHelp;
        Debug.Log("sdfsdfsd");
        if (showingHelp)
        {
            infoText.enabled = true;
            creditText.enabled = false;
        }
        else
        {
            infoText.enabled = false;
        }
    }

    public void Credits()
    {
        showingCredits = !showingCredits;

        if (showingCredits)
        {
            creditText.enabled = true;
            infoText.enabled = false;
        }
        else
        {
            creditText.enabled = false;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
