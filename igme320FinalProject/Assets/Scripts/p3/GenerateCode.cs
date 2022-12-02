using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateCode : MonoBehaviour
{
   
    GameObject[] combo = new GameObject[3];
    public GameObject[] codePieces = new GameObject[8];
    //public GameObject keyboard;
    //Transform[] glyphs = new Transform[12];
    [SerializeField] GameObject puzThree;
    public bool puzFin = false;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < combo.Length; i++)
        {
            GameObject thing = Instantiate(codePieces[Random.Range(0, 8)]);
            thing.GetComponent<SpriteRenderer>().sortingOrder = 2;
            thing.transform.parent = gameObject.transform;
            thing.transform.localScale = new Vector3(0.08333334f * 3, 0.125f * 3, 1.0f);
            //thing.transform.localPosition = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y / 2, 1.0f);
            combo[i] = thing;
        }


        combo[0].transform.localPosition = new Vector3(-0.325f, 0, -3);
        combo[1].transform.localPosition = new Vector3(0, 0, -3);
        combo[2].transform.localPosition = new Vector3(0.325f, 0, -3);
      
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < combo.Length; i++)
        {
            if (!combo[i].IsDestroyed())
            {
                puzFin = false;
                break;
            }
            else
            {
                puzFin = true;
            }
        }
        if (puzFin)
        {
            puzThree.SetActive(false);
        }
    }
}
