using UnityEngine;
using System.Collections;


public class PosterRitual : MonoBehaviour, Ritual
{
    public Camera RitualCamera;
    GameObject ReplacementObject;
    bool activeRitual = false;
    string Name = "poster";

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
