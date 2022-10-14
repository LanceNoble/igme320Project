using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiece : MonoBehaviour
{
    public bool track;
    public GameObject slot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (track)
       {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0.0f;
            gameObject.transform.position = worldPosition;
       }
    }

    private void OnMouseDown()
    {
        track = true;
    }

    private void OnMouseUp()
    {
        track = false;
        if (gameObject.GetComponent<Collider2D>().OverlapPoint(slot.transform.position))
        {
            gameObject.transform.position = slot.transform.position;
        }
    }
}
