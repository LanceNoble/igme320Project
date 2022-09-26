using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScroll : MonoBehaviour
{
    [SerializeField] [TextArea] private string[] textInfo;
    [SerializeField] private float textSpeed = 0.01f;

    [SerializeField] private TextMeshProUGUI areaText;
    private int currentDisplayText = 0;
    // Update is called once per frame
    void Start()
    {
        ActivateText();
    }

    public void ActivateText()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        for (int i = 0; i < textInfo[currentDisplayText].Length + 1; i++)
        {
            areaText.text = textInfo[currentDisplayText].Substring(0, i);
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
