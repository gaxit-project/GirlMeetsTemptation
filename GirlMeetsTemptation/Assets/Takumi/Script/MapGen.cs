using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    [Header("Map生成プレハブ")]
    public GameObject TopObj;
    public GameObject MidObj;
    public GameObject BotObj;
    public GameObject MeteoObj;

    [Header("レーン位置")]
    public Transform TopPos;
    public Transform MidPos;
    public Transform BotPos;
    public float Top;
    public float Mid;
    public float Bot;

    [Header("生成単位")]
    public int Chunk;
    public int StartPos = 100;

    private int i;
    private float time;

    static MapGen instance;

    void OnEnable()
    {
        InitMapGen();
        if (!MiniGameManager.islunatic && MiniGameManager.isStart && MiniGameManager.isOpen)
        {
            MeteoBarn();
        }
    }
    void Start()
    {
        InitMapGen();
        if(!MiniGameManager.islunatic && MiniGameManager.isStart && MiniGameManager.isOpen)
        {
            MeteoBarn();
        }
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
        }
        Debug.Log("StartPos : " + StartPos);
        
    }

    public void InitMapGen()
    {
        for(i = 100 - 12; i <= 32; i+=2)
        {
            Instantiate(TopObj, new Vector3(i, TopPos.position.y, 0f), Quaternion.identity);
            Instantiate(MidObj, new Vector3(i, MidPos.position.y, 0f), Quaternion.identity);
            Instantiate(BotObj, new Vector3(i, BotPos.position.y, 0f), Quaternion.identity);
            Debug.Log("生成ーーーー");
        }
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
