using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void ClickButton(string button)
    {
        switch (button)
        {
            case "LINE":
                Debug.Log(button + "�������ꂽ�I");
                break;
            case "Twitter":
                Debug.Log(button + "�������ꂽ�I");
                break;
            case "Game":
                Debug.Log(button + "�������ꂽ�I");
                MiniGameManager.isOpen = true;
                break;
            case "Spotify":
                Debug.Log(button + "�������ꂽ�I");
                break;
            case "soundUP":
                Debug.Log(button + "�������ꂽ�I");
                break;
            case "soundDOWN":
                Debug.Log(button + "�������ꂽ�I");
                break;
            default:
                break;
        }
    }
}
