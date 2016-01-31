using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class PCRitual : MonoBehaviour, Ritual
{
    public Camera RitualCamera;
    GameObject ReplacementObject;
    bool activeRitual = false;
    string Name = "keyboard";
    public AudioSource SoundFX;

    public string password;

    public GameObject inputFieldObj;
    private InputField inputField;

    public string inputString;

    bool initRitual;
    public bool passwordCorrect;
    private bool passwordEntered;

    // Use this for initialization
    void Start()
    {
        initRitual = false;
        passwordCorrect = false;
        passwordEntered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeRitual)
        {
            inputFieldObj.SetActive(true);
            inputField = inputFieldObj.GetComponent<InputField>();
            inputField.Select();
            inputField.ActivateInputField();

            if (initRitual == false)
            {
                initRitual = true;
                inputField.text = "Enter Password; ";
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (passwordEntered == false)
                {
                    passwordEntered = true;
                    if (inputField.text.CompareTo(password) == 0)
                    {
                        passwordCorrect = true;
                        inputField.text = "password correct\nplease right click";
                    }
                    else
                    {
                        passwordCorrect = false;
                        inputField.text = "password incorrect";
                        Application.LoadLevel("level");
                    }
                }
                else
                {
                    inputField.text = DoComputerStuff(inputField.text);
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                inputFieldObj.SetActive(false);
                activeRitual = false;
                Debug.Log("PC Ritual");
            }
        }
        

    }


    void OnGUI()
    {
        if (activeRitual)
        {
            //GUIStyle style = new GUIStyle();
            //style.fontSize = 20;
            //style.normal.textColor = Color.white;
            //style.alignment = TextAnchor.UpperLeft;

            //float labelWidth = 100;
            ////float labelHeight = 40;
            //float labelX = (Screen.width / 2) - (labelWidth / 2);
            //float labelY = (Screen.height / 2);

            //inputString = GUI.TextField(new Rect(labelX, labelY, labelWidth, 100), inputString, 25, style);
        }
    }



    public Camera GetRitualCamera()
    {
        return RitualCamera;
    }
    public GameObject GetReplacementObject()
    {
        return ReplacementObject;
    }
    public void ActivateRitual()
    {
        SoundFX.Play();
        activeRitual = true;
    }
    public string GetName()
    {
        return Name;
    }
    public bool IsActiveRitual()
    {
        return activeRitual;
    }

    string DoComputerStuff(string input)
    {
        if (input.CompareTo("Hi") == 0) { return "Hello"; }
        if (input.CompareTo("Whats up?") == 0) { return "Not much, just gamejam stuff"; }
        if (input.CompareTo("What is the ritual?") == 0) { return "Not saying! :O"; }
        if (input.CompareTo(":(") == 0) { return ":)"; }
        return "";
    }
}
