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
    [SerializeField] GameObject puzOneIntObj;
    [SerializeField] GameObject ropeObj;
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
                //P: What ? -what can I do
                case 0:
                    
                    playTextAsset = Resources.Load(playIntro) as TextAsset;
                  
                    currentPlayerText = Regex.Split(playTextAsset.text, "\n");


                    playerLineStart = 0;
                    playerLineEnd = 17;

                    playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);

                    runText = false;
                    
                    break;
                //V: Behold - Uhh... :: Happy
                case 1:
                    vilTextAsset = Resources.Load<TextAsset>(vilIntro);


                    currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                    vilLineStart = 0;
                    vilLineEnd = 3;

                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                    runText = false;

                    break;
                //P: ????? - Yeah.
                case 2:
                    playTextAsset = Resources.Load<TextAsset>(playIntro);

                    currentPlayerText = Regex.Split(playTextAsset.text, "\n");

                    playerLineStart = 18;
                    playerLineEnd = 27;

                    playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);
                    runText = false;
                    break;
                //V: Oh Great - God Forbid :: Annoyed
                case 3:
                    vilTextAsset = Resources.Load<TextAsset>(vilIntro);


                    currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                    vilLineStart = 3;
                    vilLineEnd = currentVillText.Length;

                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                    runText = false;

                    break;
                //P: The screen is behind me
                case 4:
                    break;
                //V: No matter - END; :: Neutral
                case 5:
                    break;

                //P: Like Hell -END;
                case 6:
                    playTextAsset = Resources.Load<TextAsset>(playIntro);

                    currentPlayerText = Regex.Split(playTextAsset.text, "\n");
                    playerLineStart = 28;
                    playerLineEnd = currentPlayerText.Length;

                    playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);
                    runText = false;
                    break;

                //SCENE- KNOTPUZZSTART
                //V_Untie_1::Confident
                //V:START - END;
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
                        //  button1.SetActive(false);
                        // button2.SetActive(false);
                        //button3.SetActive(false);
                        vilTextAsset = Resources.Load<TextAsset>(vilUntie2);
                        playerMove.GetComponent<SpriteRenderer>().enabled = true;
                        puzOneIntObj.SetActive(false);
                        ropeObj.SetActive(true);
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
/*Dialogue
    * *Scared* *Thinking Puzz* *Shocked Fail* *thinking* *happy *
    * Add Villian to screen
    * SCENE- INTRO
    * P_Intro_1
    * v_Intro_1
    * P: What? - what can I do
    * V: Behold - Uhh... :: Happy
    * P: ????? - Yeah.
    * V: Oh Great - God Forbid :: Annoyed
    * P: The screen is behind me
    * V: No matter - END; :: Neutral
    * P: Like Hell - END;
    *  
    * SCENE- KNOTPUZZSTART
    * V_Untie_1 :: Confident
    * V:START - END;
    *
    * SCENE- KNOTPUZINTER
    * buttonPass1 "...Yeah, it's painting" - Vil_Untie_Int1 :: Happy
    * buttonPass2 "Okay, it is painting, but I don't know what the test has to do with that."- Vil_Untie_Int2 :: Woe
    * buttonFail1 "What's it to you?" - Vil_Untie_Fail1 :: Annoyed
    *
    * SCENE- KNOTPUZZFAIL
    * P_UNTIE_PuzzFail
    *
    * SCENE- KNOTPUZZPASS
    * P_UNTIE1
    *
    * SCENE- TURNON
    * P_Light
    *
    * SCENE- FREEMOVERANDTEXT
    * V_Infinite_Scroll :: InfiniteScroll
    *
    * SCENE- IMAGEPUZSTART
    * Vil_Image_1 :: Neutral
    * P_image_1
    *
    * SCENE- IMAGEPUZINTER1
    * buttonPass1 P_Pass_ResponseA_Int2.1 - Vil_Pass_ResponseA_Int2.1 :: Happy
    * buttonPass2 P_Pass_ResponseB_Int2.1 - Vil_Pass_ResponseB_Int2.1 :: Confident
    * buttonFail1 P_Fail_Response_Int2.1 - Vil_Fail_Response_Int2.1 :: Woe
    * Vil_StandardScript_int_2.1 :: Neutral
    *
    * SCENE- IMAGEPUZINTER2
    * buttonPass1 P_Pass_ResponseA_Int2.2 - Vil_Pass_ResponseA_Int2.2 :: Happy
    * buttonPass2 P_Pass_ResponseB_Int2.2 - Vil_Pass_ResponseB_Int2.2 :: Confident
    * buttonFail1 P_Fail_Response_Int2.2 - Vil_Fail_Response_Int2.2 :: Woe
    * Vil_StandardScript_int_2.2 :: Neutral
    *
    * SCENE- PUZZFAIL
    * P_Fail_Puz
    *
    * SCENE- PUZZPASS
    *  P_Fail_Puz
    *  
    * SCENE- FREEMOVERANDTEXT
    * V_Infinite_Scroll :: InfiniteScroll
    *
    * SCENE- BLOGPUZZSTART
    * P_Blug_Puzz_Intro
    * Vil_Blug_Puzz_Intro :: Annoyed
    * Vil_int_3.1 :: Neutral
    *
    * SCENE- BLOGPUZINTER1
    * buttonPass1 P_Pass_Int3.1_ResponseA - Vil_Pass_Int3.1_ResponseA :: Happy
    * buttonPass2 P_Pass_Int3.1_ResponseB - Vil_Pass_Int3.1_ResponseB :: Confident
    * buttonFail1 P_Fail_Int3.1 - Vil_Fail_Int3.1 :: Woe
    * Vil_int_3.2 :: Neutral
    *
    * SCENE- BLOGPUZINTER2
    * buttonPass1 P_Pass_Int3.2_ResponseA - Vil_Pass_Int3.2_ResponseA :: Happy
    * buttonPass2 P_Pass_Int3.2_ResponseB - Vil_Pass_Int3.2_ResponseB :: Confident
    * buttonFail1 P_Fail_Int3.2 - Vil_Fail_Int3.2 :: Woe
    *
    * SCENE - BLOGPUZFAIL
    * BlogPuzz_Failed
    *
    * SCENE - BLOGPUZSolved
    * BlogPuzz_Solved
    *
    */

