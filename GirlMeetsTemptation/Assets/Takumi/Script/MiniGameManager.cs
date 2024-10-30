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
    //ミニゲームUI
    public GameObject MainPhoneUI;
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
            PhoneRote(isOpen);
            MiniGame.SetActive(isOpen);
            MiniGameUI.SetActive(isOpen);
            MapGen.InitMapGen();
        }
        else
        {
            PhoneRote(isOpen);
            isStart = false;
            MapDestroy();
            MiniGame.SetActive(isOpen);
            MiniGameUI.SetActive(isOpen);
        }

        Debug.Log("isOpen : " + isOpen);
        Debug.Log("isStart : " + isStart);

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

    void PhoneRote(bool game)
    {
        if (game)
        {
            MainPhoneUI.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            MainPhoneUI.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
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
