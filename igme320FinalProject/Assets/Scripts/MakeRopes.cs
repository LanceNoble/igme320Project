using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeRopes : MonoBehaviour
{
    public GameObject rope;
    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> ropes = new List<GameObject>();
        for (int i = 0; i < 6; i++)
        {
            //must account for ropes being spawned at the same angle, run the rng again so they get spawned at a more unique angle
            //create some sort of visual for ordering system, maybe start with colors?
            //make the ropes move when clicked on in the right order
            //GameObject rope = Instantiate(this.rope, gameObject.transform.position, Quaternion.identity);
            //float rng = Random.Range(0.0f, 2 * Mathf.PI);
            float rng = UnityEngine.Random.Range(0.0f, 360.0f);
            GameObject rope = Instantiate(this.rope, new Vector3(Mathf.Cos(Mathf.Deg2Rad * rng), Mathf.Sin(Mathf.Deg2Rad * rng), 0.0f), Quaternion.identity);
            //rope.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), Random.Range(0.0f, 360.0f));
            rope.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), rng);
            rope.transform.position *= (rope.transform.localScale.x / 2);
            rope.transform.SetParent(gameObject.transform);
            //rope.transform.position = new Vector3(rope.transform.position.x, rope.transform.position.y, 5.0f);
            rope.GetComponent<SpriteRenderer>().sortingOrder = -1;
            ropes.Add(rope);
        }
        for(int i = 0; i < 6; i++)
        {
            ropes[i].name = $"rope{i}";
        }
        foreach(GameObject rope in ropes)
        {
            //rope.GetComponent<MeshRenderer>().material.SetColor("bruh", Int32.Parse(rope.name.Substring(4, 1)));
            rope.GetComponent<SpriteRenderer>().material.color = new Color(1, 0, 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
