using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    [Header("設定")]
    //狂乱ゲージ
    public static bool islunatic = false;
    //ミニゲームが開かれているか
    public static bool isOpen = false;
    //ミニゲームを開始しているか
    public static bool isStart = false;
    //ミニゲーム
    public GameObject MiniGame;
    //ミニゲームUI
    public GameObject MiniGameUI;
    //ミニゲームMap
    public MapGen MapGen;





    //死亡時の種類
    //0 :何もなし 
    //1 :落下
    //2 :車の衝突
    //3 :頭上からの落下物(未実装)
    public static int MiniDeathID = 0;

    public static MiniGameManager instance;


    void Start()
    {
        //Time.timeScale = 0.0f;
        MiniDeathID = 0;
        MapGen.InitMapGen();

    }

    void Update()
    {
        if (isOpen)
        {
            MiniGame.SetActive(isOpen);
            MiniGameUI.SetActive(isOpen);
            MapGen.InitMapGen();
        }
        else
        {
            isStart = false;
            MiniGame.SetActive(isOpen);
            MiniGameUI.SetActive(isOpen);
        }

        //デバッグ用
        if(Input.GetKeyDown("k"))
        {
            if (isOpen)
            {
                isOpen = false;
            }
            else
            {
                isOpen= true;
            }
        }
        if (Input.GetKeyDown("l"))
        {
            if (isStart)
            {
                isStart = false;
            }
            else
            {
                isStart = true;
            }
        }
    }
}
