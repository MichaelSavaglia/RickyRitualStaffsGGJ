using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;


public class Timer : MonoBehaviour
{
    public Light outSideLight;
    public Text timeTxt;
    public AudioSource radio;
    public FadeAudioScript fadeAudio;
    public FadeSceneScript fadeScene;
    public Animator introCamAnim;

    bool sunDown;
    bool sunrise;

    public Camera introCam;
    public GameObject player;

    public int startingMin;
    public int startingHour;

    float currentTime;
    string state;
    DateTime date;

    bool startFade;


    // Use this for initialization
    void Start()
    {
        date = new DateTime(2005, 7, 20, 7, 40, 0);
        outSideLight.intensity = 1.6f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (date.Hour == 20)
        {
            fadeScene.SetFadeUp(true);
            fadeAudio.SetFadeUp(true);

            if (date.Hour == 20 && date.Minute == 5)
            {
                date = new DateTime(2005, 7, 20, 7, 40, 0);
                radio.Stop();
            }
        }

        if (startFade && introCamAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            Debug.Log("lol");
            introCam.enabled = false;
            player.SetActive(true);
        }

        if (date.Hour <= 7 && date.Minute >= 45 && !startFade)
        {
            startFade = true;
            //Debug.Log("AAAAAAA");
            fadeScene.fadingImg.color = new Color(0, 0, 0, 1);
            fadeScene.SetFadeUp(false);
            introCamAnim.enabled = true;
        }
        if (date.Hour == 7 && date.Minute >= 42 && !radio.isPlaying)
        {
            radio.Play();
        }
        if (date.Hour <= 15)
        {
            sunrise = true;
            sunDown = false;
        }
        if (date.Hour >= 16)
        {
            sunrise = false;
            sunDown = true;
        }

        if (currentTime > 0.5)
        {
            currentTime = 0;
            date = date.AddSeconds(72);

            if (outSideLight.intensity <= 4.3 && sunrise)
            {
                outSideLight.intensity += 0.01f;
            }
            if (outSideLight.intensity >= 1.6 && sunDown)
            {
                outSideLight.intensity -= 0.01f;
            }

        }
        if (date.Hour < 12)
        {
            state = " am";
        }
        else
        {
            state = " pm";
        }

        if (date.Hour < 10)
        {
            if (date.Minute < 10)
                timeTxt.text = "0" + date.Hour + " : " + "0" + date.Minute + state;
            else
                timeTxt.text = "0" + date.Hour + " : " + date.Minute + state;
        }
        else
        {
            if (date.Minute < 10)
                timeTxt.text = date.Hour + " : " + "0" + date.Minute + state;
            else
                timeTxt.text = date.Hour + " : " + date.Minute + state;
        }
    }
}