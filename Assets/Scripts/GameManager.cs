using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    static int NUM_RITUALS = 5;
    Queue<Ritual> ritualQueue;
    public GameObject[] ritualObjects = new GameObject[NUM_RITUALS];
    public Camera FirstPersonCamera;
    public Camera introCamera;
    public GameObject firstPersonCharacter;
    public Image Image;
    FadeSceneScript fadeScript;
    ObjectPicker PickerScript;
    bool swapRitual = false;
    GameObject CurretRitualObject;
    public Timer timerScript;
    bool inRitual = false;

    // Use this for initialization
    void Start () {
        ritualQueue = new Queue<Ritual>();
        for(int i = 0; i < NUM_RITUALS; i++)
        {
            ritualQueue.Enqueue(ritualObjects[i].GetComponent<Ritual>());
        }
        fadeScript = Image.GetComponent<FadeSceneScript>();
        //PickerScript = FirstPersonCamera.GetComponentInParent<ObjectPicker>();
        PickerScript = firstPersonCharacter.GetComponent<ObjectPicker>();
        firstPersonCharacter.SetActive( false);
        timerScript.enabled = true;
        Camera.SetupCurrent(introCamera);
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(ritualQueue.Count);
        if (ritualQueue.Count > 0)
        {
            Ritual topRitual = ritualQueue.Peek();
            if (!inRitual && PickerScript._selectedObject != null && Input.GetMouseButtonDown(0))
            {
                //Debug.Log(PickerScript._selectedObject.name);
               // Debug.Log(topRitual.GetName());
                if (PickerScript._selectedObject.name == topRitual.GetName())
                {
                    fadeScript.SetFadeUp(true);
                    swapRitual = true;
                    CurretRitualObject = PickerScript._selectedObject;
                    
                    ritualQueue.Dequeue();
                    inRitual = true;
                }
                else 
                {
                    ResetGame();
                }
            }
            SwapRitual();
            CheckRitualExits();
        }
        else
        {
            if(CurretRitualObject.name == "door")
            {
                Cursor.visible = true;
                CurretRitualObject.GetComponent<Ritual>().ActivateRitual();
                Application.LoadLevel("Game Over");
            }
        }

    }

    void CheckRitualExits()
    {
        if (CurretRitualObject != null)
        {
            if (!swapRitual && !CurretRitualObject.GetComponent<Ritual>().IsActiveRitual())
            {
                FirstPersonCamera.enabled = true;
                firstPersonCharacter.SetActive(true);
                CurretRitualObject.GetComponent<Ritual>().GetRitualCamera().enabled = false;
                inRitual = false;
            }
        }
    }
    void SwapRitual()
    {
        if (swapRitual && fadeScript.HasFadedOut() == true)
        {
            FirstPersonCamera.enabled = false;
            firstPersonCharacter.SetActive(false);
            CurretRitualObject.GetComponent<Ritual>().GetRitualCamera().enabled = true;
            CurretRitualObject.GetComponent<Ritual>().ActivateRitual();
            fadeScript.SetFadeUp(false);
            swapRitual = false;
            
        }
    }
    void ResetGame()
    {
        Application.LoadLevel("level");
    }
}
