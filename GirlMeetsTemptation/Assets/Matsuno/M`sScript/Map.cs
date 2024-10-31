using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject GoalObjext;
    float distanceOfPlayer;
    float currentDistance;
    float StartDistanceOfPlayer;
    //Sliderを入れる
    public Slider slider;

    void Start()
    {
        StartDistanceOfPlayer = Vector3.Distance(Player.transform.position, GoalObjext.transform.position);
        //Sliderを満タンにする。
        slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーとゴールまでの距離の計算
        distanceOfPlayer = Vector3.Distance(Player.transform.position, GoalObjext.transform.position);
        Debug.Log("ゴールまでの距離:" + distanceOfPlayer);

        //if(/*マップを開くフラグがオンの時*/)
        //{
            //(float)をつけてfloatの変数として振舞わせる。
            slider.value = distanceOfPlayer / StartDistanceOfPlayer;
        //}
    }
}
