using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using static System.Net.Mime.MediaTypeNames;

public class LineButtom : MonoBehaviour
{
    [SerializeField] GameObject LineSystemUI;
    // ���C���̗F�B�̃{�^���֘A
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
    public GameObject PhoneUI;
    public GameObject PhoneLineUI;

    //���C���p�̃t���O����
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
    public static bool Text10 = false;
    public static bool Text11 = false;
    public static bool Text12 = false;
    public static bool Text13= false;
    public static bool Text14= false;
    public static bool Text15= false;
    public static bool Text16= false;
    public static bool Text17= false;
    public static bool Text18= false;
    public static bool FirstText = false;
    public static bool TextRndFlag = true;
    public static bool SelectTextUIFlag = false;

    public static int SelectX, SelectC, SelectV;
    [SerializeField] Button LineButton;

    bool MenuFlag = true;
    bool HomeBack = true;
    //�C���v�b�g�V�X�e��
    private InputAction LineX;
    private InputAction LineA;
    private InputAction LineB;
    private InputAction LineY;
    private InputAction LineL;
    private InputAction LineR;

    // line�̕]����UI�ƃt���O
    [SerializeField] GameObject EvaluationUI;
    public static bool LinePerfect = false;
    public static bool LineNormal = false;
    public static bool LineBad = false;
    public static bool Evaluation = false;



    // Start is called before the first frame update
    void Start()
    {
        Karepi.Select();
        if (!ButtonManager.TwiXFlag)
        {
            TalkHome.SetActive(false);
            KarepiTalk.SetActive(false);
            OshiTalk.SetActive(false);
            ManeChanTalk.SetActive(false);
            Tomodati1Talk.SetActive(false);
            Tomodati2Talk.SetActive(false);
            PhoneLineUI.SetActive(false);
        }

    }

    void OnEnable()
    {
        TalkHome.SetActive(true);
        PhoneUI.SetActive(false);
        PhoneLineUI.SetActive(true);
        Karepi.Select();
        ButtonManager.TwiXFirstFlag = false;
        
        var pInput = GetComponent<PlayerInput>();
        var actionMap = pInput.currentActionMap;
        LineX = actionMap["LineSelectX"];
        LineA = actionMap["LineSelectA"];
        LineB = actionMap["LineSelectB"];
        LineY = actionMap["LineBackY"];
        LineR = actionMap["MoveR"];
        LineL = actionMap["MoveL"];
        ShowObject();
        
    }

