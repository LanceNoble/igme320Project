using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2WinCheck : MonoBehaviour
{
    GameObject[] puzPieces;
    string pieceText = "puz2_";
    bool puzSolved = true;
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
           Collider2D currentPuz = puzPieces[1].GetComponent<Collider2D>();
            if (currentPuz.enabled)
            {
                puzSolved = false;
                break;
            }
        }

        if (puzSolved)
        {
            GameObject.Find("Puzzle2").SetActive(false);
            PlayerMovement playerMove = GameObject.Find("Player").GetComponent<PlayerMovement>();
            playerMove.enabled = true;
        }
    }
}
