using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerTextManager : MonoBehaviour
{
    [SerializeField] private GameObject timer;
    [SerializeField] private TextMeshProUGUI textDisplay;

    // Update is called once per frame
    void Update()
    {
        float timeText = timer.GetComponent<TimerScript>().timeLeft;

        timeText = Mathf.FloorToInt(timeText);

        textDisplay.text = timeText.ToString();
    }
}
