using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum StateType 
    {
        LIGHTSON,
        LIGHTSOFF
    }

    public StateType state;
    public GameObject[] gameObjects;
    public GameObject[] lights;
    public bool flippable;

    // Start is called before the first frame update
    void Start()
    {
        state = StateType.LIGHTSOFF;
        flippable = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case StateType.LIGHTSON:
                foreach (GameObject go in gameObjects)
                {
                    go.GetComponent<SpriteRenderer>().material.SetFloat("_dark", 0);
                }
                foreach (GameObject light in lights)
                {
                    light.SetActive(true);
                }
                break;

            case StateType.LIGHTSOFF:
                foreach (GameObject go in gameObjects)
                {
                    go.GetComponent<SpriteRenderer>().material.SetFloat("_dark", 1);
                }
      
                foreach (GameObject light in lights)
                {
                    light.SetActive(false);
                }
                break;
        }

    }
}
