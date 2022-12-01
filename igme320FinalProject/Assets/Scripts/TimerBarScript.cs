using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerBarScript : MonoBehaviour
{
    public Image timeBar;
    float totalTime = 180.0f;
    [SerializeField] private GameObject timer;

    // Update is called once per frame
    void Update()
    {
        float timeleft = timer.GetComponent<TimerScript>().timeLeft;
        
        timeBar.fillAmount = timeleft / totalTime;

        timeBar.color = Color.green;
        if(timeBar.fillAmount < .5f)
        {
            timeBar.color = Color.yellow;
        }

        if (timeBar.fillAmount < .25f)
        {
            timeBar.color = Color.red;
        }
    }
}
