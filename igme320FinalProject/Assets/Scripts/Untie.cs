using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Untie : MonoBehaviour
{
    bool loosen;
    // Start is called before the first frame update
    void Start()
    {
        // determine which direction is loosen and which direction is pull
        //int looseDirection = Random.Range(0, 2);
        loosen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (loosen)
        {
            transform.Translate(new Vector3(1f, 0, 0) * Time.deltaTime);
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
        loosen = true;
    }
}