    private void Update()
    {
        //�߂�
        if(!MenuFlag)
        {
            bool LineButtonX = LineX.triggered;
            bool LineButtonA = LineA.triggered;
            bool LineButtonB = LineB.triggered;
            bool LineButtonY = LineY.triggered;
            bool LineButtonR = LineR.triggered;
            bool LineButtonL = LineL.triggered;


            #region ���C���Q�[�����[���ړ�
            // ���ւ̈ړ�
            if (LineButtonL && PlayerMovement.currentLane > 0 && !Input.GetKey(KeyCode.LeftShift))
            {
                //PlayerMovement.currentLane--;
                PlayerMovement.instance.MoveToLane();
            }

            // �E�ւ̈ړ�
            if (LineButtonR && PlayerMovement.currentLane < 2 && !Input.GetKey(KeyCode.LeftShift))
            {
                //PlayerMovement.currentLane++;
                PlayerMovement.instance.MoveToLane();
            }
            #endregion





            #region �A�v�������
            if (LineButtonY)
            {
                TalkHome.SetActive(true);
                KarepiTalk.SetActive(false);
                OshiTalk.SetActive(false);
                ManeChanTalk.SetActive(false);
                Tomodati1Talk.SetActive(false);
                Tomodati2Talk.SetActive(false);
                EvaluationUI.SetActive(false);
                LinePerfect = false;
                LineNormal = false;
                LineBad = false;
                Evaluation = false;
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
                KarepiFlag = false;
                ManeChanFlag = false;
                OshiFlag = false;
                Tomodati1Flag = false;
                Tomodati2Flag = false;
                SelectTextUIFlag = false;
                Invoke(nameof(MenuStart),0.5f);
            }
            #endregion

            if (LineButtonX && !ButtonOFFFlag)
            {
                if (SelectFlag)
                {
                    SelectKey(1);
                    SelectFlag = false;
                }
                else
                {
                    Debug.Log("X�{�^����������܂���");
                    XButtonFlag = true;
                }
                SelectTextUIFlag = false;
                ButtonOFFFlag = true;
            }
            else if (LineButtonA && !ButtonOFFFlag)
            {
                if (SelectFlag)
                {
                    SelectKey(2);
                    SelectFlag = false;
                }
                else
                {
                    Debug.Log("C�{�^����������܂���");
                    CButtonFlag = true;
                }
                SelectTextUIFlag = false;
                ButtonOFFFlag = true;
            }
            else if (LineButtonB && !ButtonOFFFlag)
            {
                if (SelectFlag)
                {
                    SelectKey(3);
                    SelectFlag = false;
                }
                else
                {
                    Debug.Log("V�{�^����������܂���");
                    VButtonFlag = true;
                }
                SelectTextUIFlag = false;
                ButtonOFFFlag = true;
            }
        }
        // line���j���[�ɂ������̏���
        else if(MenuFlag && HomeBack)
        {
            // line�����
            bool LineButtonY = LineY.triggered;
            if (LineButtonY)
            {
                LineSystemUI.SetActive(false);
                Debug.Log("���񂿂���񂱂Ђ�");
                TalkHome.SetActive(false);
                PhoneLineUI.SetActive(false);
                PhoneUI.SetActive(true);
                LineButton.Select();
                ButtonManager.TwiXFlag = false;
            }
        }

    
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
            Debug.Log("�t���O�I��1�I"+Text1);
        }
        else if (SelectText == 2)
        {
            Text2 = true;
            Debug.Log("�t���O�I��2�I" + Text2);
        }
        else if (SelectText == 3)
        {
            Text3 = true;
            Debug.Log("�t���O�I��3�I" + Text3);
        }
        else if (SelectText == 4)
        {
            Text4 = true;
            Debug.Log("�t���O�I��4�I" + Text4);
        }
        else if (SelectText == 5)
        {
            Text5 = true;
            Debug.Log("�t���O�I��5�I" + Text5);
        }
        else if (SelectText == 6)
        {
            Text6 = true;
            Debug.Log("�t���O�I��6�I" + Text6);
        }
        else if (SelectText == 7)
        {
            Text7 = true;
            Debug.Log("�t���O�I��7�I" + Text7);
        }
        else if (SelectText == 8)
        {
            Text8 = true;
            Debug.Log("�t���O�I��8�I" + Text8);
        }
        else if (SelectText == 9)
        {
            Text9 = true;
            Debug.Log("�t���O�I��9�I" + Text9);
        }
        else if (SelectText == 10)
        {
            Text10 = true;
            Debug.Log("�t���O�I��2�I" + Text2);
        }
        else if (SelectText == 11)
        {
            Text11 = true;
            Debug.Log("�t���O�I��3�I" + Text3);
        }
        else if (SelectText == 12)
        {
            Text12 = true;
            Debug.Log("�t���O�I��4�I" + Text4);
        }
        else if (SelectText == 13)
        {
            Text13 = true;
            Debug.Log("�t���O�I��5�I" + Text5);
        }
        else if (SelectText == 14)
        {
            Text14 = true;
            Debug.Log("�t���O�I��6�I" + Text6);
        }
        else if (SelectText == 15)
        {
            Text15 = true;
            Debug.Log("�t���O�I��7�I" + Text7);
        }
        else if (SelectText == 16)
        {
            Text16 = true;
            Debug.Log("�t���O�I��8�I" + Text8);
        }
        else if (SelectText == 17)
        {
            Text17 = true;
            Debug.Log("�t���O�I��9�I" + Text9);
        }
        else if (SelectText == 18)
        {
            Text18 = true;
            Debug.Log("�t���O�I��9�I" + Text9);
        }
    }


    // �\������ۂɌĂяo�����֐�
    public void ShowObject()
    {
        // InputAction�̗L����
        LineX.Enable();
        LineA.Enable();
        LineB.Enable();
        LineY.Enable();
        var pInput = GetComponent<PlayerInput>();
        var actionMap = pInput.currentActionMap;
        LineX = actionMap["LineSelectX"];
        LineA = actionMap["LineSelectA"];
        LineB = actionMap["LineSelectB"];
        LineY = actionMap["LineBackY"];
    }


    //���C���̃{�^��

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
        HomeBack = false;
        MenuFlag = false;
    }
    public void MenuStart()
    {
        HomeBack = true;
        MenuFlag = true;
    }
}
