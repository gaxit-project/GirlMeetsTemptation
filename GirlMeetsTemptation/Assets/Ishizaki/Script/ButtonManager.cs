using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static bool TwiXFlag = false;
    public static bool TwiXFirstFlag = false;
    [SerializeField] GameObject LineObject;
    public void ClickButton(string button)
    {
        switch (button)
        {
            case "LINE":
                Debug.Log(button + "が押された！");
                TwiXFlag = true;
                TwiXFirstFlag = true;
                LineObject.SetActive(true);
                break;
            case "Twitter":
                Debug.Log(button + "が押された！");
                break;
            case "Game":
                Debug.Log(button + "が押された！");
                MiniGameManager.isOpen = true;
                break;
            case "Spotify":
                Debug.Log(button + "が押された！");
                break;
            case "soundUP":
                Debug.Log(button + "が押された！");
                break;
            case "soundDOWN":
                Debug.Log(button + "が押された！");
                break;
            default:
                break;
        }
    }
}
