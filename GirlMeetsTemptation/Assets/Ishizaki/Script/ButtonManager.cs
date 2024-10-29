using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static bool TwiXFlag = false;
    public static bool TwiXFirstFlag = false;
    public void ClickButton(string button)
    {
        switch (button)
        {
            case "LINE":
                Debug.Log(button + "が押された！");
                TwiXFlag = true;
                TwiXFirstFlag = true;
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
