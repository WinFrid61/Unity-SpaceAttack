using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public Text time;
    private DateTime timeBegin;
    public static Timer instance;
    private TimeSpan timeTimer;
    public string timeString;

    void Start()    
    {
        if (instance == null)
        {
            instance = this;
        }
        timeBegin = DateTime.Now;
    }

    private void Update()
    {
        timeTimer = DateTime.Now - timeBegin;
        timeString = string.Format("{0:D2}:{1:D2}:{2:D2}", timeTimer.Hours, timeTimer.Minutes, timeTimer.Seconds);
        time.text = "Survived:\n" + timeString;
    }
}
