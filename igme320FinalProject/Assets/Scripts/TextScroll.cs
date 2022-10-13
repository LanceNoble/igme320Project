using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class TextScroll : MonoBehaviour
{
    private string[] textInfo;
    [SerializeField] private float textSpeed = 0.01f;
    [SerializeField] private TextMeshProUGUI areaText;
    [SerializeField] private RectTransform villianText;
    [SerializeField] private float textWorldScale;
    private bool textFinished = true;
    private Vector3 orignPos;

    static string vilDia1 = "Assets/Dialogue/Vill/VIL_intro_1.txt";
    static string vilDia2 = "Assets/Dialogue/SAMPLE2.txt";
    static string vilDia3 = "Assets/Dialogue/SAMPLE3.txt";
    static string vilDia4 = "Assets/Dialogue/SAMPLE4.txt";
    static string vilDia5 = "Assets/Dialogue/SAMPLE5.txt";

    private void Start()
    {
        Vector3 orignPos = new Vector3(0,0,90);
        textWorldScale = .0055f;
        villianText.localPosition = orignPos;
    }



    private void Update()
    {
        if (textFinished)
        {
            villianText.localPosition = orignPos;

            textInfo = File.ReadAllLines(vilDia1);

            ActivateText();
            textFinished = false;
        }
    }
    public void ActivateText()
    {
        StartCoroutine(AnimateText());
    }
    public void Reset()
    {
        
    }
    IEnumerator AnimateText()
    {
        int lineCount = 9;
        for (int j = 0; j < textInfo.Length; j++)
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
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(1);
        textFinished = true;
        areaText.text = "";
    }
}
