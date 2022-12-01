using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

// MUST FIX BUG WHERE CLICKING CENTER OF KNOT WILL RELEASE ALL THE ROPES AT ONCE
// MUST FIX KNOT SHRINKING TOO SMALL WITH MISCLICKS

public class Untie : MonoBehaviour
{
    bool loosen;
    public GameObject knot;
    public List<GameObject> ropes;
    [SerializeField] GameObject timer;
    public GameObject gm;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gm = GameObject.Find("gameStateManager");
        knot = GameObject.Find("knot(Clone)");
        timer = GameObject.Find("Timer");
        ropes = knot.GetComponent<MakeRopes>().ropes;
        loosen = false;
        gameObject.GetComponent<SpriteRenderer>().material.color = new Color(float.Parse(gameObject.name.Substring(4, 1)), 0, 0, 1);
        int number = int.Parse(gameObject.name.Substring(4, 1));
        Color ogColor = gameObject.GetComponent<SpriteRenderer>().material.color;
        switch (number)
        {
            case 0:
                ogColor = gameObject.GetComponent<SpriteRenderer>().material.color;
                gameObject.GetComponent<SpriteRenderer>().material.color = Color.Lerp(ogColor, Color.white, 1.0f);
                break;

            case 1:
                ogColor = gameObject.GetComponent<SpriteRenderer>().material.color;
                gameObject.GetComponent<SpriteRenderer>().material.color = Color.Lerp(ogColor, Color.black, .25f);
                break;

            case 2:
                ogColor = gameObject.GetComponent<SpriteRenderer>().material.color;
                gameObject.GetComponent<SpriteRenderer>().material.color = Color.Lerp(ogColor, Color.black, .75f);
                break;

            case 3:
                ogColor = gameObject.GetComponent<SpriteRenderer>().material.color;
                gameObject.GetComponent<SpriteRenderer>().material.color = Color.Lerp(ogColor, Color.black, 1.0f);
                break;

            //case 4:
            //    gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
            //    break;
            //
            //case 5:
            //    gameObject.GetComponent<SpriteRenderer>().material.color = Color.black;
            //    break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (loosen)
        {
            transform.Translate(new Vector3(5.0f, 0, 0) * Time.deltaTime);
        }

        
        if (ropes.Count == 0)
        {
            GameObject.Find("PuzzleSpace1").SetActive(false);
            GameObject.Find("TimerText").SetActive(false);
            timer.GetComponent<TimerScript>().timeLeft = 20f;
            timer.SetActive(false);
            PlayerMovement playerMove = GameObject.Find("Player").GetComponent<PlayerMovement>();
            playerMove.enabled = true;

            gm.GetComponent<GameManager>().flippable = true;
            //player.GetComponent<SpriteRenderer>().sprite = 
            player.GetComponent<SpriteRenderer>().sortingOrder = 3;
        }
        /*// if left mouse button is down
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clicked");
            // check if mouse is over object

            
        }

        //struct used to get information back from a raycast
        RaycastHit hit;

        //returns a ray going from camera to mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Physics.Raycast returns bool saying whether or not ray intersects with collider
        //  casts a ray from point origin, in direction of direction parameter, of length maxdistance parameter, against all colliders in scene
        //  out keyword: used to pass arguments to methods as a reference type, generally used when a method needs to return multiple values
        //  in this case, we want the function to return not just the bool but also the hit since we haven't initialized it yet
        //  thanks to "out" the hit variable gets initialized for us by function without us having to do anything
        //  There is a way to implement this in 2D with Physics2D.Raycast, but idk how to so i'm sticking with raycasting in 3d
        if (Physics.Raycast(ray, out hit))
        {
            // hit variable contains information about the object that our ray (Camera.main.ScreenPointToRay(Input.mousePosition);) just hit
            //if (hit.transform.name == "rightRope")
            //{
            //    Debug.Log("You hit: " + hit.collider.gameObject);
            //}
            Debug.Log(hit.transform.name);
        }*/

    }

    private void OnMouseDown()
    {
        if (gameObject == ropes[ropes.Count - 1])
        {
            Vector3 scale = knot.transform.localScale;
            knot.transform.localScale = new Vector3(scale.x + .1f, scale.y + .1f, scale.z + .1f);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            loosen = true;
            ropes.RemoveAt(ropes.Count - 1);
        }
        else
        {
            Vector3 scale = knot.transform.localScale;
            knot.transform.localScale = new Vector3(scale.x - .1f, scale.y - .1f, scale.z - .1f);
        }
    }
}
