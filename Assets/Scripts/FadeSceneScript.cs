using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FadeSceneScript : MonoBehaviour {

    public Image fadingImg;
    public float fadeSpeed;
    bool fadingIN;
    bool isFading;
    bool fadedOut;
	// Use this for initialization
	void Start () {
        fadingImg = GetComponent<Image>();
        isFading = false;
        fadingIN = false;
        fadedOut = false;

    }
	
	// Update is called once per frame
	void Update () {
       
        if(isFading)
        {
            if(fadingIN)
            {
                // fade out
                if (fadingImg.color.a < 1)
                {
                    fadingImg.color += new Color(fadingImg.color.r, fadingImg.color.g, fadingImg.color.b, Time.deltaTime * fadeSpeed);

                }
                else
                {
                    isFading = false;
                    fadedOut = true;
                }
            }
            else
            {
                // fading in 
                if (fadingImg.color.a > 0)
                {
                    fadingImg.color += new Color(fadingImg.color.r, fadingImg.color.g, fadingImg.color.b, Time.deltaTime * -fadeSpeed);

                }
                else
                {
                    isFading = false;
                    fadedOut = false;

                }
            }
           

        }
        
	}

    public bool HasFadedOut()
    {
        return fadedOut;
    }

    public void SetFadeUp(bool fadeUp)
    {
        isFading = true;
        fadingIN = fadeUp;
    }
}
