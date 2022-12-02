using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VilAnimate : MonoBehaviour
{
    [SerializeField] Sprite annoyed;
    [SerializeField] Sprite confident;
    [SerializeField] Sprite confused;
    [SerializeField] Sprite happy;
    [SerializeField] Sprite infinite;
    [SerializeField] Sprite neutral;
    [SerializeField] Sprite woe;
    [SerializeField] SpriteRenderer bgRender;
    public int currentEmote = 1;
    // Update is called once per frame
    void Update()
    {
        switch (currentEmote)
        {
            case 0:
                bgRender.sprite = annoyed;
                break;
            case 1:
                bgRender.sprite = confident;
                break;
            case 2:
                bgRender.sprite = confused;
                break;
            case 3:
                bgRender.sprite = happy;
                break;
            case 4:
                bgRender.sprite = infinite;
                break;
            case 5:
                bgRender.sprite = neutral;
                break;
            case 6:
                bgRender.sprite = woe;
                break;
        }
    }
}
