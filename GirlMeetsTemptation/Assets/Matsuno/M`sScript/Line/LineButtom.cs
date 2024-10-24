using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class LineButtom : MonoBehaviour
{
    
    // ラインの友達のボタン関連
    public Button Karepi;
    public Button Oshi;
    public Button Ozi;
    public Button Tomodati1;
    public Button Tomodati2;
    public GameObject TalkHome;
    public GameObject KarepiTalk;
    public GameObject OshiTalk;
    public GameObject ManeChanTalk;
    public GameObject Tomodati1Talk;
    public GameObject Tomodati2Talk;

    //ライン用のフラグたち
    public static bool KarepiFlag = false;
    public static bool ManeChanFlag = false;
    public static bool OshiFlag = false;
    public static bool Tomodati1Flag = false;
    public static bool Tomodati2Flag = false;
    public static bool XButtonFlag = false;
    public static bool CButtonFlag = false;
    public static bool VButtonFlag = false;
    public static bool ButtonOFFFlag = false;
    public static bool SelectFlag = false;

    public static bool Text1 = false;
    public static bool Text2 = false;
    public static bool Text3 = false;
    public static bool Text4 = false;
    public static bool Text5 = false;
    public static bool Text6 = false;
    public static bool Text7 = false;
    public static bool Text8 = false;
    public static bool Text9 = false;
    public static bool FirstText = false;
    public static bool TextRndFlag = true;

    public static int SelectX, SelectC, SelectV;

    bool MenuFlag = true;
    //インプットシステム
    private InputAction LineX;
    private InputAction LineA;
    private InputAction LineB;
    private InputAction LineY;
    // Start is called before the first frame update
    void Start()
    {
        Karepi.Select();
        //if(//ラインフラグがオフなら)
        //{
        //    TalkHome.SetActive(false);
        //    KarepiTalk.SetActive(false);
        //    OshiTalk.SetActive(false);
        //    ManeChanTalk.SetActive(false);
        //    Tomodati1Talk.SetActive(false);
        //    Tomodati2Talk.SetActive(false);
        //}

        var pInput = GetComponent<PlayerInput>();
        var actionMap = pInput.currentActionMap;
        LineX = actionMap["LineSelectX"];
        LineA = actionMap["LineSelectA"];
        LineB = actionMap["LineSelectB"];
        LineY = actionMap["LineBackY"];

    }

    private void Update()
    {
        
        //if(//ラインフラグがオンなら)
        //{
        //    TalkHome.SetActive(true);
        //    Karepi.Select();
        //戻る
        if(!MenuFlag)
        {
            bool LineButtonX = LineX.triggered;
            bool LineButtonA = LineA.triggered;
            bool LineButtonB = LineB.triggered;
            bool LineButtonY = LineY.triggered;
            Debug.Log("すいっちおおおおおおおおおふ");
            if (Input.GetKey(KeyCode.Z) || LineButtonY)
            {
                TalkHome.SetActive(true);
                KarepiTalk.SetActive(false);
                OshiTalk.SetActive(false);
                ManeChanTalk.SetActive(false);
                Tomodati1Talk.SetActive(false);
                Tomodati2Talk.SetActive(false);
                Text1 = false;
                Text2 = false;
                Text3 = false;
                Text4 = false;
                Text5 = false;
                Text6 = false;
                Text7 = false;
                Text8 = false;
                Text9 = false;
                XButtonFlag = false;
                CButtonFlag = false;
                VButtonFlag = false;
                ButtonOFFFlag = false;
                TextRndFlag = true;
                MenuFlag = true;
            }
            if (LineButtonX && !ButtonOFFFlag || Input.GetKey(KeyCode.X) && !ButtonOFFFlag)
            {
                if (SelectFlag)
                {
                    SelectKey(1);
                    SelectFlag = false;
                }
                else
                {
                    Debug.Log("Xボタンが押されました");
                    XButtonFlag = true;
                }
                ButtonOFFFlag = true;
            }
            else if (LineButtonA && !ButtonOFFFlag || Input.GetKey(KeyCode.C) && !ButtonOFFFlag)
            {
                if (SelectFlag)
                {
                    SelectKey(2);
                    SelectFlag = false;
                }
                else
                {
                    Debug.Log("Cボタンが押されました");
                    CButtonFlag = true;
                }
                ButtonOFFFlag = true;
            }
            else if (LineButtonB && !ButtonOFFFlag || Input.GetKey(KeyCode.V) && !ButtonOFFFlag)
            {
                if (SelectFlag)
                {
                    SelectKey(3);
                    SelectFlag = false;
                }
                else
                {
                    Debug.Log("Vボタンが押されました");
                    VButtonFlag = true;
                }
                ButtonOFFFlag = true;
            }
        }
        
        //}
    }
    public static void SelectKey(int Select1Cnt, int Select2Cnt, int Select3Cnt)
    {
        Debug.Log("X:" + Select1Cnt + "C:" + Select2Cnt + "V:" + Select3Cnt);
        SelectX = Select1Cnt;
        SelectC = Select2Cnt;
        SelectV = Select3Cnt;
    }

    public void SelectKey(int PushKey)
    {
        int SelectText = 0;
        if (PushKey == 1)
        {
            SelectText = SelectX;
        }
        else if(PushKey == 2)
        {
            SelectText = SelectC;
        }
        else if(PushKey == 3)
        {
            SelectText = SelectV;
        }
        FirstText = true;
        if (SelectText == 1)
        {
            Text1 = true;
            Debug.Log("フラグオン1！"+Text1);
        }
        else if (SelectText == 2)
        {
            Text2 = true;
            Debug.Log("フラグオン2！" + Text2);
        }
        else if (SelectText == 3)
        {
            Text3 = true;
            Debug.Log("フラグオン3！" + Text3);
        }
        else if (SelectText == 4)
        {
            Text4 = true;
            Debug.Log("フラグオン4！" + Text4);
        }
        else if (SelectText == 5)
        {
            Text5 = true;
            Debug.Log("フラグオン5！" + Text5);
        }
        else if (SelectText == 6)
        {
            Text6 = true;
            Debug.Log("フラグオン6！" + Text6);
        }
        else if (SelectText == 7)
        {
            Text7 = true;
            Debug.Log("フラグオン7！" + Text7);
        }
        else if (SelectText == 8)
        {
            Text8 = true;
            Debug.Log("フラグオン8！" + Text8);
        }
        else if (SelectText == 9)
        {
            Text9 = true;
            Debug.Log("フラグオン9！" + Text9);
        }
    }

    //ラインのボタン

    public void KarepiPush()
    {
        TalkHome.SetActive(false);
        KarepiTalk.SetActive(true);
        KarepiFlag = true;
        Invoke(nameof(MenuStop), 0.5f);
    }
    public void OshiPush()
    {
        TalkHome.SetActive(false);
        OshiTalk.SetActive(true);
        OshiFlag = true;
        Invoke(nameof(MenuStop), 0.5f);
    }
    public void ManeChanPush()
    {
        TalkHome.SetActive(false);
        ManeChanTalk.SetActive(true);
        ManeChanFlag = true;
        Invoke(nameof(MenuStop), 0.5f);
    }
    public void Tomodati1Push()
    {
        TalkHome.SetActive(false);
        Tomodati1Talk.SetActive(true);
        Tomodati1Flag = true;
        Invoke(nameof(MenuStop), 0.5f);
    }
    public void Tomodati2Push()
    {
        TalkHome.SetActive(false);
        Tomodati2Talk.SetActive(true);
        Tomodati2Flag = true;
        Invoke(nameof(MenuStop), 0.5f);
    }
    public void MenuStop()
    {
        MenuFlag = false;
    }
}
