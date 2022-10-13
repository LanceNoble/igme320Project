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
    private int currentDisplayText = 0;
    [SerializeField] private RectTransform villianText;
    private bool textFinished = true;
    private Vector3 orignPos;

    static string vilDia1 = "Assets/Dialogue/SAMPLE1.txt";
    static string vilDia2 = "Assets/Dialogue/SAMPLE2.txt";
    static string vilDia3 = "Assets/Dialogue/SAMPLE3.txt";
    static string vilDia4 = "Assets/Dialogue/SAMPLE4.txt";
    static string vilDia5 = "Assets/Dialogue/SAMPLE5.txt";

    private void Start()
    {
        Vector3 orignPos = villianText.localPosition;
    }



    private void Update()
    {
        if (textFinished)
        {
            villianText.localPosition = orignPos;
            int randScript = Random.Range(1, 6);
            switch (randScript)
            {
                case 1:
                    textInfo = File.ReadAllLines(vilDia1);
                    break;
                case 2:
                    textInfo = File.ReadAllLines(vilDia2);
                    break;
                case 3:
                    textInfo = File.ReadAllLines(vilDia3);
                    break;
                case 4:
                    textInfo = File.ReadAllLines(vilDia4);
                    break;
                case 5:
                    textInfo = File.ReadAllLines(vilDia5);
                    break;
            }
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
        int lineCount = 10;
        float textWorldScale = .0062625f;
        for (int i = 0; i < textInfo[currentDisplayText].Length + 1; i++)
        {
            if (areaText.textInfo.lineCount >= lineCount)
            {
                areaText.rectTransform.Translate(new Vector3(0, 98.8916f * textWorldScale, 0), Space.Self);
                lineCount++;
            }
            areaText.text = textInfo[currentDisplayText].Substring(0, i);
            yield return new WaitForSeconds(textSpeed);
            
        }
        yield return new WaitForSeconds(1);
        textFinished = true;
    }
}
