using UnityEngine;
using System.Collections;

public class GUIToolTips : MonoBehaviour {

    private GameObject[] ritualObjects;
    public GameObject fpsController;
    private GameObject selectedObject;

	// Use this for initialization
	void Start () {
        ritualObjects = GetComponent<GameManager>().ritualObjects;
	}
	
	// Update is called once per frame
	void Update () {
        selectedObject = fpsController.GetComponent<ObjectPicker>()._selectedObject;
	}

    void OnGUI()
    {
        if(selectedObject != null)
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 40;
            style.normal.textColor = Color.white;
            style.alignment = TextAnchor.LowerCenter;

            float labelWidth = 100;
            float labelHeight = 40;
            float labelX = (Screen.width / 2) - (labelWidth / 2);
            float labelY = Screen.height - 120;
            GUI.Label(new Rect(labelX, labelY, labelWidth, labelHeight), selectedObject.name, style);
        }
    }
}
