using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;

    public static bool TwiXFlag = false;
    public static bool TwiXFirstFlag = false;
    public static bool GMapFlag = false;
    public static bool GMapFirstFlag = false;

    [Header("プレイヤー・プレイヤー入力")]
    public GameObject PlayerObj;
    private PlayerInput pInput;
    public static bool mainInput;

    [Header("ミニゲーム入力")]
    public GameObject MiniObj;
    private PlayerInput MiniInput;

    [Header("Line入力")]
    public GameObject LineObj;
    private PlayerInput LineInput;


    [SerializeField] GameObject GMapUI;
    [SerializeField] GameObject LineObject;

    private void Awake()
    {
        pInput = PlayerObj.GetComponent<PlayerInput>();
        MiniInput = MiniObj.GetComponent<PlayerInput>();
        LineInput = LineObj.GetComponent<PlayerInput>();
        PlayInputSet();
        Debug.Log("プレイヤー入力可能");
    }

    private void Update()
    {
        if (MiniGameManager.isOpen)
        {
            MiniInputSet();
            mainInput = false;
        }
        else if (TwiXFlag)
        {
            LineInputSet();
            mainInput = false;
        }
        else
        {
            PlayInputSet();
            mainInput = true;
        }
    }
    public void ClickButton(string button)
    {
        switch (button)
        {
            case "LINE":
                Debug.Log(button + "が押された！");
                LineInputSet();
                TwiXFlag = true;
                TwiXFirstFlag = true;
                LineObject.SetActive(true);
                break;
            case "Twitter":
                Debug.Log(button + "が押された！");
                //PlayInputSet(false);
                GMapFlag = true;
                GMapFirstFlag = true;
                GMapUI.SetActive(true);
                break;
            case "Game":
                Debug.Log(button + "が押された！");
                MiniInputSet();
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

    public void PlayInputSet()
    {
        pInput.enabled = true;
        MiniInput.enabled = false;
        LineInput.enabled = false;
    }

    public void MiniInputSet()
    {
        MiniInput.enabled = true;
        pInput.enabled = false;
        LineInput.enabled = false;
    }

    public void LineInputSet()
    {
        LineInput.enabled = true;
        pInput.enabled = false;
        MiniInput.enabled = false;
    }
}
