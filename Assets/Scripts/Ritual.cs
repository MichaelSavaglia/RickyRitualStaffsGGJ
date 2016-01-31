using UnityEngine;
using System.Collections;

public interface Ritual
{
    Camera GetRitualCamera();
    GameObject GetReplacementObject();
    void ActivateRitual();
    string GetName();
    bool IsActiveRitual();
}
