using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2WinCheck : MonoBehaviour
{
    GameObject[] puzPieces;
    string pieceText = "puz2_";
    bool puzSolved = true;
    public bool puzFin = false;
    [SerializeField] RangeCheck3 winCheck;
    void Start()
    {
        puzPieces = new GameObject[12];
        for(int i = 0; i < puzPieces.Length; i ++)
        {
            int currentNum = i + 1;
            string currentPiece = pieceText + currentNum;
            puzPieces[i] = GameObject.Find(currentPiece);
        }
    }

    // Update is called once per frame
    void Update()
    {
        puzSolved = true;
        for (int i = 0; i < puzPieces.Length; i++)
        {
           Collider2D currentPuz = puzPieces[i].GetComponent<Collider2D>();
            if (currentPuz.enabled)
            {
                puzSolved = false;
               
            }
        }

        if (puzSolved)
        {
            GameObject.Find("Puzzle2").SetActive(false);
            PlayerMovement playerMove = GameObject.Find("Player").GetComponent<PlayerMovement>();
            playerMove.enabled = true;
            winCheck.puz2Fin = true;
            puzFin = true;
        }
    }
}
