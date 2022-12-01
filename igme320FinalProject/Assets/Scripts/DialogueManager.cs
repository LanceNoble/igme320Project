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
    private string vilUntieInt1 = "Dialogue/Vill/VIL_untie_int1";
    private string vilUntieInt2 = "Dialogue/Vill/VIL_untie_int2";
    private string vilUntieFail = "Dialogue/Vill/VIL_untie_fail1";
    private string vilInfinite = "Dialogue/Vill/Infinite_Scroll";
    private string vilImageStart = "Dialogue/Vill/VIL_image_1";
    private string vilImageInt1 = "Dialogue/ImagePuzzText/ImagePuzzText/VIL_standard_script_int2.1";
    private string vilImageInt2 = "Dialogue/ImagePuzzText/ImagePuzzText/VIL_standard_script_int2.2";
    private string vilBlogStart = "Dialogue/BlogPuzzText/BlogPuzzText/VIL_blogPuzz_intro";
    private string vilBlogInt1 = "Dialogue/BlogPuzzText/BlogPuzzText/VIL_int3.1";
    private string vilBlogInt2 = "Dialogue/BlogPuzzText/BlogPuzzText/VIL_int3.2";
    //player text
    private string playIntro = "Dialogue/Player/P_intro_1";
    private string playUntie1 = "Dialogue/Player/P_untie_1";
    private string playUntieFail = "Dialogue/Player/P_untie_puzfail";
    private string playUntiePass = "Dialogue/Player/P_untie_2";
    private string playLightOn;
    private string playImageStart = "Dialogue/Player/P_image_1";
    private string playImageFail = "Dialogue/ImagePuzzText/ImagePuzzText/P_failPuzz";
    private string playImagePass = "Dialogue/ImagePuzzText/ImagePuzzText/P_solvePuzz";
    private string playBlogStart = "Dialogue/BlogPuzzText/BlogPuzzText/P_blogPuzz_intro";
    private string playBlogFail = "Dialogue/BlogPuzzText/BlogPuzzText/blogPuzz_failed";
    private string playBlogPass = "";


    [SerializeField] GameObject playerText;
    [SerializeField] GameObject vilText;
    [SerializeField] RangeCheck puzOneObj;
    [SerializeField] RangeCheck2 puzTwoObj;
    [SerializeField] RangeCheck3 puzThreeObj;
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    [SerializeField] GameObject button3;
    [SerializeField] GameObject playerMove;
    [SerializeField] GameObject puzOneIntObj;
    [SerializeField] GameObject puzTwo;

    [SerializeField] GameObject ropeObj;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject timerText;
    [SerializeField] int currentText = 0;
    public TextAsset playTextAsset;
    public TextAsset vilTextAsset;
    public string[] currentPlayerText;
    public string[] currentVillText;
    public int playStart;
    public int vilStart;
    public int playerLineStart;
    public int playerLineEnd;
    public int vilLineStart;
    public int vilLineEnd;
    private bool runText;
    public bool startPuz;
    public bool canClick;
    public int buttonValue;
    public bool intAdvance;
    GameObject button1Text;
    GameObject button2Text;
    GameObject button3Text;
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
                    playerLineEnd = 23;

                    playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);
                    runText = false;
                    break;
                //V: Oh Great - God Forbid :: Annoyed
                case 3:
                    vilTextAsset = Resources.Load<TextAsset>(vilIntro);


                    currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                    vilLineStart = 3;
                    vilLineEnd = 6;

                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                    runText = false;

                    break;
                //P: The screen is behind me
                case 4:
                    playTextAsset = Resources.Load<TextAsset>(playIntro);

                    currentPlayerText = Regex.Split(playTextAsset.text, "\n");

                    playerLineStart = 26;
                    playerLineEnd = 28;

                    playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);
                    runText = false;
                    break;
                //V: No matter - END; :: Neutral
                case 5:
                    vilTextAsset = Resources.Load<TextAsset>(vilIntro);


                    currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                    vilLineStart = 6;
                    vilLineEnd = currentVillText.Length;

                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                    runText = false;
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
                    if (!startPuz)
                    {
                        button1.SetActive(true);
                        button2.SetActive(true);
                        button3.SetActive(true);
                        intAdvance = false;
                    }
                    startPuz = true;
                   
                  
                    button1Text = button1.transform.GetChild(0).gameObject;
                    
                    button1Text.GetComponent<TextMeshProUGUI>().text = "...Yeah, it's painting";
                   
                    button2Text = button2.transform.GetChild(0).gameObject;
                    button2Text.GetComponent<TextMeshProUGUI>().text = "Okay, it is painting, but I don't know what the test has to do with that.";

                    button3Text = button3.transform.GetChild(0).gameObject;
                    button3Text.GetComponent<TextMeshProUGUI>().text = "What's it to you?";

                    if (buttonValue != 0)
                    {
                        button1.SetActive(false);
                        button2.SetActive(false);
                        button3.SetActive(false);
                        switch (buttonValue)
                        {
                            case 1:
                                vilTextAsset = Resources.Load<TextAsset>(vilUntieInt1);
                                currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                                vilLineStart = 0;
                                vilLineEnd = 2;
                                vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                           
                                buttonValue = 0;
                                break;
                            case 2:
                                vilTextAsset = Resources.Load<TextAsset>(vilUntieInt2);
                                currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                                vilLineStart = 0;
                                vilLineEnd = 2;
                                vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                              
                                buttonValue = 0;
                                break;
                            case 3:
                                vilTextAsset = Resources.Load<TextAsset>(vilUntieFail);
                                currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                                vilLineStart = 0;
                                vilLineEnd = 2;
                                vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                                buttonValue = 0;
                                break;
                        }
                    }

                    if (playerMove.GetComponent<PlayerMovement>().enabled  && vilText.GetComponent<TextScroll>().textFinished == 2)
                    {
                        timer.GetComponent<TimerScript>().timeLeft = 180f;
                        timer.SetActive(false);
                        timerText.SetActive(false);
                        buttonValue = 0;
                        vilTextAsset = Resources.Load<TextAsset>(vilUntie2);
                        playerMove.GetComponent<SpriteRenderer>().enabled = true;
                        puzOneIntObj.SetActive(false);
                        ropeObj.SetActive(true);
                        currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                        vilLineStart = 0;
                        vilLineEnd = 3;
                        intAdvance = true;
                        vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                        runText = false;
                        startPuz = false;
                    }
                    break;
                case 9:
                    intAdvance = false;
                    playTextAsset = Resources.Load<TextAsset>(playUntie1);

                    currentPlayerText = Regex.Split(playTextAsset.text, "\n");

                    playerLineStart = 0;
                    playerLineEnd = currentPlayerText.Length;

                    playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);
                    runText = false;
                    break;
                    // Infinite Scroll
                case 10:

                    if (puzTwoObj.clickState == 2)
                    {
                        vilTextAsset = Resources.Load<TextAsset>(vilImageStart);


                        currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                        vilLineStart = 0;
                        vilLineEnd = currentVillText.Length;

                        vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                        runText = false;
                    }


                    break;
                    // Play Image start
                case 11:
                    playTextAsset = Resources.Load<TextAsset>(playImageStart);

                    currentPlayerText = Regex.Split(playTextAsset.text, "\n");

                    playerLineStart = 0;
                    playerLineEnd = currentPlayerText.Length;

                    playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);
                    runText = false;
                    break;

            
                    // Puz 2 dialogue
                case 12:
                    if (!startPuz)
                    {
                        button1.SetActive(true);
                        button2.SetActive(true);
                        button3.SetActive(true);
                        intAdvance = false;
                        puzTwo.SetActive(true);
                        timer.SetActive(true);
                        timerText.SetActive(true);
                          
                    button1Text = button1.transform.GetChild(0).gameObject;
                    
                    button1Text.GetComponent<TextMeshProUGUI>().text = "I picked my major at random too, way too many choices.";
                   
                    button2Text = button2.transform.GetChild(0).gameObject;
                    button2Text.GetComponent<TextMeshProUGUI>().text = "What do you like making?";

                    button3Text = button3.transform.GetChild(0).gameObject;
                    button3Text.GetComponent<TextMeshProUGUI>().text = "You said your mom was an illustrator?";
                    }
                    startPuz = true;
                    break;

                    // Infinite Scroll
                case 13:

                    break;
                    //blog player start
              
                case 14:

                    break;
                    // blog puz dialogue
                case 15:

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
                    if (vilText.GetComponent<TextScroll>().textFinished == 2 && intAdvance == true)
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
                case 11:
                    playStart = playerText.GetComponent<PlayerText>().playTextFinished;
                    if (playStart == 2)
                    {
                        runText = true;
                        playerText.GetComponent<PlayerText>().playTextFinished = 0;
                        currentText = 12;
                    }
                    break;
                case 12:
                    if (vilText.GetComponent<TextScroll>().textFinished == 2 && intAdvance == true)
                    {
                        runText = true;
                        vilText.GetComponent<TextScroll>().textFinished = 0;
                        currentText = 13;
                    }
                    break;
                case 13:
                    if (vilText.GetComponent<TextScroll>().textFinished == 2 && intAdvance == true)
                    {
                        runText = true;
                        vilText.GetComponent<TextScroll>().textFinished = 0;
                        currentText = 14;
                    }
                    break;
                case 14:
                    playStart = playerText.GetComponent<PlayerText>().playTextFinished;
                    if (playStart == 2)
                    {
                        runText = true;
                        playerText.GetComponent<PlayerText>().playTextFinished = 0;
                        currentText = 15;
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

