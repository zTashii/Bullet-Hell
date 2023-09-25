using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeManager : MonoBehaviour
{

    public TextMeshProUGUI timeText;

    private void Awake()
    {
        int minutes = Mathf.FloorToInt(Timer.elapsedTime / 60);
        int seconds = Mathf.FloorToInt(Timer.elapsedTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
