using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    [Header("生成プレハブ")]
    public GameObject TopObj;
    public GameObject MidObj;
    public GameObject BotObj;
    public GameObject MeteoObj;

    public GameObject CoinObj;

    [Header("レーン位置")]
    public Transform TopPos;
    public Transform MidPos;
    public Transform BotPos;
    public float Top;
    public float Mid;
    public float Bot;

    [Header("生成単位")]
    public int Chunk;
    public int StartPos = 132;

    [Header("プレイヤー")]
    public GameObject PlayerObj;
    public GameObject CameraObj;

    private int i;
    private float time;
    private float CoinTime;

    static MapGen instance;

    void OnEnable()
    {
        time = 0;
        CoinTime = 0;
        StartPos = 132;
        MiniGameManager.MiniDeathID = 0;
        for(i = 88; i <= 132; i+= 2)
        {
            StartMapGen(i);
        }
        PlayerObj.transform.position = new Vector3(100, 0, 0);
        CameraObj.transform.position = new Vector3(100, 3.5f, -18.56f);

    }

    void Update()
    {
        if (!MiniGameManager.islunatic && MiniGameManager.isStart && MiniGameManager.isOpen)
        {
            time += Time.deltaTime;
            if (time > 3f)
            {
                int rnd = Random.Range(0, 10);
                if (rnd <= 4)
                {
                    MeteoBarn();
                }
                time = 0f;
            }

            if(MiniGameManager.SubMissionID == 1)
            {
                CoinTime += Time.deltaTime;
                if (CoinTime > 7f)
                {
                    int rnd1 = Random.Range(0, 10);
                    if (rnd1 <= 2)
                    {
                        Instantiate(CoinObj, new Vector3(StartPos, BotPos.position.y + 3, 0f), Quaternion.identity);
                    }
                    else if (rnd1 <= 6)
                    {
                        Instantiate(CoinObj, new Vector3(StartPos, MidPos.position.y + 3, 0f), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(CoinObj, new Vector3(StartPos, TopPos.position.y + 3, 0f), Quaternion.identity) ;
                    }
                    CoinTime = 0f;
                }
            }
        }

        if (Input.GetKeyDown("u")){
            Instantiate(TopObj, new Vector3(StartPos, TopPos.position.y, 0f), Quaternion.identity);
            Instantiate(MidObj, new Vector3(StartPos, MidPos.position.y, 0f), Quaternion.identity);
            Instantiate(BotObj, new Vector3(StartPos, BotPos.position.y, 0f), Quaternion.identity);
            StartPos += 2;
        }
        
    }

    public void InitMapGen()
    {
        for(i = 100 - 12; i <= 32; i+=2)
        {
            Instantiate(TopObj, new Vector3(i, TopPos.position.y, 0f), Quaternion.identity);
            Instantiate(MidObj, new Vector3(i, MidPos.position.y, 0f), Quaternion.identity);
            Instantiate(BotObj, new Vector3(i, BotPos.position.y, 0f), Quaternion.identity);
        }
    }

    public void StartMapGen(int st)
    {
        Instantiate(TopObj, new Vector3(st, TopPos.position.y, 0f), Quaternion.identity);
        Instantiate(MidObj, new Vector3(st, MidPos.position.y, 0f), Quaternion.identity);
        Instantiate(BotObj, new Vector3(st, BotPos.position.y, 0f), Quaternion.identity);
    }

    public void CreateMap()
    {
        Instantiate(TopObj, new Vector3(StartPos, TopPos.position.y, 0f), Quaternion.identity);
        Instantiate(MidObj, new Vector3(StartPos, MidPos.position.y, 0f), Quaternion.identity);
        Instantiate(BotObj, new Vector3(StartPos, BotPos.position.y, 0f), Quaternion.identity);
        StartPos += 2;
    }


    public void MeteoBarn()
    {
        Instantiate(MeteoObj, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

    }

}
