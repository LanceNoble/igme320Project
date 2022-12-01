using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public GameObject manager;
    public GameObject outline;
    [SerializeField] GameObject puzTwo;
    [SerializeField] GameObject puzThree;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.GetComponent<GameManager>().flippable)
        {
            outline.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("flipped");
        if (manager.GetComponent<GameManager>().flippable == true)
        {
            manager.GetComponent<GameManager>().state = GameManager.StateType.LIGHTSON;
            puzTwo.SetActive(true);
            puzThree.SetActive(true);
        }
    }
}
