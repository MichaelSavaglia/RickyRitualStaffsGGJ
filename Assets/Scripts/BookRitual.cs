using UnityEngine;
using System.Collections;


public class BookRitual : MonoBehaviour, Ritual
{
    public Camera RitualCamera;
    public GameObject ReplacementObject;
    bool activeRitual = false;
    string Name = "diary";
    public AudioSource soundFX;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (activeRitual)
        {
            if (Input.GetMouseButtonDown(1))
            {
                activeRitual = false;
                GetComponent<MeshRenderer>().enabled = true;
                ReplacementObject.SetActive(false);
            }
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
        GetComponent<MeshRenderer>().enabled = false;
        ReplacementObject.SetActive(true);
        soundFX.Play();
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
}
