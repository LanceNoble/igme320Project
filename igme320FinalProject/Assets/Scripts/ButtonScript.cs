using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool buttonPressed;
    [SerializeField] DialogueManager dManager;
    public void ButtonPressed()
    {
        dManager.buttonValue = 1;
    }
 
}
