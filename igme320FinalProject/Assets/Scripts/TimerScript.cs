using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public float timeLeft = 180.0f;
    [SerializeField] GameObject loseScreen;


    // Update is called once per frame
    void Update()
    {

            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
           
            }
            else
            {
            timeLeft = 0;
            SceneManager.LoadScene("LoseScene");
            Time.timeScale = 0;
            }
        
    }
}
