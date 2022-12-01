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
        textFinished = 0;
        areaText.text += "\n";
        Debug.Log(lineStart);
        Debug.Log(lineEnd);
        for (int j = lineStart; j < lineEnd - 1; j++)
        {
            char[] lineInfo = textInfo[j].ToCharArray();
            for (int i = 0; i < textInfo[j].Length; i++)
            {
                
                areaText.text += lineInfo[i];
                yield return new WaitForSeconds(textSpeed);

            }
            yield return new WaitForSeconds(1f);
        }
        
        yield return new WaitForSeconds(1f);
        textFinished = 2;
        
    }
}
