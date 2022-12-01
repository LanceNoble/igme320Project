using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public GameObject manager;
    public GameObject outline;
    [SerializeField] BoxCollider2D objCollider;
    [SerializeField] BoxCollider2D inRange;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] GameObject puzTwo;
    [SerializeField] GameObject puzThree;
    bool lightsOn = false;
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
            sprite.color = Color.red;
        }
        if (Input.GetKeyUp("e"))
        {
            OnMouseDown();
        }
        if (objCollider.IsTouching(inRange))
        {
            sprite.color = Color.yellow;
        }
        if(lightsOn)
        {
            sprite.color = Color.yellow;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("flipped");
        if (manager.GetComponent<GameManager>().flippable && objCollider.IsTouching(inRange))
        {
            manager.GetComponent<GameManager>().state = GameManager.StateType.LIGHTSON;
            puzTwo.SetActive(true);
            puzThree.SetActive(true);
            lightsOn = true;
        }
    }
}
