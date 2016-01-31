using UnityEngine;
using System.Collections;

public class FadeAudioScript : MonoBehaviour
{
    public AudioSource radioNews;
    public float fadeSpeed;
    public float maxVolume;
    bool fadingUp;
    bool isFading;

    // Use this for initialization
    void Start()
    {
        isFading = false;
        fadingUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFading)
        {
            if (fadingUp)
            {
                if (radioNews.volume > 0)
                    radioNews.volume -= fadeSpeed;
                else
                    isFading = false;
            }
            else
            {
                if (radioNews.volume <= maxVolume)
                    radioNews.volume += fadeSpeed;
                else
                    isFading = false;
            }
        }
    }

    public void SetFadeUp(bool fadeUp)
    {
        isFading = true;
        fadingUp = fadeUp;
    }
}
