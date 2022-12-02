using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Sprite back;
    [SerializeField] Sprite neutral;
    [SerializeField] Sprite playing;
    [SerializeField] Sprite scared;
    [SerializeField] Sprite thinking;
    [SerializeField] SpriteRenderer playRender;
    public int currentEmote = 3;
    // Update is called once per frame
    void Update()
    {
        switch (currentEmote)
        {
            case 0:
                playRender.sprite = back;
                break;
            case 1:
                playRender.sprite = neutral;
                break;
            case 2:
                playRender.sprite = playing;
                break;
            case 3:
                playRender.sprite = scared;
                break;
            case 4:
                playRender.sprite = thinking;
                break;
           
        }
    }
}
