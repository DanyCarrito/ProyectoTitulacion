using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float minTime = 0f;

    public TextMeshProUGUI timerText;
    public float timer;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        int displayTimer = Mathf.Max(0, Mathf.FloorToInt(timer));
        timerText.text = displayTimer.ToString();

        if (timer <= minTime)
        {
            PanelManager.Instance.win();
            if(player != null)
            {
                player.SetActive(false);
            }
        }
    }

    public void TimePenalty()
    {
        Debug.Log("penalty");
        //timer--;
    }
}
