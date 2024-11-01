using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    [SerializeField] GameObject MapApp;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject GoalObjext;
    [SerializeField] GameObject CarBar;
    [SerializeField] GameObject HumanBar;
    [SerializeField] GameObject BicycleBar;
    [SerializeField] Button LineButton;
    float distanceOfPlayer;
    float StartDistanceOfPlayer;
    //Slider������
    public Slider slider;

    // �{�^���Ƃ��̃t���O
    public Button CarButton;
    public Button HumanButton;
    public Button BicycleButton;
    bool CarFlag = true;
    bool HumanFlag = false;
    bool BicycleFlag = false;

    [SerializeField] TextMeshProUGUI DistanceText;

    // �����܂ł̋����Ɠ������Ԃ̕ϐ�
    int Distance = 0;
    public static int Timer = 0;
    public static int CarTimer = 0;
    int BicycleTimer = 0;

    void Start()
    {
        StartDistanceOfPlayer = Vector3.Distance(Player.transform.position, GoalObjext.transform.position);
        //Slider�𖞃^���ɂ���B
        slider.value = 1;
        CarBar.SetActive(true);
        HumanBar.SetActive(false);
        BicycleBar.SetActive(false);
        MapApp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�ƃS�[���܂ł̋����̌v�Z
        distanceOfPlayer = Vector3.Distance(Player.transform.position, GoalObjext.transform.position);
        Distance = (int)distanceOfPlayer * 3;
        Timer = Distance / 100;
        Debug.Log("�c�莞��" + Timer);
        if(Timer < 1)
        {
            Timer = 1;
        }
        CarTimer = Timer / 4;
        if (CarTimer < 1)
        {
            CarTimer = 1;
        }

        if (ButtonManager.GMapFlag)
        {
            if (ButtonManager.GMapFirstFlag)
            {
                UIOFF();
                CarBar.SetActive(true);
                CarButton.Select();
                ButtonManager.GMapFirstFlag = false;
            }
            //(float)������float�̕ϐ��Ƃ��ĐU���킹��B
            slider.value = distanceOfPlayer / StartDistanceOfPlayer;

            // �A�v�������
            if (Input.GetKey(KeyCode.Z))
            {
                ButtonManager.GMapFlag = false;
                MapApp.SetActive(false);
                LineButton.Select();
            }

            if(CarFlag)
            {
                DistanceText.text = "��" + CarTimer.ToString() + "��(" + Distance.ToString() + "m)\n��ʏ��𔽉f���������_�̍ŒZ���[�g";
            }
            else if(HumanFlag)
            {
                DistanceText.text = "��" + Timer.ToString() + "��(" + Distance.ToString() + "m)\n��ʏ��𔽉f���������_�̍ŒZ���[�g";
            }
            else if(BicycleFlag)
            {
                BicycleTimer = Timer / 3;
                if (BicycleTimer < 1)
                {
                    BicycleTimer = 1;
                }
                DistanceText.text = "��" + BicycleTimer.ToString() + "��(" + Distance.ToString() + "m)\n��ʏ��𔽉f���������_�̍ŒZ���[�g";
            }
        }
    }
    public void CarNav()
    {
        FlagOFF();
        UIOFF();
        CarFlag = true;
        CarBar.SetActive(true);
    }

    public void HumanNav()
    {
        FlagOFF();
        UIOFF();
        HumanFlag = true;
        HumanBar.SetActive(true);
    }

    public void BocycleNav()
    {
        FlagOFF();
        UIOFF();
        BicycleFlag = true;
        BicycleBar.SetActive(true);
    }

    void FlagOFF()
    {
        CarFlag = false;
        HumanFlag = false;
        BicycleFlag = false;
    }
    void UIOFF()
    {
        CarBar.SetActive(false);
        HumanBar.SetActive(false);
        BicycleBar.SetActive(false);
    }
}
