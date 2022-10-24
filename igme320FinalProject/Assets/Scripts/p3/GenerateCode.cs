using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateCode : MonoBehaviour
{
    //public GameObject keyboard;
    //Transform[] glyphs = new Transform[12];
    GameObject[] combo = new GameObject[6];
    public GameObject[] codePieces = new GameObject[12];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < combo.Length; i++)
        {
            GameObject thing = Instantiate(codePieces[Random.Range(0, 12)]);
            thing.transform.parent = gameObject.transform;
            thing.transform.localScale = new Vector3(0.08333334f, 0.125f, 1.0f);
            combo[i] = thing;
            //Debug.Log(combo.Length);
        }


        //thing.transform.position = new Vector3()-3;
        //Instantiate(thing);
        combo[0].transform.localPosition = new Vector3(-0.325f, 0.25f, -3);
        combo[1].transform.localPosition = new Vector3(0, 0.25f, -3);
        combo[2].transform.localPosition = new Vector3(0.325f, 0.25f, -3);
        combo[3].transform.localPosition = new Vector3(-0.325f, -0.25f, -3);
        combo[4].transform.localPosition = new Vector3(0, -0.25f, -3);
        combo[5].transform.localPosition = new Vector3(0.325f, -0.25f, -3);

        /*for (int i = 0; i < 12; i++)
        {
            //glyphs[i] = keyboard.transform.GetChild(i);
        }
        for (int i = 0; i < 6; i++)
        {
            //codePieces[i].
            Transform thing = Instantiate(glyphs[Random.Range(0, 12)]);
            thing.parent = gameObject.transform;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
