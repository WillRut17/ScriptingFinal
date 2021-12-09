using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    public Text timerText;

    // Update is called once per frame
    void Update()
    {
        CalculateTime(time);

        time += 1 * Time.deltaTime;
    }

    void CalculateTime(float timeToCalculate)
    {
        float minutes = Mathf.FloorToInt(timeToCalculate / 60);
        float seconds = Mathf.FloorToInt(timeToCalculate % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
