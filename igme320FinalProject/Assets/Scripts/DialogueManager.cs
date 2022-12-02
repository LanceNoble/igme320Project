using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private string vilImageResponseA1 = "Dialogue/ImagePuzzText/ImagePuzzText/VIL_pass_responseA_int2.1";
    private string vilImageResponseA2 = "Dialogue/ImagePuzzText/ImagePuzzText/VIL_pass_responseA_int2.2";
    private string vilImageResponseB1 = "Dialogue/ImagePuzzText/ImagePuzzText/VIL_pass_responseB_int2.1";
    private string vilImageResponseB2 = "Dialogue/ImagePuzzText/ImagePuzzText/VIL_pass_responseB_int2.2";
    private string vilImageFail1 = "Dialogue/ImagePuzzText/ImagePuzzText/VIL_fail_response_int2.1";
    private string vilImageFail2 = "Dialogue/ImagePuzzText/ImagePuzzText/VIL_fail_response_int2.2";
    private string vilBlogStart = "Dialogue/BlogPuzzText/BlogPuzzText/VIL_blogPuzz_intro";
    private string vilBlogInt1 = "Dialogue/BlogPuzzText/BlogPuzzText/VIL_int3.1";
    private string vilBlogInt2 = "Dialogue/BlogPuzzText/BlogPuzzText/VIL_int3.2";
    private string vilBlogResponseA1 = "Dialogue/BlogPuzzText/BlogPuzzText/VIL_pass_int3.1_responseA";
    private string vilBlogResponseA2 = "Dialogue/BlogPuzzText/BlogPuzzText/VIL_pass_int3.2_responseA";
    private string vilBlogResponseB1 = "Dialogue/BlogPuzzText/BlogPuzzText/VIL_pass_int3.1_responseB";
    private string vilBlogResponseB2 = "Dialogue/BlogPuzzText/BlogPuzzText/VIL_pass_int3.2_responseB";
    private string vilBlogFail1 = "Dialogue/BlogPuzzText/BlogPuzzText/VIL_fail_int3.1";
    private string vilBlogFail2 = "Dialogue/BlogPuzzText/BlogPuzzText/VIL_fail_int3.2";
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
    private string playBlogPass = "Dialogue/BlogPuzzText/BlogPuzzText/blogPuzz_solved";


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
    [SerializeField] GameObject puzThree;
    [SerializeField] GenerateCode puzThreeCode;
    [SerializeField] GameObject ropeObj;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject timerText;
    [SerializeField] int currentText = 0;
    [SerializeField] VilAnimate vilBig;
    [SerializeField] VilAnimate vilSmall;
    [SerializeField] PlayAnimate playSmall;
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
    public bool wrongAnswer = false;
    float time = 5f;
    public void Start()
    {
        runText = true;
        canClick = false;
    }

    public void Update()
    {
        if (wrongAnswer)
        {
            if(vilText.GetComponent<TextScroll>().textFinished == 2)
            {
                SceneManager.LoadScene("LoseScene");
            }
        }
        else
        {
            if (runText)
            {
                switch (currentText)
                {
                    //P: What ? -what can I do
                    case 0:
                        playSmall.currentEmote = 3;
                        playTextAsset = Resources.Load(playIntro) as TextAsset;

                        currentPlayerText = Regex.Split(playTextAsset.text, "\n");


                        playerLineStart = 0;
                        playerLineEnd = 17;

                        playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);

                        runText = false;

                        break;
                    //V: Behold - Uhh... :: Happy
                    case 1:
                        vilBig.currentEmote = 3;
                        vilSmall.currentEmote = 3;
                        vilTextAsset = Resources.Load<TextAsset>(vilIntro);


                        currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                        vilLineStart = 0;
                        vilLineEnd = 3;

                        vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                        runText = false;

                        break;
                    //P: ????? - Yeah.
                    case 2:
                        playSmall.currentEmote = 1;
                        playTextAsset = Resources.Load<TextAsset>(playIntro);

                        currentPlayerText = Regex.Split(playTextAsset.text, "\n");

                        playerLineStart = 18;
                        playerLineEnd = 23;

                        playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);
                        runText = false;
                        break;
                    //V: Oh Great - God Forbid :: Annoyed
                    case 3:

                        vilBig.currentEmote = 0;
                        vilSmall.currentEmote = 0;
                        vilTextAsset = Resources.Load<TextAsset>(vilIntro);


                        currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                        vilLineStart = 3;
                        vilLineEnd = 6;

                        vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                        runText = false;

                        break;
                    //P: The screen is behind me
                    case 4:
                        playSmall.currentEmote = 2;
                        playTextAsset = Resources.Load<TextAsset>(playIntro);

                        currentPlayerText = Regex.Split(playTextAsset.text, "\n");

                        playerLineStart = 26;
                        playerLineEnd = 28;

                        playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);
                        runText = false;
                        break;
                    //V: No matter - END; :: Neutral
                    case 5:

                        vilBig.currentEmote = 5;
                        vilSmall.currentEmote = 5;
                        vilTextAsset = Resources.Load<TextAsset>(vilIntro);


                        currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                        vilLineStart = 6;
                        vilLineEnd = currentVillText.Length;

                        vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                        runText = false;
                        break;

                    //P: Like Hell -END;
                    case 6:
                        playSmall.currentEmote = 4;
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
                            vilBig.currentEmote = 1;
                            vilSmall.currentEmote = 1;
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
                        button2Text.GetComponent<TextMeshProUGUI>().text = "Okay, it is painting";

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
                                    vilBig.currentEmote = 3;
                                    vilSmall.currentEmote = 3;
                                    playSmall.currentEmote = 2;
                                    vilTextAsset = Resources.Load<TextAsset>(vilUntieInt1);
                                    currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                                    vilLineStart = 0;
                                    vilLineEnd = 2;
                                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);

                                    buttonValue = 0;
                                    break;
                                case 2:
                                    vilBig.currentEmote = 6;
                                    vilSmall.currentEmote = 6;
                                    playSmall.currentEmote = 1;
                                    vilTextAsset = Resources.Load<TextAsset>(vilUntieInt2);
                                    currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                                    vilLineStart = 0;
                                    vilLineEnd = 2;
                                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);

                                    buttonValue = 0;
                                    break;
                                case 3:
                                    playSmall.currentEmote = 3;
                                    vilBig.currentEmote = 0;
                                    vilSmall.currentEmote = 0;
                                    vilTextAsset = Resources.Load<TextAsset>(vilUntieFail);
                                    currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                                    vilLineStart = 0;
                                    vilLineEnd = 2;
                                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                                    buttonValue = 0;
                                    wrongAnswer = true;
                                    break;
                            }
                        }

                        if (playerMove.GetComponent<PlayerMovement>().enabled && vilText.GetComponent<TextScroll>().textFinished == 2 && !wrongAnswer)
                        {
                            vilBig.currentEmote = 1;
                            vilSmall.currentEmote = 1;
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
                        playSmall.currentEmote = 4;
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
                        vilBig.currentEmote = 4;
                        vilSmall.currentEmote = 4;
                        playSmall.currentEmote = 2;


                        if (puzTwoObj.clickState == 2 )
                        {
                            time = 5f;
                            vilBig.currentEmote = 5;
                            vilSmall.currentEmote = 5;
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
                        playSmall.currentEmote = 4;
                        playTextAsset = Resources.Load<TextAsset>(playImageStart);

                        currentPlayerText = Regex.Split(playTextAsset.text, "\n");

                        playerLineStart = 0;
                        playerLineEnd = currentPlayerText.Length;

                        playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);
                        runText = false;
                        break;


                    // image puz section 1 dialogue
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

                            button1Text.GetComponent<TextMeshProUGUI>().text = "I picked my major at random too";

                            button2Text = button2.transform.GetChild(0).gameObject;
                            button2Text.GetComponent<TextMeshProUGUI>().text =  "You said your mom was an illustrator?";

                            button3Text = button3.transform.GetChild(0).gameObject;
                            button3Text.GetComponent<TextMeshProUGUI>().text = "What do you like making?";

                            startPuz = true;
                        }

                        if (buttonValue != 0)
                        {
                            button1.SetActive(false);
                            button2.SetActive(false);
                            button3.SetActive(false);
                            switch (buttonValue)
                            {
                                case 1:
                                    playSmall.currentEmote = 2;
                                    vilBig.currentEmote = 3;
                                    vilSmall.currentEmote = 3;
                                    vilTextAsset = Resources.Load<TextAsset>(vilImageResponseA1);
                                    currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                                    vilLineStart = 0;
                                    vilLineEnd = 2;
                                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);

                                    buttonValue = 0;
                                    break;
                                case 3:
                                    playSmall.currentEmote = 1;
                                    vilBig.currentEmote = 1;
                                    vilSmall.currentEmote = 1;
                                    vilTextAsset = Resources.Load<TextAsset>(vilImageResponseB1);
                                    currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                                    vilLineStart = 0;
                                    vilLineEnd = 2;
                                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);

                                    buttonValue = 0;
                                    break;
                                case 2:
                                    playSmall.currentEmote = 0;
                                    vilBig.currentEmote = 0;
                                    vilSmall.currentEmote = 0;
                                    vilTextAsset = Resources.Load<TextAsset>(vilImageFail1);
                                    currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                                    vilLineStart = 0;
                                    vilLineEnd = 2;
                                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                                    buttonValue = 0;
                                    wrongAnswer = true;
                                    break;
                            }

                        }

                        if (vilText.GetComponent<TextScroll>().textFinished == 2 && !wrongAnswer)
                        {
                            vilBig.currentEmote = 5;
                            vilSmall.currentEmote = 5;
                            vilTextAsset = Resources.Load<TextAsset>(vilImageInt1);


                            currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                            vilLineStart = 0;
                            vilLineEnd = currentVillText.Length;

                            vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                            runText = false;
                            startPuz = false;
                        }

                        break;
                    // image puz section 2 dialogue
                    case 13:
                        if (!startPuz)
                        {
                            button1.SetActive(true);
                            button2.SetActive(true);
                            button3.SetActive(true);
                            button1Text = button1.transform.GetChild(0).gameObject;

                            button1Text.GetComponent<TextMeshProUGUI>().text =  "What made you choose drawing?";

                            button2Text = button2.transform.GetChild(0).gameObject;
                            button2Text.GetComponent<TextMeshProUGUI>().text = "What was the name of the blog?";

                            button3Text = button3.transform.GetChild(0).gameObject;
                            button3Text.GetComponent<TextMeshProUGUI>().text = "Yeah art history puts me right to sleep.";

                            startPuz = true;
                        }

                        if (buttonValue != 0)
                        {
                            button1.SetActive(false);
                            button2.SetActive(false);
                            button3.SetActive(false);
                            switch (buttonValue)
                            {
                                case 3:
                                    playSmall.currentEmote = 2;
                                    vilBig.currentEmote = 3;
                                    vilSmall.currentEmote = 3;
                                    vilTextAsset = Resources.Load<TextAsset>(vilImageResponseA2);
                                    currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                                    vilLineStart = 0;
                                    vilLineEnd = 2;
                                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);

                                    buttonValue = 0;
                                    break;
                                case 2:
                                    playSmall.currentEmote = 1;
                                    vilBig.currentEmote = 1;
                                    vilSmall.currentEmote = 1;
                                    vilTextAsset = Resources.Load<TextAsset>(vilImageResponseB2);
                                    currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                                    vilLineStart = 0;
                                    vilLineEnd = 2;
                                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);

                                    buttonValue = 0;
                                    break;
                                case 1:
                                    playSmall.currentEmote = 3;
                                    vilBig.currentEmote = 0;
                                    vilSmall.currentEmote = 0;
                                    vilTextAsset = Resources.Load<TextAsset>(vilImageFail2);
                                    currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                                    vilLineStart = 0;
                                    vilLineEnd = 2;
                                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                                    buttonValue = 0;
                                    wrongAnswer = true;
                                    break;
                            }

                        }

                        if (vilText.GetComponent<TextScroll>().textFinished == 2 && puzTwo.GetComponent<P2WinCheck>().puzFin && !wrongAnswer)
                        {
                            vilBig.currentEmote = 5;
                            vilSmall.currentEmote = 5;
                            timer.GetComponent<TimerScript>().timeLeft = 180f;
                            timer.SetActive(false);
                            timerText.SetActive(false);
                            buttonValue = 0;
                            vilTextAsset = Resources.Load<TextAsset>(vilImageInt2);


                            currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                            vilLineStart = 0;
                            vilLineEnd = currentVillText.Length;

                            vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                            runText = false;
                            startPuz = false;
                        }
                        break;

                    // image puz pass 
                    case 14:
                        playSmall.currentEmote = 2;
                        playTextAsset = Resources.Load<TextAsset>(playImagePass);

                        currentPlayerText = Regex.Split(playTextAsset.text, "\n");

                        playerLineStart = 0;
                        playerLineEnd = currentPlayerText.Length;

                        playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);
                        runText = false;
                        break;
                    //infinite
                    case 15:
                       

                        if (puzThreeObj.clickState == 2)
                        {

                            playTextAsset = Resources.Load<TextAsset>(playBlogStart);

                            currentPlayerText = Regex.Split(playTextAsset.text, "\n");

                            playerLineStart = 0;
                            playerLineEnd = currentPlayerText.Length;

                            playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);
                            runText = false;
                        }
                        break;

                    // Vill Blog start

                    case 16:
                        vilBig.currentEmote = 0;
                        vilSmall.currentEmote = 0;
                        vilTextAsset = Resources.Load<TextAsset>(vilBlogStart);
                        currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                        vilLineStart = 0;
                        vilLineEnd = currentVillText.Length;

                        vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                        runText = false;

                        break;

                    case 17:
                        vilBig.currentEmote = 5;
                        vilSmall.currentEmote = 5;
                        vilTextAsset = Resources.Load<TextAsset>(vilBlogInt1);
                        currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                        vilLineStart = 0;
                        vilLineEnd = currentVillText.Length;

                        vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                        runText = false;
                        break;

                    case 18:
                        if (!startPuz)
                        {
                            button1.SetActive(true);
                            button2.SetActive(true);
                            button3.SetActive(true);
                            intAdvance = false;
                            puzThree.SetActive(true);
                            timer.SetActive(true);
                            timerText.SetActive(true);

                            button1Text = button1.transform.GetChild(0).gameObject;

                            button1Text.GetComponent<TextMeshProUGUI>().text = "That's crazy coming from college students";

                            button2Text = button2.transform.GetChild(0).gameObject;
                            button2Text.GetComponent<TextMeshProUGUI>().text = "That's serious pressure for one person";

                            button3Text = button3.transform.GetChild(0).gameObject;
                            button3Text.GetComponent<TextMeshProUGUI>().text = "Why didn't you make the blog private?";

                            startPuz = true;
                        }

                        if (buttonValue != 0)
                        {
                            button1.SetActive(false);
                            button2.SetActive(false);
                            button3.SetActive(false);
                            switch (buttonValue)
                            {
                                case 1:
                                    playSmall.currentEmote = 2;
                                    vilBig.currentEmote = 3;
                                    vilSmall.currentEmote = 3;
                                    vilTextAsset = Resources.Load<TextAsset>(vilBlogResponseA1);
                                    currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                                    vilLineStart = 0;
                                    vilLineEnd = 2;
                                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);

                                    buttonValue = 0;
                                    break;
                                case 2:
                                    playSmall.currentEmote = 1;
                                    vilBig.currentEmote = 1;
                                    vilSmall.currentEmote = 1;
                                    vilTextAsset = Resources.Load<TextAsset>(vilBlogResponseB1);
                                    currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                                    vilLineStart = 0;
                                    vilLineEnd = 2;
                                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);

                                    buttonValue = 0;
                                    break;
                                case 3:
                                    playSmall.currentEmote = 3;
                                    vilBig.currentEmote = 6;
                                    vilSmall.currentEmote = 6;
                                    vilTextAsset = Resources.Load<TextAsset>(vilBlogFail1);
                                    currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                                    vilLineStart = 0;
                                    vilLineEnd = 2;
                                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                                    buttonValue = 0;
                                    wrongAnswer = true;
                                    break;
                            }

                        }

                        if (vilText.GetComponent<TextScroll>().textFinished == 2 && !wrongAnswer)
                        {
                            vilBig.currentEmote = 5;
                            vilSmall.currentEmote = 5;
                            vilTextAsset = Resources.Load<TextAsset>(vilBlogInt2);


                            currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                            vilLineStart = 0;
                            vilLineEnd = currentVillText.Length;

                            vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                            runText = false;
                            startPuz = false;
                        }

                        break;

                    case 19:
                        if (!startPuz)
                        {
                            button1.SetActive(true);
                            button2.SetActive(true);
                            button3.SetActive(true);

                            button1Text = button1.transform.GetChild(0).gameObject;

                            button1Text.GetComponent<TextMeshProUGUI>().text =  "Kidnapping me just for that?";

                            button2Text = button2.transform.GetChild(0).gameObject;
                            button2Text.GetComponent<TextMeshProUGUI>().text = "They must have been terrible students";

                            button3Text = button3.transform.GetChild(0).gameObject;
                            button3Text.GetComponent<TextMeshProUGUI>().text = "I just didn't want to fail...";

                            startPuz = true;
                        }

                        if (buttonValue != 0)
                        {
                            button1.SetActive(false);
                            button2.SetActive(false);
                            button3.SetActive(false);
                            switch (buttonValue)
                            {
                                case 3:
                                    playSmall.currentEmote = 2;
                                    vilBig.currentEmote = 3;
                                    vilSmall.currentEmote = 3;
                                    vilTextAsset = Resources.Load<TextAsset>(vilBlogResponseA2);
                                    currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                                    vilLineStart = 0;
                                    vilLineEnd = 2;
                                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);

                                    buttonValue = 0;
                                    break;
                                case 2:
                                    playSmall.currentEmote = 4;
                                    vilBig.currentEmote = 1;
                                    vilSmall.currentEmote = 1;
                                    vilTextAsset = Resources.Load<TextAsset>(vilBlogResponseB2);
                                    currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                                    vilLineStart = 0;
                                    vilLineEnd = 2;
                                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);

                                    buttonValue = 0;
                                    break;
                                case 1:
                                    playSmall.currentEmote = 3;
                                    vilBig.currentEmote = 6;
                                    vilSmall.currentEmote = 6;
                                    vilTextAsset = Resources.Load<TextAsset>(vilBlogFail2);
                                    currentVillText = Regex.Split(vilTextAsset.text, "\n\r");
                                    vilLineStart = 0;
                                    vilLineEnd = 2;
                                    vilText.GetComponent<TextScroll>().ActivateText(vilLineStart, vilLineEnd, currentVillText);
                                    buttonValue = 0;
                                    wrongAnswer = true;
                                    break;
                            }

                        }

                        if (vilText.GetComponent<TextScroll>().textFinished == 2 && puzThreeCode.puzFin && !wrongAnswer)
                        {
                            playSmall.currentEmote = 4;
                            timer.GetComponent<TimerScript>().timeLeft = 180f;
                            timer.SetActive(false);
                            timerText.SetActive(false);
                            playTextAsset = Resources.Load<TextAsset>(playBlogPass);

                            currentPlayerText = Regex.Split(playTextAsset.text, "\n");

                            playerLineStart = 0;
                            playerLineEnd = currentPlayerText.Length;

                            playerText.GetComponent<PlayerText>().ActivateText(playerLineStart, playerLineEnd, currentPlayerText);
                            runText = false;
                        }

                        break;
                    case 20:
                        SceneManager.LoadScene("TitleScreen");
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
                        if (vilText.GetComponent<TextScroll>().textFinished == 2)
                        {
                            runText = true;
                            vilText.GetComponent<TextScroll>().textFinished = 0;
                            currentText = 13;
                        }
                        break;
                    case 13:
                        if (vilText.GetComponent<TextScroll>().textFinished == 2)
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
                    case 15:
                        playStart = playerText.GetComponent<PlayerText>().playTextFinished;
                        if (playStart == 2)
                        {
                            runText = true;
                            playerText.GetComponent<PlayerText>().playTextFinished = 0;
                            currentText = 16;
                        }
                        break;
                    case 16:
                        if (vilText.GetComponent<TextScroll>().textFinished == 2)
                        {
                            runText = true;
                            vilText.GetComponent<TextScroll>().textFinished = 0;
                            currentText = 17;
                        }
                        break;
                    case 17:
                        if (vilText.GetComponent<TextScroll>().textFinished == 2)
                        {
                            runText = true;
                            vilText.GetComponent<TextScroll>().textFinished = 0;
                            currentText = 18;
                        }
                        break;
                    case 18:
                        if (vilText.GetComponent<TextScroll>().textFinished == 2)
                        {
                            runText = true;
                            vilText.GetComponent<TextScroll>().textFinished = 0;
                            currentText = 19;
                        }
                        break;
                    case 19:
                        if (vilText.GetComponent<TextScroll>().textFinished == 2)
                        {
                            runText = true;
                            vilText.GetComponent<TextScroll>().textFinished = 0;
                            currentText = 20;
                        }
                        break;
                    case 20:

                        break;
                }
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

