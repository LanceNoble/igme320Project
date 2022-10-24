using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeSelected : MonoBehaviour
{
    public bool selected;
    public GameObject screen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            if (screen.transform.GetChild(0).name == $"{gameObject.name}(Clone)")
            {
                Debug.Log("solved!");
                Destroy(screen.transform.GetChild(0).gameObject);
            }
            selected = false;
        }
    }

    private void OnMouseDown()
    {
        selected = true;
        Debug.Log("selected!");
    }
}
