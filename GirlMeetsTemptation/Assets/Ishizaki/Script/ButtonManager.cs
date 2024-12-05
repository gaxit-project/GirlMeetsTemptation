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

    [Header("�v���C���[�E�v���C���[����")]
    public GameObject PlayerObj;
    private PlayerInput pInput;

    [Header("�~�j�Q�[������")]
    public GameObject MiniObj;
    private PlayerInput MiniInput;

    [Header("Line����")]
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
        MiniGameManager.isOpen = false;
        Debug.Log("�v���C���[���͉\");
    }

    private void Update()
    {
        if (MiniGameManager.isOpen)
        {
            MiniInputSet();
        }
        else if (TwiXFlag)
        {
            LineInputSet();
        }
        else
        {
            PlayInputSet();
        }
    }
    public void ClickButton(string button)
    {
        switch (button)
        {
            case "LINE":
                Debug.Log(button + "�������ꂽ�I");
                LineInputSet();
                TwiXFlag = true;
                TwiXFirstFlag = true;
                LineObject.SetActive(true);
                break;
            case "Twitter":
                Debug.Log(button + "�������ꂽ�I");
                //PlayInputSet(false);
                GMapFlag = true;
                GMapFirstFlag = true;
                GMapUI.SetActive(true);
                break;
            case "Game":
                Debug.Log(button + "�������ꂽ�I");
                MiniInputSet();
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

    public void PlayInputSet()
    {
        pInput.enabled = true;
        /*MiniInput.enabled = false;
        LineInput.enabled = false;*/
    }

    public void MiniInputSet()
    {
        MiniInput.enabled = true;
        /*pInput.enabled = false;
        LineInput.enabled = false;*/
    }

    public void LineInputSet()
    {
        LineInput.enabled = true;
        /*pInput.enabled = false;
        MiniInput.enabled = false;*/
    }
}
