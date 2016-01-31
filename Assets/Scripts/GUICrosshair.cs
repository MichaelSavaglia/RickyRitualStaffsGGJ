using UnityEngine;
using System.Collections;

public class GUICrosshair : MonoBehaviour {

    public Texture2D crosshairTexture;
    Rect position;

    public bool crosshairVisible = true;
    public bool cursorVisible = true;

	// Use this for initialization
	void Start () {
        position = new Rect((Screen.width - crosshairTexture.width) / 2, 
                            (Screen.height - crosshairTexture.height) / 2, 
                            crosshairTexture.width, 
                            crosshairTexture.height);

        Cursor.visible = cursorVisible;
	}
	
	// Update is called once per frame
	void OnGUI () {

        if (crosshairVisible == true)
        {
            GUI.DrawTexture(position, crosshairTexture);
        }
	}

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            Cursor.visible = !Cursor.visible;
        }
    }
}
