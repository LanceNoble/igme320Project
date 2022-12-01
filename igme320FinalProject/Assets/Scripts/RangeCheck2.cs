using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCheck2 : MonoBehaviour
{
    //fields for easy interaction with player
    [SerializeField] private CircleCollider2D objCollider;
    [SerializeField] private BoxCollider2D inRange;
    [SerializeField] private SpriteRenderer buttonRend;
    [SerializeField] private GameObject puzzleSpace;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject timerText;
    [SerializeField] private DialogueManager dialogueManager;
    private PlayerMovement playerMove;
    //states for the button
    bool objState = false;
    bool clickable = false;
    public int clickState = 0;
    private bool oneUseBool = true;
    private void Start()
    {
        playerMove = player.GetComponent<PlayerMovement>();
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp("e"))
        {
            OnMouseDown();
        }


        //determines if the button is in range of the player
        if (objCollider.IsTouching(inRange) && dialogueManager.canClick)
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
            clickState = 2;
            buttonRend.color = Color.green;
            oneUseBool = false;

        }
        else if (clickable)
        {
            buttonRend.color = Color.yellow;
        }
        else if (!objState)
        {
            buttonRend.color = Color.red;
        }

       
     

    }
    private void OnMouseDown()
    {
        //swaps state on click
        if (clickable)
        {
            objState = true;
        }
    }
}
