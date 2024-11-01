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
    //Sliderを入れる
    public Slider slider;

    // ボタンとそのフラグ
    public Button CarButton;
    public Button HumanButton;
    public Button BicycleButton;
    bool CarFlag = true;
    bool HumanFlag = false;
    bool BicycleFlag = false;

    [SerializeField] TextMeshProUGUI DistanceText;

    // 到着までの距離と到着時間の変数
    int Distance = 0;
    public static int Timer = 0;
    public static int CarTimer = 0;
    int BicycleTimer = 0;

    void Start()
    {
        StartDistanceOfPlayer = Vector3.Distance(Player.transform.position, GoalObjext.transform.position);
        //Sliderを満タンにする。
        slider.value = 1;
        CarBar.SetActive(true);
        HumanBar.SetActive(false);
        BicycleBar.SetActive(false);
        MapApp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーとゴールまでの距離の計算
        distanceOfPlayer = Vector3.Distance(Player.transform.position, GoalObjext.transform.position);
        Distance = (int)distanceOfPlayer * 3;
        Timer = Distance / 100;
        Debug.Log("残り時間" + Timer);
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
            //(float)をつけてfloatの変数として振舞わせる。
            slider.value = distanceOfPlayer / StartDistanceOfPlayer;

            // アプリを閉じる
            if (Input.GetKey(KeyCode.Z))
            {
                ButtonManager.GMapFlag = false;
                MapApp.SetActive(false);
                LineButton.Select();
            }

            if(CarFlag)
            {
                DistanceText.text = "約" + CarTimer.ToString() + "分(" + Distance.ToString() + "m)\n交通情報を反映した現時点の最短ルート";
            }
            else if(HumanFlag)
            {
                DistanceText.text = "約" + Timer.ToString() + "分(" + Distance.ToString() + "m)\n交通情報を反映した現時点の最短ルート";
            }
            else if(BicycleFlag)
            {
                BicycleTimer = Timer / 3;
                if (BicycleTimer < 1)
                {
                    BicycleTimer = 1;
                }
                DistanceText.text = "約" + BicycleTimer.ToString() + "分(" + Distance.ToString() + "m)\n交通情報を反映した現時点の最短ルート";
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
