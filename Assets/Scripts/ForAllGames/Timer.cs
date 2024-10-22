using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Timer : MonoBehaviour
{
    public float minTime;
    public TextMeshProUGUI timerText;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        int displayTimer = Mathf.Max(0, Mathf.FloorToInt(timer));
        timerText.text = displayTimer.ToString();

        if (timer <= minTime)
        {
            Time.timeScale = 0f;
        }
    }

    public void TimePenalty()
    {
        Debug.Log("penalty");
        //timer--;
    }
}
