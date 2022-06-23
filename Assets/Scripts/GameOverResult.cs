using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverResult : MonoBehaviour
{
    public Text SurvivedTime;
    void Start()
    {
        SurvivedTime.text = "You survived\n" + Timer.instance.timeString;
    }
}
