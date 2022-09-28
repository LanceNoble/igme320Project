using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBond : MonoBehaviour
{
    public GameObject knot;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(knot, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
