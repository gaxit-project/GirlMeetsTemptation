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
    //ミニゲームメッセージUI
    public GameObject MiniUI;
    //ミニゲームメッセージUI
    public Text Minitext;
    //メインスマホUI
    public GameObject MainPhoneUI;
    //ミニゲームMap
    public MapGen MapGen;

    float count = 0;

    //コインの枚数
    public static int CoinCount = 0;
    //走行距離
    public static float RunDistance = 0f;

    // サブミッションがクリアしたか
    public static bool SubClear = false;

    //一回変数
    bool isOnce = false;

    //サブミッションの種類
    //0 :何もなし 
    //1 :コインの取得
    //2 :走る距離(未実装)
    public static int SubMissionID = 0;

    //死亡時の種類
    //0 :何もなし 
    //1 :落下
    //2 :車の衝突
    //3 :頭上からの落下物(未実装)
    public static int MiniDeathID = 0;

    float time = 0;



    public static MiniGameManager instance;


    void Start()
    {
        MiniDeathID = 0;
        MapGen.InitMapGen();

    }

    void Update()
    {
        if (isOpen)
        {
            if (isStart)
            {
                MiniUI.SetActive(false);
            }
            else
            {
                MiniUI.SetActive(true);
            }

            time += Time.deltaTime;
            int ITime = (int)time;
            if(ITime == 1)
            {
                Minitext.text = "2";
            }
            else if(ITime == 2)
            {
                Minitext.text = "1";
            }
            else if(ITime == 3)
            {
                Minitext.text = "Go!";
            }
            else if(ITime >= 4)
            {
                isStart = true;
            }

            if(MiniDeathID != 0)
            {
                isStart = false;
                Minitext.text = "GameOver";
            }

            MiniGame.SetActive(isOpen);
            MiniGameUI.SetActive(isOpen);
            MainPhoneUI.SetActive(false);
            MapGen.InitMapGen();

        }
        else
        {
            Minitext.text = "3";
            time = 0;
            isStart = false;
            MapDestroy();
            MiniGame.SetActive(isOpen);
            MiniGameUI.SetActive(isOpen);
            MainPhoneUI.SetActive(true);
        }

        if (SubClear)
        {
            //名声スコア+10
            SubClear = false;
            if (!isOnce)
            {
                //名声スコア+10

                //Sound

                StartCoroutine(SubMissionReset());
            }

        }


        //デバッグ用
        if (Input.GetKeyDown("k"))
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

        if (Input.GetKeyDown("p"))
        {
            SubMissionID = 1;
        }
    }

    IEnumerator SubMissionReset()
    {
        yield return new WaitForSeconds(3);
        SubMissionID = 0;
    }

    void MapDestroy()
    {
        GameObject[] Top = GameObject.FindGameObjectsWithTag("Top");
        foreach (GameObject top in Top)
        {
            Destroy(top);
        }
        GameObject[] Mid = GameObject.FindGameObjectsWithTag("Mid");
        foreach (GameObject mid in Mid)
        {
            Destroy(mid);
        }
        GameObject[] Bot = GameObject.FindGameObjectsWithTag("Bot");
        foreach (GameObject bot in Bot)
        {
            Destroy(bot);
        }
        GameObject[] Human = GameObject.FindGameObjectsWithTag("Human");
        foreach (GameObject human in Human)
        {
            Destroy(human);
        }
        GameObject[] Car = GameObject.FindGameObjectsWithTag("Car");
        foreach (GameObject car in Car)
        {
            Destroy(car);
        }
        GameObject[] Meteo = GameObject.FindGameObjectsWithTag("Meteo");
        foreach (GameObject meteo in Meteo)
        {
            Destroy(meteo);
        }
    }
}
