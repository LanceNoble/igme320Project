using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour
{
    bool held;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (held)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z += 5;
            gameObject.transform.position = mousePos;
            
        }
    }

    private void OnMouseDown()
    {
        held = true;
    }

    private void OnMouseUp()
    {
        held = false;
    }
}
