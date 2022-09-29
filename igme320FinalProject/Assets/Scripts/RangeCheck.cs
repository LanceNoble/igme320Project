using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCheck : MonoBehaviour
{
    //fields for easy interaction with player
    [SerializeField] private CircleCollider2D objCollider;
    [SerializeField] private BoxCollider2D inRange;
    [SerializeField] private SpriteRenderer buttonRend;
    [SerializeField] private GameObject puzzleSpace;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject timerText;
    private PlayerMovement playerMove;
    //states for the button
    bool objState = false;
    bool clickable = false;
    private void Start()
    {
       playerMove = player.GetComponent<PlayerMovement>();
    }


    // Update is called once per frame
    void Update()
    {
        //determines if the button is in range of the player
        if (objCollider.IsTouching(inRange))
        {
            clickable = true;
        }
        else
        {
            clickable = false;
        }

        //defines the state of the circle, might swap to a state machine to clean code
        if (objState)
        {
            buttonRend.color = Color.green;
            playerMove.enabled = false;
            timer.SetActive(objState);
            timerText.SetActive(objState);
            
        }
        else if (clickable)
        {
            buttonRend.color = Color.yellow;
        }
        else if(!objState)
        {
            buttonRend.color = Color.red;
        }


        //Activates the puzzle according to what button is pressed
        puzzleSpace.SetActive(objState);


    }
    private void OnMouseDown()
    {
        //swaps state on click
      if(clickable)
        {
            objState = true;
        }
    }
}
