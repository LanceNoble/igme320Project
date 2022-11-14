using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class DialogueManager : MonoBehaviour
{
    //Vill text
    private string vilIntro = "Dialogue/Vill/VIL_intro_1";
    private string vilUntie1 = "Dialogue/Vill/VIL_untie_1";
    private string vilUntie2 = "Dialogue/Vill/VIL_untie_2";
    private string vilUntieFail = "Dialogue/Vill/VIL_untie_fail1";
    private string vilUntiePass1 = "Dialogue/Vill/VIL_untie_int1";
    private string vilUntiePass2 = "Dialogue/Vill/VIL_untie_int2";
    private string vilImage1 = "Dialogue/Vill/VIL_image_1";
    //player text
    private string playIntro = "Dialogue/Player/P_intro_1";
    private string playUntie1 = "Dialogue/Player/P_untie_1";
    private string playUntieFail = "Dialogue/Player/P_untie_puzfail";
    private string playPuzFail = "Dialogue/Player/P_image_1";
    [SerializeField] GameObject playerText;
    [SerializeField] GameObject vilText;
    [SerializeField] RangeCheck puzOneObj;
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    [SerializeField] GameObject button3;
    [SerializeField] GameObject playerMove;
    public TextAsset playTextAsset;
    public TextAsset vilTextAsset;
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
       
        if (runText)
        {
            switch (currentText)
            {
                case 0:
                    
                    playTextAsset = Resources.Load(playIntro) as TextAsset;
                  
                    currentPlayerText = Regex.Split(playTextAsset.text, "\n");


                    playerLineStart = 0;
                    playerLineEnd = 17;

                    playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);

                    runText = false;
                    
                    break;
                case 1:
                    vilTextAsset = Resources.Load<TextAsset>(vilIntro);


                    currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                    vilLineStart = 0;
                    vilLineEnd = 3;

                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                    runText = false;

                    break;
                case 2:
                    playTextAsset = Resources.Load<TextAsset>(playIntro);

                    currentPlayerText = Regex.Split(playTextAsset.text, "\n");

                    playerLineStart = 18;
                    playerLineEnd = 27;

                    playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);
                    runText = false;
                    break;
                case 3:
                    vilTextAsset = Resources.Load<TextAsset>(vilIntro);


                    currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                    vilLineStart = 3;
                    vilLineEnd = currentVillText.Length;

                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                    runText = false;

                    break;
             
                case 6:
                    playTextAsset = Resources.Load<TextAsset>(playIntro);

                    currentPlayerText = Regex.Split(playTextAsset.text, "\n");
                    playerLineStart = 28;
                    playerLineEnd = currentPlayerText.Length;

                    playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);
                    runText = false;
                    break;
                case 7:
                    canClick = true;
                    if (puzOneObj.clickState == 2)
                    {
                        vilTextAsset = Resources.Load<TextAsset>(vilUntie1);


                        currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                        vilLineStart = 0;
                        vilLineEnd = currentVillText.Length;

                        vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                        runText = false;
                    }
                    break;
                case 8:
                    startPuz = true;
                    //button1.SetActive(true);
                    GameObject button1Text = button1.transform.GetChild(0).gameObject;
                    
                    button1Text.GetComponent<TextMeshProUGUI>().text = "Art";
                    //button2.SetActive(true);
                    GameObject button2Text = button2.transform.GetChild(0).gameObject;
                    button2Text.GetComponent<TextMeshProUGUI>().text = "History";
                   // button3.SetActive(true);
                    GameObject button3Text = button3.transform.GetChild(0).gameObject;
                    button3Text.GetComponent<TextMeshProUGUI>().text = "Math";
                    if (playerMove.GetComponent<PlayerMovement>().enabled)
                    {
                        //  button1.SetActive(false);
                        // button2.SetActive(false);
                        //button3.SetActive(false);
                        vilTextAsset = Resources.Load<TextAsset>(vilUntie2);


                        currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                        vilLineStart = 0;
                        vilLineEnd = 3;

                        vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                        runText = false;
                    }
                    break;
                case 9:
                    playTextAsset = Resources.Load<TextAsset>(playUntie1);

                    currentPlayerText = Regex.Split(playTextAsset.text, "\n");

                    playerLineStart = 0;
                    playerLineEnd = 1;

                    playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);
                    runText = false;
                    break;
                case 10:

                        vilTextAsset = Resources.Load<TextAsset>(vilUntie2);


                        currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                        vilLineStart = 8;
                        vilLineEnd = currentVillText.Length;

                        vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                        runText = false;
                  
                    break;
                case 11:
                    startPuz = true;
                    playTextAsset = Resources.Load<TextAsset>(playUntie1);

                    currentPlayerText = Regex.Split(playTextAsset.text, "\n");

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
                        currentText = 6;
                    }

                    break;
                case 4:
                    playStart = playerText.GetComponent<PlayerText>().playTextFinished;
                    if (playStart == 2)
                    {
                        runText = true;
                        playerText.GetComponent<PlayerText>().playTextFinished = 0;
                        currentText = 6;
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
