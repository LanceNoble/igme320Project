using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MakeRopes : MonoBehaviour
{
    public GameObject rope;
    public int ropeAm;
    List<GameObject> ropes;
    bool loosen;
    // Start is called before the first frame update
    void Start()
    {
        ropes = new List<GameObject>();
        for (int i = 0; i < ropeAm; i++)
        {
            GameObject rope = Instantiate(this.rope, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            float rngAng = UnityEngine.Random.Range(0.0f, 360.0f);
           
            for (int j = 0; j < ropes.Count; j++)
            {
               
                if (rngAng <= ropes[j].transform.rotation.eulerAngles.z + 20.0f && rngAng >= ropes[j].transform.eulerAngles.z - 20.0f)
                {
                    rngAng = UnityEngine.Random.Range(0.0f, 360.0f);
                    j = 0;
                }
            }
            
            rope.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), rngAng);
            Vector3 ropePos = new Vector3(Mathf.Cos(Mathf.Deg2Rad * rngAng), Mathf.Sin(Mathf.Deg2Rad * rngAng), 0.0f);
           
            rope.transform.position = ropePos;
            
            rope.transform.position *= (rope.transform.localScale.x / 2);
            rope.transform.SetParent(gameObject.transform);
            
            rope.GetComponent<SpriteRenderer>().sortingOrder = -1;
            ropes.Add(rope);
        }
        for(int i = 0; i < 6; i++)
        {
            ropes[i].name = $"rope{i}";
        }
        //foreach(GameObject rope in ropes)
        //{
        //    
        //    rope.GetComponent<SpriteRenderer>().material.color = new Color(1, 0, 1, 1);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (loosen)
        {
            foreach (GameObject rope in ropes)
            {
                rope.transform.Translate(new Vector3(5.0f, 0, 0) * Time.deltaTime);
            }
        }
    }

    //private void OnMouseDown()
    //{
    //    loosen = true;
    //    
    //}
}
