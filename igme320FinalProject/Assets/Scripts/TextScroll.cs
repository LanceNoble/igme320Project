using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class TextScroll : MonoBehaviour
{
   
    [SerializeField] private float textSpeed = 0.01f;
    [SerializeField] private TextMeshProUGUI areaText;
    [SerializeField] private RectTransform villianText;
    [SerializeField] private float textWorldScale;
    public int textFinished = 0;
    private Vector3 orignPos;
    [SerializeField] private GameObject textManager;
   
    private void Start()
    {
        Vector3 orignPos = new Vector3(0,0,90);
        textWorldScale = .0055f;
        villianText.localPosition = orignPos;
    }

    public void ActivateText(int lineStart, int lineEnd, string[] textInfo)
    {
        StartCoroutine(AnimateText(lineStart, lineEnd, textInfo));
    }
    public void Reset()
    {
        
    }
    IEnumerator AnimateText(int lineStart,int lineEnd, string[] textInfo)
    {
        int lineCount = 9;
        for (int j = lineStart; j < lineEnd; j++)
        {
            for (int i = 0; i < textInfo[j].Length + 1; i++)
            {
                if (areaText.textInfo.lineCount >= lineCount)
                {
                    areaText.rectTransform.Translate(new Vector3(0, 98.8916f * textWorldScale, 0), Space.Self);
                    lineCount++;
                }

                areaText.text = textInfo[j].Substring(0, i);
                yield return new WaitForSeconds(textSpeed);

            }
            yield return new WaitForSeconds(.5f);
        }
        yield return new WaitForSeconds(.5f);
        textFinished = 2;
        areaText.text = " ";
    }
}
