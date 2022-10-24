using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    //Vill text
    private string vilIntro = "Assets/Dialogue/Vill/VIL_intro_1.txt";
    private string vilUntie1 = "Assets/Dialogue/Vill/VIL_untie_1.txt";
    private string vilUntie2 = "Assets/Dialogue/Vill/VIL_untie_2.txt";
    private string vilUntieFail = "Assets/Dialogue/Vill/VIL_untie_fail1.txt";
    private string vilUntiePass1 = "Assets/Dialogue/Vill/VIL_untie_int1.txt";
    private string vilUntiePass2 = "Assets/Dialogue/Vill/VIL_untie_int2.txt";
    private string vilImage1 = "Assets/Dialogue/Vill/VIL_image_1.txt";
    //player text
    private string playIntro = "Assets/Dialogue/Player/P_intro_1.txt";
    private string playUntie1 = "Assets/Dialogue/Player/P_untie_1.txt";
    private string playUntieFail = "Assets/Dialogue/Player/P_untie_puzfail.txt";
    private string playPuzFail = "Assets/Dialogue/Player/P_image_1.txt";
    [SerializeField] GameObject playerText;
    [SerializeField] GameObject vilText;
    [SerializeField] RangeCheck puzOneObj;
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    [SerializeField] GameObject button3;
    [SerializeField] GameObject playerMove;
    public string[] currentPlayerText;
    public string[] currentVillText;
    private int currentText = 0;
    public int playStart;
    public int vilStart;
    public int playerLineStart;
    public int playerLineEnd;
    public int vilLineStart;
    public int vilLineEnd;
    private bool runText;
    public bool startPuz;
    public bool canClick;

    public void Start()
    {
        runText = true;
        canClick = false;
    }

    public void Update()
    {
        Debug.Log(currentText);
        if (runText)
        {
            switch (currentText)
            {
                case 0:
                    currentPlayerText = File.ReadAllLines(playIntro);

                    playerLineStart = 0;
                    playerLineEnd = 17;

                    playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);

                    runText = false;
                    
                    break;
                case 1:
                    currentVillText = File.ReadAllLines(vilIntro);
                    vilLineStart = 0;
                    vilLineEnd = 3;

                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                    runText = false;

                    break;
                case 2:
                    currentPlayerText = File.ReadAllLines(playIntro);
                    playerLineStart = 18;
                    playerLineEnd = 23;

                    playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);
                    runText = false;
                    break;
                case 3:
                    currentVillText = File.ReadAllLines(vilIntro);
                   
                    vilLineStart = 3;
                    vilLineEnd = 9;

                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                    runText = false;

                    break;
                case 4:
                    currentPlayerText = File.ReadAllLines(playIntro);
                  
                    playerLineStart = 23;
                    playerLineEnd = 27;

                    playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);
                    runText = false;

                    break;
                case 5:
                    currentVillText = File.ReadAllLines(vilIntro);

                    vilLineStart = 10;
                    vilLineEnd = 15;

                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                    runText = false;
                    break;
                case 6:
                    currentPlayerText = File.ReadAllLines(playIntro);
                    playerLineStart = 28;
                    playerLineEnd = 53;

                    playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);
                    runText = false;
                    break;
                case 7:
                    canClick = true;
                    if (puzOneObj.clickState == 2)
                    {
                        currentVillText = File.ReadAllLines(vilUntie1);
                        vilLineStart = 0;
                        vilLineEnd = 11;

                        vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                        runText = false;
                    }
                    break;
                case 8:
                    startPuz = true;
                    button1.SetActive(true);
                    GameObject button1Text = button1.transform.GetChild(0).gameObject;
                    
                    button1Text.GetComponent<TextMeshProUGUI>().text = "Art";
                    button2.SetActive(true);
                    GameObject button2Text = button2.transform.GetChild(0).gameObject;
                    button2Text.GetComponent<TextMeshProUGUI>().text = "History";
                    button3.SetActive(true);
                    GameObject button3Text = button3.transform.GetChild(0).gameObject;
                    button3Text.GetComponent<TextMeshProUGUI>().text = "Math";
                    if (playerMove.GetComponent<PlayerMovement>().enabled)
                    {
                        button1.SetActive(false);
                        button2.SetActive(false);
                        button3.SetActive(false);
                        currentVillText = File.ReadAllLines(vilUntie2);
                        vilLineStart = 0;
                        vilLineEnd = 7;

                        vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                        runText = false;
                    }
                    break;
                case 9:
                    currentPlayerText = File.ReadAllLines(playUntie1);

                    playerLineStart = 0;
                    playerLineEnd = 1;

                    playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);
                    runText = false;
                    break;
                case 10:
                   
                        currentVillText = File.ReadAllLines(vilUntie2);
                        vilLineStart = 8;
                        vilLineEnd = 11;

                        vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                        runText = false;
                  
                    break;
                case 11:
                    startPuz = true;
                    currentPlayerText = File.ReadAllLines(playUntie1);

                    playerLineStart = 3;
                    playerLineEnd = 5;

                    playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);
                    runText = false;
                    break;
                case 20:
                    break;
            }
        }
        else
        {
            switch (currentText)
            {
                case 0:
                    playStart = playerText.GetComponent<PlayerText>().playTextFinished;
                    Debug.Log(playStart);
                   if (playStart == 2)
                    {
                        runText = true;
                        playerText.GetComponent<PlayerText>().playTextFinished = 0;
                        currentText = 1;
                    }
                  
                    break;
                case 1:
                   if (vilText.GetComponent<TextScroll>().textFinished == 2)
                    {
                        runText = true;
                        vilText.GetComponent<TextScroll>().textFinished = 0;
                        currentText = 2;
                    }
                    break;
                case 2:
                    playStart = playerText.GetComponent<PlayerText>().playTextFinished;
                    if (playStart == 2)
                    {
                        runText = true;
                        playerText.GetComponent<PlayerText>().playTextFinished = 0;
                        currentText = 3;
                    }

                    break;
                case 3:
                    if (vilText.GetComponent<TextScroll>().textFinished == 2)
                    {
                        runText = true;
                        vilText.GetComponent<TextScroll>().textFinished = 0;
                        currentText = 4;
                    }

                    break;
                case 4:
                    playStart = playerText.GetComponent<PlayerText>().playTextFinished;
                    if (playStart == 2)
                    {
                        runText = true;
                        playerText.GetComponent<PlayerText>().playTextFinished = 0;
                        currentText = 5;
                    }
                    break;
                case 5:
                    if (vilText.GetComponent<TextScroll>().textFinished == 2)
                    {
                        runText = true;
                        vilText.GetComponent<TextScroll>().textFinished = 0;
                        currentText = 6;
                    }
                    break;
                case 6:
                    playStart = playerText.GetComponent<PlayerText>().playTextFinished;
                    if (playStart == 2)
                    {
                        runText = true;
                        playerText.GetComponent<PlayerText>().playTextFinished = 0;
                        currentText = 7;
                    }
                    break;
                case 7:
                    if (vilText.GetComponent<TextScroll>().textFinished == 2)
                    {
                        runText = true;
                        vilText.GetComponent<TextScroll>().textFinished = 0;
                        currentText = 8;
                    }
                    break;
                case 8:
                    if (vilText.GetComponent<TextScroll>().textFinished == 2)
                    {
                        runText = true;
                        vilText.GetComponent<TextScroll>().textFinished = 0;
                        currentText = 9;
                    }
                    break;
                case 9:
                    playStart = playerText.GetComponent<PlayerText>().playTextFinished;
                    if (playStart == 2)
                    {
                        runText = true;
                        playerText.GetComponent<PlayerText>().playTextFinished = 0;
                        currentText = 10;
                    }
                    break;
                case 10:
                    if (vilText.GetComponent<TextScroll>().textFinished == 2)
                    {
                        runText = true;
                        vilText.GetComponent<TextScroll>().textFinished = 0;
                        currentText = 11;
                    }
                    break;
                   
                case 20:
                    break;
            }
        }

     
    }
    public bool ButtonPress()
    {
        return true;
    }
}
