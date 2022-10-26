using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerText : MonoBehaviour
{
   
    [SerializeField] private float textSpeed = 0.01f;
    [SerializeField] private TextMeshProUGUI areaText;
    public int playTextFinished = 0;
    [SerializeField] private GameObject textManager;


    public void ActivateText(int lineStart, int lineEnd, string[] textInfo)
    {
        StartCoroutine(AnimateText(lineStart,lineEnd,textInfo));
    }
 
    IEnumerator AnimateText(int lineStart,int lineEnd,string[] textInfo)
    {
        for (int j = lineStart; j < lineEnd; j++)
        {
            for (int i = 0; i < textInfo[j].Length + 1; i++)
            {

                areaText.text = textInfo[j].Substring(0, i);
                yield return new WaitForSeconds(textSpeed);

            }
            yield return new WaitForSeconds(.5f);
        }
        yield return new WaitForSeconds(.5f);
        playTextFinished = 2;
        areaText.text = " ";
    }
}
